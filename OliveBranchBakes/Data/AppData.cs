using OliveBranchBakes.Services;

namespace OliveBranchBakes.Data;

/// <summary>Provides access to shared application data and services.</summary>
public static class AppData
{
    public static DataStore Store { get; private set; } = null!;
    public static ShoppingCartService Cart { get; private set; } = null!;
    public static IPricingService Pricing { get; private set; } = null!;
    public static SchedulingService Scheduling { get; private set; } = null!;
    public static CustomerAccountService Accounts { get; private set; } = null!;

    public static void Initialize()
    {
        Store = new DataStore();
        Cart = new ShoppingCartService();

        Pricing = new PlanAheadPricingService(Store.Settings);
        Scheduling = new PickupService(Store.Settings);
        Accounts = new CustomerAccountService(Store);
    }
}