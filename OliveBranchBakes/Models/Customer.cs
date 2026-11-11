using System.Security.Cryptography;

namespace OliveBranchBakes.Models;

/// <summary>Customer identity. Only a salt and password hash are persisted.</summary>
public sealed class Customer
{
    public string Id { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string PasswordSalt { get; set; } = "";
    public string PasswordHash { get; set; } = "";

    public Customer() { }

    public Customer(string id, string name, string email, string phone, string password)
    {
        Id = id;
        FullName = name.Trim(); Email = email.Trim().ToLowerInvariant(); Phone = phone.Trim();
        if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(FullName) ||
            !Email.Contains('@') || string.IsNullOrWhiteSpace(Phone))
            throw new ArgumentException("Provide a name, valid email address and phone number.");
        SetPassword(password);
    }

    public void SetPassword(string password)
    {
        if (password.Length < 8 || !password.Any(char.IsDigit))
            throw new ArgumentException("Password needs at least eight characters and a number.");
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100_000, HashAlgorithmName.SHA256, 32);
        PasswordSalt = Convert.ToBase64String(salt);
        PasswordHash = Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(PasswordSalt) || string.IsNullOrWhiteSpace(PasswordHash)) return false;
        byte[] result = Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromBase64String(PasswordSalt),
            100_000, HashAlgorithmName.SHA256, 32);
        return CryptographicOperations.FixedTimeEquals(result, Convert.FromBase64String(PasswordHash));
    }
}
