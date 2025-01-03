using System.Diagnostics;
using System.Globalization;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Core.Features.Identity;
using Charcillaries.Core.Features.Images;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Core.Features.TourOperator;
using Charcillaries.Data.DatabaseSpecific;
using Charcillaries.Web;
using FluentValidation;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Minio;
using Npgsql;
using SD.LLBLGen.Pro.DQE.PostgreSql;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SK.Framework;
using SK.Framework.Email;
using SoloX.BlazorJsonLocalization;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddTransient<DataAccessAdapter>();
services.AddTransient<EmailServerData>();
services.Configure<EmailServerData>(builder.Configuration.GetSection("EmailServer"));
services.AddTransient<IEmailServer, EmailServer>();
services.AddTransient<IPassengerRepository, PassengerManagementRepository>();
services.AddTransient<IAirlineRepository, AirlineManagementRepository>();
services.AddTransient<ITourOperatorRepository, TourOperatorManagementRepository>();
services.AddTransient<IFlightRepository, FlightManagementRepository>();
services.AddTransient<IIdentityRepository, IdentityRepository>();
services.AddTransient<IImageService, ImageService>();

services.AddValidatorsFromAssemblyContaining<PassengerNewInput.Validator>();
services.Configure<MvcOptions>(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

services.AddAuthentication()
    .AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/logout";

            options.ExpireTimeSpan = TimeSpan.FromHours(8);
            options.SlidingExpiration = true;
        }
    );
services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireRole("Admin"))
    .AddPolicy("passenger", policy => policy.RequireRole("Passenger"))
    .AddPolicy("airline", policy => policy.RequireRole("Airline"))
    .AddPolicy("tourOperator", policy => policy.RequireRole("Tour Operator"));

services.AddJsonLocalization(optionsBuilder =>
        optionsBuilder
            .UseEmbeddedJson(options =>
            {
                options.ResourcesPath = "Resources";
                options.Assemblies = new[]
                    { typeof(Global).Assembly, typeof(AirlineLocalization).Assembly, Assembly.GetExecutingAssembly() };
            })
            .AddFallback("Global", typeof(Global).Assembly)
            .AddFallback("AirlineLocalization", typeof(AirlineLocalization).Assembly)
            .EnableLogger()
    , ServiceLifetime.Singleton
);
ConfigureCulture(services);

services.AddMinio(configureClient => configureClient
    .WithEndpoint("garage.incubator-infra.demoday.us")
    .WithRegion("garage")
    .WithCredentials("GKefe8dc8fd3fcd715dd3df07e", "8e85e2c9daa48f9f9805aa164ac0384133a21d7d765f966c67fa128789dacc0f")
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
    }))
    .Build()
);

var razor = services.AddRazorPages(options =>
{
    options.Conventions.Add(new PageRouteTransformerConvention(new SlugifyParameterTransformer()));
    options.Conventions.AuthorizeFolder("/Admin", "Admin");
    options.Conventions.AuthorizeFolder("/Passenger", "passenger");
    options.Conventions.AuthorizeFolder("/Airline", "airline");
    options.Conventions.AuthorizeFolder("/TourOperator", "tourOperator");
});

// Add services to the container.
if (builder.Environment.IsDevelopment())
    razor.AddRazorRuntimeCompilation();

RuntimeConfiguration.AddConnectionString("ConnectionString.PostgreSql (Npgsql)",
    builder.Configuration.GetConnectionString(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                                              "Development"));

services.AddTransient<BaseUrl>(_ =>
{
    var baseUrl =
        builder.Configuration.GetSection("BaseUrl")[
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"]!;
    return new BaseUrl(baseUrl);
});

RuntimeConfiguration.ConfigureDQE<PostgreSqlDQEConfiguration>(
    c => c.SetTraceLevel(TraceLevel.Verbose)
        .AddDbProviderFactory(typeof(NpgsqlFactory)));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.UseStaticFiles();
app.MapRazorPages();

app.UseRequestLocalization();

AjaxEndpoints.Map(app);
app.Run();
return;


void ConfigureCulture(IServiceCollection serviceCollection)
{
    var english = new CultureInfo("en")
    {
        DateTimeFormat =
        {
            ShortDatePattern = "dd-MM-yyyy",
            ShortTimePattern = "HH:mm tt",
            LongTimePattern = "HH:mm tt"
        }
    };

    var arabic = new CultureInfo("ar", true)
    {
        DateTimeFormat =
        {
            ShortDatePattern = "dd/MM/yyyy",
            ShortTimePattern = "hh:mm tt",
            LongTimePattern = "hh:mm tt"
        }
    };

    var supportedCultures = new[]
    {
        english,
        arabic
    };

    serviceCollection.Configure<RequestLocalizationOptions>(options =>
    {
        options.DefaultRequestCulture = new RequestCulture(supportedCultures[1]); // english 0, arabic 1
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;

        options.RequestCultureProviders.Add(new CookieRequestCultureProvider());
    });
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

public record BaseUrl(string Url);