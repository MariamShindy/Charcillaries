using Minio;
using Minio.DataModel.Args;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;

namespace Charcillaries.Migration._1000;

[Migration(1009)]
public class _1009_SeedAmenityTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var amenities =
            JsonNode.Parse(
                File.ReadAllText(
                    $"1000{Path.DirectorySeparatorChar}JsonData{Path.DirectorySeparatorChar}amenities.json"))![
                "amenities"]!.AsArray();

        var amenityAirlineDictionary = new Dictionary<int, HashSet<string>>();

        var amenityId = 0;
        var randomAmenities = new Faker<Amenity>()
            .Rules((f, x) =>
            {
                var amenity = f.Random.CollectionItem(amenities)!;
                amenityAirlineDictionary.TryGetValue(amenityId / 5 + 1, out var set);
                set ??= [];

                while (set.Contains(amenity["name"]!.ToString()))
                {
                    amenity = f.Random.CollectionItem(amenities)!;
                }

                set.Add(amenity["name"]!.ToString());
                amenityAirlineDictionary[amenityId / 5 + 1] = set;

                x.name = amenity["name"]!.ToString();
                x.description = amenity["description"]!.ToString();
                x.icon = string.IsNullOrEmpty(amenity["icon"]!.ToString())
                    ? null
                    : Guid.Parse(amenity["icon"]!.ToString());
            })
            .RuleFor(x => x.airline_id, f => amenityId++ / 5 + 1)
            .Generate(50);

        foreach (var amenity in randomAmenities)
            Insert.IntoTable(Tables.Amenity).Row(amenity);

        var minio = new MinioClient()
            .WithEndpoint("garage.incubator-infra.demoday.us")
            .WithRegion("garage")
            .WithCredentials("GKefe8dc8fd3fcd715dd3df07e",
                "8e85e2c9daa48f9f9805aa164ac0384133a21d7d765f966c67fa128789dacc0f")
            .WithSSL()
            .WithHttpClient(new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, cert, chain, errors) =>
                {
                    if (errors == SslPolicyErrors.None)
                        return true;
                    return chain is not null && chain.ChainElements.Any(x => x.Certificate.Equals(cert));
                },
                ClientCertificates =
                        {
                            GetOrCreateCertificate()
                        }
            }
                )
            );

        PutImage(minio, amenities).Wait();
    }

    public override void Down()
    {
    }

    private async Task PutImage(IMinioClient minio, JsonArray amenities)
    {
        var images = Directory.GetFiles($"1000{Path.DirectorySeparatorChar}Resources");
        foreach (var rawImage in images)
        {
            var imageName = Path.GetFileName(rawImage).Split(".")[0];
            // get guid from json with name == imageName
            var guid = amenities.First(x => x!["name"]!.ToString() == imageName)!["icon"]!.ToString();

            try
            {
                var statObjectResponse =
                    await minio.StatObjectAsync(new StatObjectArgs()
                        .WithBucket("charcillaries")
                        .WithObject(guid));
                if (statObjectResponse is not null)
                    continue;
            }
            catch
            {
                // ignored
            }

            var image = await Image.LoadAsync(rawImage);

            image.Mutate(x => x.Resize(0, 256, KnownResamplers.Lanczos3));
            await using var stream = new MemoryStream();
            await image.SaveAsWebpAsync(stream, new WebpEncoder { Quality = 75 });

            stream.Position = 0;
            await minio.PutObjectAsync(new PutObjectArgs().WithBucket("charcillaries")
                .WithObjectSize(stream.Length)
                .WithStreamData(stream)
                .WithContentType("image/webp")
                .WithObject(guid));
        }
    }

    X509Certificate2 GenerateCertificate()
    {
        using var rsa = RSA.Create(2048);
        var request = new CertificateRequest("cn=charcillaries.garage.incubator-infra.demoday.us", rsa,
            HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        var certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));
        return certificate;
    }

    X509Certificate2 GetOrCreateCertificate()
    {
        if (File.Exists("garage.cer"))
        {
            var cert = X509CertificateLoader.LoadCertificateFromFile("garage.cer");

            if (cert.NotAfter > DateTime.Now)
                return cert;
        }

        var newCert = GenerateCertificate();
        File.WriteAllBytes("garage.cer", newCert.Export(X509ContentType.Cert));

        return newCert;
    }

    private record Amenity
    {
        public string name { get; set; } = "";
        public string description { get; set; } = "";

        public Guid? icon { get; set; }
        public int airline_id { get; set; }
    }
}