
namespace OliveBranchBakes.Models;
public sealed record PricingResult(
    decimal Subtotal,
    decimal Discount,
    decimal Fees,
    decimal Tax)
{
    public decimal Total =>
        Subtotal - Discount + Fees + Tax;
}
