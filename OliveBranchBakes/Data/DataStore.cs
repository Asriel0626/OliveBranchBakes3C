using System.Text.Json;
using System.Text.Json.Serialization;
using OliveBranchBakes.Models;

namespace OliveBranchBakes.Data;

/// <summary>Reads and writes bakery records as JSON files.</summary>
public sealed class DataStore
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public string FolderPath { get; }

    public List<BakeryCategory> Categories { get; private set; } = new();
    public List<BakeryProduct> Products { get; private set; } = new();
    public List<Customer> Customers { get; private set; } = new();
    public List<BakeryOrder> Orders { get; private set; } = new();
    public BakerySettings Settings { get; private set; } = new();

    public DataStore(string? folderPath = null)
    {
        FolderPath = folderPath ?? Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "OliveBranchBakes",
            "Phase3A");

        Directory.CreateDirectory(FolderPath);
        Reload();
    }

    private string FileAt(string name) =>
        Path.Combine(FolderPath, name + ".json");

    private T? Read<T>(string filename)
    {
        string path = FileAt(filename);

        if (!File.Exists(path))
            return default;

        try
        {
            return JsonSerializer.Deserialize<T>(
                File.ReadAllText(path), JsonOptions)
                ?? throw new InvalidDataException(
                    $"{filename}.json is empty. " +
                    "Restore or remove it to regenerate demo data.");
        }
        catch (JsonException ex)
        {
            throw new InvalidDataException(
                $"Cannot read {filename}.json. " +
                $"The saved JSON is invalid: {ex.Message}", ex);
        }
    }

    private void Write<T>(string filename, T data)
    {
        string path = FileAt(filename);
        string temp = path + ".tmp";

        File.WriteAllText(
            temp,
            JsonSerializer.Serialize(data, JsonOptions));

        File.Move(temp, path, true);
    }

    public void Reload()
    {
        bool settingsMissing = !File.Exists(FileAt("settings"));

        Settings = Read<BakerySettings>("settings")
            ?? new BakerySettings();

        if (!VariantRules.IsValidDigits(Settings.VariantDigits))
        {
            throw new InvalidDataException(
                "settings.json needs a three-digit VariantDigits value.");
        }

        bool categoriesMissing = !File.Exists(FileAt("categories"));
        bool productsMissing = !File.Exists(FileAt("products"));
        bool customersMissing = !File.Exists(FileAt("customers"));
        bool ordersMissing = !File.Exists(FileAt("orders"));

        Categories = Read<List<BakeryCategory>>("categories")
            ?? SeedData.Categories();

        Products = Read<List<BakeryProduct>>("products")
            ?? SeedData.Products(Settings);

        Customers = Read<List<Customer>>("customers")
            ?? SeedData.Customers();

        Orders = Read<List<BakeryOrder>>("orders")
            ?? SeedData.Orders(Products, Customers, Settings.TaxRate);

        ValidateData();

        if (settingsMissing || categoriesMissing || productsMissing ||
            customersMissing || ordersMissing)
        {
            SaveAll();
        }
    }

    private void ValidateData()
    {
        if (Categories.Any(category =>
            string.IsNullOrWhiteSpace(category.Id) ||
            string.IsNullOrWhiteSpace(category.Name)))
        {
            throw new InvalidDataException(
                "A category in saved data has no name or ID.");
        }

        foreach (var product in Products)
            product.Validate();

        if (Products.Select(product => product.Id)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Count() != Products.Count)
        {
            throw new InvalidDataException(
                "Duplicate menu IDs were found in products.json.");
        }

        if (Customers.Select(customer => customer.Email)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Count() != Customers.Count)
        {
            throw new InvalidDataException(
                "Customer emails must be unique (case-insensitive).");
        }

        foreach (var order in Orders)
            order.Validate();
    }

    public void SaveAll()
    {
        ValidateData();

        Write("settings", Settings);
        Write("categories", Categories);
        Write("products", Products);
        Write("customers", Customers);
        Write("orders", Orders);
    }

    public void SaveCustomer(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);

        if (Customers.Any(existing =>
            string.Equals(
                existing.Id,
                customer.Id,
                StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException(
                "This customer ID already exists.");
        }

        if (Customers.Any(existing =>
            string.Equals(
                existing.Email,
                customer.Email,
                StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException(
                "An account already uses this email address. Please sign in.");
        }

        Customers.Add(customer);

        try
        {
            Write("customers", Customers);
        }
        catch
        {
            Customers.Remove(customer);
            throw;
        }
    }
    public void SaveOrder(BakeryOrder order)
    {
        ArgumentNullException.ThrowIfNull(order);
        order.Validate();

        if (Orders.Any(existing =>
            string.Equals(
                existing.ConfirmationNumber,
                order.ConfirmationNumber,
                StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException(
                "This confirmation number already exists. Please try again.");
        }

        Orders.Add(order);

        try
        {
            Write("orders", Orders);
        }
        catch
        {
            Orders.Remove(order);
            throw;
        }
    }

    public void SelectVariant(string lastThreeDigits)
    {
        if (!VariantRules.IsValidDigits(lastThreeDigits))
        {
            throw new ArgumentException(
                "Enter exactly the last three digits of the student ID.");
        }

        Settings.VariantDigits = lastThreeDigits;
        Settings.IsDemoVariant = false;

        Products.RemoveAll(item =>
            item.IsSeasonal &&
            item.Id.StartsWith("SEASON-", StringComparison.Ordinal));

        Products.Add(
            VariantRules.SeasonalProduct(lastThreeDigits[0]));

        SaveAll();
    }

    public BakeryOrder AddSampleOrder()
    {
        var bread = Products.Single(product => product.Id == "BR001");
        var muffin = Products.Single(product => product.Id == "MU001");

        DateTime placedAt = DateTime.Now;
        int next = 1;
        string prefix = $"OBB-{placedAt:yyMMdd}-";

        while (Orders.Any(order =>
            order.ConfirmationNumber == $"{prefix}{next:000}"))
        {
            next++;
        }

        DateTime pickup = DateTime.Today.AddDays(3).AddHours(10);

        while (
            (pickup.Month == 12 && pickup.Day == 25) ||
            (pickup.Month == 11 &&
             pickup.DayOfWeek == DayOfWeek.Thursday &&
             pickup.Day >= 22 &&
             pickup.Day <= 28))
        {
            pickup = pickup.AddDays(1);
        }

        BakeryOrder order = new(
            $"{prefix}{next:000}",
            null,
            "Sample Guest",
            "555-0199",
            placedAt,
            pickup,
            new[]
            {
                new OrderItem(bread, 2),
                new OrderItem(muffin, 1)
            });

        order.Tax = Math.Round(
            order.Subtotal * Settings.TaxRate,
            2,
            MidpointRounding.AwayFromZero);

        Orders.Add(order);
        Write("orders", Orders);

        return order;
    }
}