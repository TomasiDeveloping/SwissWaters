using System.Security.Cryptography;
using Core.Interfaces;

namespace Core.Helper;

public class ApiKeyService : IApiKeyService
{
    private const string Prefix = "SW-";
    private const int NumberOfSecureBytesToGenerate = 32;
    private const int LengthOfKey = 36;

    public string GenerateApiKey()
    {
        var bytes = RandomNumberGenerator.GetBytes(NumberOfSecureBytesToGenerate);

        return string.Concat(Prefix, Convert.ToBase64String(bytes)
            .Replace("/", "")
            .Replace("+", "")
            .Replace("=", "")
            .AsSpan(0, LengthOfKey - Prefix.Length));
    }
}