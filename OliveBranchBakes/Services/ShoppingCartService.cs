using OliveBranchBakes.Models;

namespace OliveBranchBakes.Services;

/// <summary>Holds the current shopping cart until checkout is implemented.</summary>
public sealed class ShoppingCartService
{
    public const int MaximumQuantityPerItem = 99;
    private readonly List<CartItem> _items = new();

    public event EventHandler? Changed;
    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();
    public int ItemCount => _items.Sum(item => item.Quantity);
    public decimal Subtotal => _items.Sum(item => item.LineTotal);
    public DateTime MenuDate { get; private set; } = DateTime.Today;

    public void Add(BakeryProduct product, int quantity = 1)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (!product.IsAvailableOn(MenuDate))
            throw new InvalidOperationException("This product is not available for the selected menu date.");
        if (quantity < 1 || quantity > MaximumQuantityPerItem)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Enter a quantity between 1 and 99.");

        CartItem? existing = _items.FirstOrDefault(item =>
            item.ProductId.Equals(product.Id, StringComparison.OrdinalIgnoreCase));
        if (existing is null)
            _items.Add(new CartItem(product, quantity));
        else
        {
            if (existing.Quantity > MaximumQuantityPerItem - quantity)
                throw new InvalidOperationException("This item has reached the maximum cart quantity of 99.");
            existing.Quantity += quantity;
        }
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void SetQuantity(string productId, int quantity)
    {
        CartItem line = Find(productId);
        if (quantity < 1 || quantity > MaximumQuantityPerItem)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Enter a whole number from 1 to 99, or remove the item.");
        if (line.Quantity == quantity) return;
        line.Quantity = quantity;
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void Remove(string productId)
    {
        CartItem line = Find(productId);
        _items.Remove(line);
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void Clear()
    {
        if (_items.Count == 0) return;
        _items.Clear();
        Changed?.Invoke(this, EventArgs.Empty);
    }

    // Update the preview date and remove any seasonal items no longer available.
    // The actual pickup-time and pie-capacity checks are part of Phase 3C.
    public int SelectMenuDate(DateTime date)
    {
        DateTime selected = date.Date;
        if (MenuDate == selected) return 0;
        MenuDate = selected;
        int removed = _items.RemoveAll(item => !item.Product.IsAvailableOn(selected));
        Changed?.Invoke(this, EventArgs.Empty);
        return removed;
    }

    public int SyncWithMenu(IEnumerable<BakeryProduct> products)
    {
        var available = new HashSet<string>(
            products.Where(product => product.IsAvailableOn(MenuDate)).Select(product => product.Id),
            StringComparer.OrdinalIgnoreCase);
        int removed = _items.RemoveAll(item => !available.Contains(item.ProductId));
        if (removed > 0) Changed?.Invoke(this, EventArgs.Empty);
        return removed;
    }

    private CartItem Find(string productId) =>
        _items.FirstOrDefault(item => item.ProductId.Equals(productId, StringComparison.OrdinalIgnoreCase))
        ?? throw new KeyNotFoundException("This item is no longer in the cart.");
}

public sealed class CartItem
{
    public BakeryProduct Product { get; }
    public string ProductId => Product.Id;
    public string ProductName => Product.Name;
    public decimal UnitPrice { get; }
    public int Quantity { get; internal set; }
    public decimal LineTotal => UnitPrice * Quantity;

    internal CartItem(BakeryProduct product, int quantity)
    {
        Product = product;
        UnitPrice = product.Price;
        Quantity = quantity;
    }
}
