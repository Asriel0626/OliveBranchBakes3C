using OliveBranchBakes.Data;
using OliveBranchBakes.Models;

namespace OliveBranchBakes.Services;

/// <summary>Returns menu items by category and availability date.</summary>
public sealed class CatalogService
{
    private readonly DataStore _data;
    public CatalogService(DataStore data) => _data = data;
    public IReadOnlyList<BakeryCategory> Categories() => _data.Categories.AsReadOnly();
    public IReadOnlyList<BakeryProduct> AvailableOn(DateTime onDate, string? categoryId = null) =>
        _data.Products.Where(p => p.IsAvailableOn(onDate) &&
            (categoryId is null || p.CategoryId.Equals(categoryId, StringComparison.OrdinalIgnoreCase)))
            .OrderBy(p => p.Name).ToList();
}
