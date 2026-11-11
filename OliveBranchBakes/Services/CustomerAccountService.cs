using System.Net.Mail;
using OliveBranchBakes.Data;
using OliveBranchBakes.Models;

namespace OliveBranchBakes.Services;

public sealed class CustomerAccountService
{
    private readonly DataStore _store;
    private string? _currentCustomerId;

    public Customer? CurrentCustomer =>
        _currentCustomerId is null
            ? null
            : _store.Customers.FirstOrDefault(customer =>
                customer.Id == _currentCustomerId);

    public CustomerAccountService(DataStore store)
    {
        _store = store ??
            throw new ArgumentNullException(nameof(store));
    }

    public Customer CreateAccount(
        string name,
        string email,
        string phone,
        string password)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            name.Trim().Length > 100)
        {
            throw new ArgumentException(
                "Enter your full name using 100 characters or fewer.");
        }

        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Enter your phone number.");

        string cleanPhone = phone.Trim();
        int phoneDigits = cleanPhone.Count(char.IsAsciiDigit);

        if (phoneDigits < 7 || phoneDigits > 15 ||
            cleanPhone.Any(character =>
                !char.IsAsciiDigit(character) &&
                !" +-().".Contains(character)))
        {
            throw new ArgumentException(
                "Enter a phone number with 7 to 15 digits.");
        }

        string normalizedEmail = NormalizeEmail(email);

        if (_store.Customers.Any(customer =>
            string.Equals(
                customer.Email,
                normalizedEmail,
                StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException(
                "An account already uses this email address. Please sign in.");
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException(
                "Password needs at least eight characters and a number.");
        }

        var customer = new Customer(
            "C-" + Guid.NewGuid().ToString("N"),
            name.Trim(),
            normalizedEmail,
            cleanPhone,
            password);

        _store.SaveCustomer(customer);
        _currentCustomerId = customer.Id;

        return customer;
    }

    public Customer SignIn(string email, string password)
    {
        string normalizedEmail = NormalizeEmail(email);

        var customer = _store.Customers.FirstOrDefault(customer =>
            string.Equals(
                customer.Email,
                normalizedEmail,
                StringComparison.OrdinalIgnoreCase));

        if (customer is null || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException(
                "The email address or password is incorrect.");
        }

        bool passwordMatches;

        try
        {
            passwordMatches = customer.VerifyPassword(password);
        }
        catch (FormatException ex)
        {
            throw new InvalidDataException(
                "The saved password information could not be read.", ex);
        }

        if (!passwordMatches)
        {
            throw new ArgumentException(
                "The email address or password is incorrect.");
        }

        _currentCustomerId = customer.Id;

        return customer;
    }

    public void SignOut()
    {
        _currentCustomerId = null;
    }

    public IReadOnlyList<BakeryOrder> GetOrderHistory()
    {
        Customer? customer = CurrentCustomer;

        if (customer is null)
            return Array.Empty<BakeryOrder>();

        return _store.Orders
            .Where(order => order.CustomerId == customer.Id)
            .OrderByDescending(order => order.PlacedAt)
            .ToList();
    }

    private static string NormalizeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Enter your email address.");

        string normalized = email.Trim().ToLowerInvariant();

        if (!MailAddress.TryCreate(normalized, out var address) ||
            !address.Address.Equals(
                normalized,
                StringComparison.OrdinalIgnoreCase) ||
            !address.Host.Contains('.'))
        {
            throw new ArgumentException(
                "Enter a valid email address, such as name@example.com.");
        }

        return normalized;
    }
}