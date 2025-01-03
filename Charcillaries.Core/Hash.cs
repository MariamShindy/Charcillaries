using Sqids;
using System.Security.Cryptography;

namespace Charcillaries.Core;

public static class RandomCode
{
    static readonly Random _rnd = new();

    public static string Generate()
    {
        var number = _rnd.Next(0, int.MaxValue);

        return Hash.EncodeInt(number);
    }
}

public static class Hash
{
    static readonly SqidsEncoder<int> _hashInt = new(new SqidsOptions { MinLength = 6 });

    static readonly SqidsEncoder<long> _hashLong = new(new SqidsOptions { MinLength = 6 });

    static readonly SimpleAES _aes = new();

    public static string DecodeString(string hash)
        => _aes.DecryptString(hash);

    public static int DecodeToInt(string hash)
        => _hashInt.Decode(hash)[0];

    public static long DecodeToLong(string hash)
        => _hashLong.Decode(hash)[0];

    public static short DecodeToShort(string hash)
        => Convert.ToInt16(_hashInt.Decode(hash)[0]);

    public static string EncodeString(string str)
        => _aes.EncryptToString(str);

    public static string EncodeInt(int number)
        => _hashInt.Encode(number);

    public static string EncodeLong(long number)
        => _hashLong.Encode(number);

    public static string EncodeShort(short number)
        => _hashInt.Encode(number);
}

// ReSharper disable once InconsistentNaming
public class SimpleAES
{
    // Change this key per project at https://www.random.org/cgi-bin/randbyte?nbytes=32&format=d
    readonly byte[] _key =
    [
        49, 63, 18, 63, 255, 75, 132, 182, 186, 40, 175, 51, 13, 11, 145, 24,
        26, 168, 10, 124, 191, 163, 204, 65, 62, 22, 78, 135, 243, 133, 202, 199
    ];

    // Change this key per project https://www.random.org/cgi-bin/randbyte?nbytes=16&format=d
    readonly byte[] _vector = [85, 236, 110, 81, 221, 189, 63, 232, 33, 122, 60, 244, 214, 164, 34, 54];

    public SimpleAES()
    {
    }

    /// <summary>
    /// ----------- The commonly used methods ------------------------------
    /// Encrypt some text and return a string suitable for passing in a URL.
    /// </summary>
    public string EncryptToString(string textValue)
    {
        return ByteArrToString(Encrypt(textValue));
    }

    /// <summary>
    /// Encrypt some text and return an encrypted byte array.
    /// </summary>
    public byte[] Encrypt(string plainText)
    {
        ArgumentNullException.ThrowIfNull(plainText);

        // Create an Aes object
        // with the specified key and IV.
        using var aesAlg = Aes.Create();
        aesAlg.Key = _key;
        aesAlg.IV = _vector;

        // Create an encryptor to perform the stream transform.
        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for encryption.
        using MemoryStream msEncrypt = new();
        using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (StreamWriter swEncrypt = new(csEncrypt))
        {
            //Write all data to the stream.
            swEncrypt.Write(plainText);
        }

        var encrypted = msEncrypt.ToArray();

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    /// <summary>
    /// The other side: Decryption methods
    /// </summary>
    public string DecryptString(string encryptedString)
    {
        return Decrypt(StrToByteArray(encryptedString));
    }

    /// <summary>
    /// Decryption when working with byte arrays.
    /// </summary>
    public string Decrypt(byte[] cipherText)
    {
        if (cipherText is not { Length: > 0 })
            throw new ArgumentNullException(nameof(cipherText));

        // Declare the string used to hold
        // the decrypted text.

        // Create an Aes object
        // with the specified key and IV.
        using var aesAlg = Aes.Create();
        aesAlg.Key = _key;
        aesAlg.IV = _vector;

        // Create a decryptor to perform the stream transform.
        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for decryption.
        using MemoryStream msDecrypt = new(cipherText);
        using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csDecrypt);

        // Read the decrypted bytes from the decrypting stream
        // and place them in a string.
        var plaintext = srDecrypt.ReadToEnd();

        return plaintext;
    }

    /// <summary>
    /// Convert a string to a byte array.  NOTE: Normally we'd create a Byte Array from a string using an ASCII encoding (like so).
    ///      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    ///      return encoding.GetBytes(str);
    /// However, this results in character values that cannot be passed in a URL.  So, instead, I just
    /// lay out all of the byte values in a long string of numbers (three per - must pad numbers less than 100).
    ///</summary>
    public static byte[] StrToByteArray(string str)
    {
        if (str.Length == 0)
            throw new Exception("Invalid string value in StrToByteArray");

        var byteArr = new byte[str.Length / 3];
        var i = 0;
        var j = 0;
        do
        {
            var val = byte.Parse(str.Substring(i, 3));
            byteArr[j++] = val;
            i += 3;
        } while (i < str.Length);

        return byteArr;
    }

    /// <summary>
    /// Same comment as above.  Normally the conversion would use an ASCII encoding in the other direction:
    ///      System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
    ///      return enc.GetString(byteArr);
    /// </summary>
    public static string ByteArrToString(byte[] byteArr)
    {
        var tempStr = "";
        for (var i = 0; i <= byteArr.GetUpperBound(0); i++)
        {
            var val = byteArr[i];
            tempStr += val switch
            {
                < 10 => "00" + val,
                < 100 => "0" + val,
                _ => val.ToString()
            };
        }

        return tempStr;
    }
}