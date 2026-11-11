using OliveBranchBakes.Models;

namespace OliveBranchBakes.Services;

public abstract class SchedulingService
{
    protected BakerySettings Settings { get; }

    protected SchedulingService(BakerySettings settings)
    {
        Settings = settings ??
            throw new ArgumentNullException(nameof(settings));
    }

    public abstract void Validate(
        IReadOnlyCollection<OrderItem> items,
        IReadOnlyCollection<BakeryProduct> products,
        IReadOnlyCollection<BakeryOrder> orders,
        DateTime placedAt,
        DateTime pickupAt);

    public abstract int GetRemainingPies(
        IReadOnlyCollection<BakeryOrder> orders,
        IReadOnlyCollection<BakeryProduct> products,
        DateTime pickupAt);
}
