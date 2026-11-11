namespace OliveBranchBakes.Models;

/// <summary>Persistent bakery menu entry; the season dates belong to the menu data, not to a form.</summary>
public sealed class BakeryProduct
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string CategoryId { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsSeasonal { get; set; }
    public int? SeasonStartMonth { get; set; }
    public int? SeasonStartDay { get; set; }
    public int? SeasonEndMonth { get; set; }
    public int? SeasonEndDay { get; set; }

    public BakeryProduct() { }

    public BakeryProduct(string id, string name, string categoryId, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(categoryId))
            throw new ArgumentException("Product ID, name and category are required.");
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        Id = id.Trim(); Name = name.Trim(); CategoryId = categoryId.Trim();
        Description = description.Trim(); Price = price;
    }

    public bool IsAvailableOn(DateTime date)
    {
        if (!IsActive) return false;
        if (!IsSeasonal) return true;
        if (SeasonStartMonth is null || SeasonStartDay is null || SeasonEndMonth is null || SeasonEndDay is null)
            return false;
        int today = date.Month * 100 + date.Day;
        int first = SeasonStartMonth.Value * 100 + SeasonStartDay.Value;
        int last = SeasonEndMonth.Value * 100 + SeasonEndDay.Value;
        return first <= last ? today >= first && today <= last : today >= first || today <= last;
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(CategoryId))
            throw new InvalidDataException("A saved menu item has missing information.");
        if (Price < 0) throw new InvalidDataException("A saved menu item has a negative price.");
        if (IsSeasonal && (SeasonStartMonth is null || SeasonStartDay is null || SeasonEndMonth is null || SeasonEndDay is null))
            throw new InvalidDataException("A seasonal menu item needs its availability dates.");
    }
}
