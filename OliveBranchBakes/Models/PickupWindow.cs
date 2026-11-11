namespace OliveBranchBakes.Models;

/// <summary>Reusable slot data model; availability rules are a Phase 3C service task.</summary>
public sealed class PickupWindow
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Capacity { get; set; }
    public int ReservedOrders { get; set; }

    public PickupWindow() { }
    public PickupWindow(DateTime start, DateTime end, int capacity)
    {
        if (end <= start || capacity < 1)
            throw new ArgumentException("A pickup slot needs a valid interval and capacity.");
        Start = start; End = end; Capacity = capacity;
    }
    public bool HasSpace => ReservedOrders < Capacity;
}
