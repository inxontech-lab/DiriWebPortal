using System.Security.Cryptography;

namespace DiriAPI.Services.Security;

public class PasswordHashingService
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 100_000;
    private const string Prefix = "PBKDF2";

    public string HashPassword(string password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var key = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);

        return $"{Prefix}${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(key)}";
    }

    public bool VerifyPassword(string password, string? storedValue)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(storedValue))
        {
            return false;
        }

        var parts = storedValue.Split('$', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 4 &&
            string.Equals(parts[0], Prefix, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(parts[1], out var iterations))
        {
            try
            {
                var salt = Convert.FromBase64String(parts[2]);
                var storedKey = Convert.FromBase64String(parts[3]);
                var attemptedKey = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, storedKey.Length);
                return CryptographicOperations.FixedTimeEquals(attemptedKey, storedKey);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        return string.Equals(password, storedValue, StringComparison.Ordinal);
    }

    public bool NeedsRehash(string? storedValue)
    {
        if (string.IsNullOrWhiteSpace(storedValue))
        {
            return true;
        }

        return !storedValue.StartsWith($"{Prefix}$", StringComparison.OrdinalIgnoreCase);
    }
}
