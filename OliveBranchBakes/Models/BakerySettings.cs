namespace OliveBranchBakes.Models;

/// <summary>Stores bakery settings and the selected rule labels.</summary>
public sealed class BakerySettings
{
    // Default selection for this bakery variant.
    public string VariantDigits { get; set; } = "319";
    public bool IsDemoVariant { get; set; } = false;
    public decimal TaxRate { get; set; } = 0.085m;
    public int PlanAheadDays { get; set; } = 7;
    public decimal PlanAheadItemDiscount { get; set; } = 0.50m;
    public int RushFeeThresholdHours { get; set; } = 48;
    public decimal RushFeeAmount { get; set; } = 5.00m;
    public int DailyPieLimit { get; set; } = 12;

    public int MinimumAdvanceHours { get; set; } = 24;
    public int MaximumAdvanceDays { get; set; } = 30;
    public string SeasonalItemLabel => VariantRules.SeasonalName(VariantDigits[0]);
    public string OperationsLabel => VariantRules.OperationsLabel(VariantDigits[1]);
    public string PricingLabel => VariantRules.PricingLabel(VariantDigits[2]);
}
