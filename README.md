# Olive Branch Bakes — Phase 3B

Windows Forms ordering prototype built with C# and .NET 8. This version extends the Phase 3A data foundation with a working, session-based shopping cart and category/seasonal menu browsing.

## Running the project

Open `OliveBranchBakes.sln` in Visual Studio 2022 with the **.NET desktop development** workload and .NET 8 installed. Select **Build > Rebuild Solution** and then press **F5**. The title bar displays `Phase 3B`.

From **WELCOME**, open **ORDER**. Choose a category or change the **MENU DATE** to preview seasonal availability. Click **ADD +** to put a product in the basket; use **+**, **-**, **REMOVE**, and **CLEAR** to change the cart. The subtotal updates immediately. Click **SUMMARY** to see the same cart in the single main window; return to ORDER to edit it.

**Saved Data** remains available from the Welcome page. The original 3A local JSON data directory is retained, so existing sample orders survive an app restart.

## Assignment scope

- **3B:** category browsing, seasonal visibility, cart add/edit/remove, live subtotal, and a consistent summary preview.
- **3C (not yet built):** final order placement, account sign-in, P5 discounts/rush fees, O1 daily pie capacity checks, pickup scheduling, taxes and confirmation.
- The cart is held in memory for the current running session. It is **not** a saved customer order; the 3A Saved Data window shows separate sample orders.
- Menu date controls **catalog visibility**, not a confirmed pickup reservation.
- The selected student variant remains `319`: Sweet Potato Pie ($21, Nov 1–Dec 31), O1 pie capacity, P5 plan-ahead pricing. The O1/P5 business rules remain scheduled for 3C.

## Tests

With .NET 8 installed, run in a Windows terminal from the project root:

```powershell
dotnet run --project Tests/Phase3ADataTests.csproj
dotnet run --project Tests/Phase3BCartTests.csproj
```

Also complete the UI checks in `docs/3B_TestChecklist.md`. Run the cart tests **without editing or deleting** your original 3A JSON data.

## Project notes

`OliveBranchBakes/Services/ShoppingCartService.cs` owns quantity validation and subtotal calculations. `Forms/CustomerOrderForm.cs` renders the cart; `Forms/OrderSummaryForm.cs` reads the same shared cart from `Data/AppData.cs`. This keeps business logic out of form event handlers.

GitHub release for the second checkpoint should be tagged `week2-3B`. Add your actual dated decisions, work journal entries, tests, and Git commits before submitting; do not invent Git history or completed test results. Disclose substantial AI assistance in the journal as required by the assignment.
