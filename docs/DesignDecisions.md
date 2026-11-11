# Design Decision Record (3A — working draft)

**Student action required:** Review and rewrite entries in your own words, then add the actual date, GitHub commit link, and test evidence. Do not invent commits. The instructor requires >=3 entries for each week and >=12 total.

## 3A-01 — Use `decimal` for every amount

- Decision: `Models/BakeryProduct.cs` (`Price`) and `Models/OrderItem.cs` (`UnitPrice`, `LineTotal`) use `decimal`.
- How: line totals multiply the original per-item price by the whole-number quantity. The order's subtotal adds all lines. No `float` or `double` is used for currency.
- Why: bakery prices and tax calculations must avoid floating-point representation errors.
- Alternative considered: `double` is familiar for scientific calculations, but inappropriate for accounting precision.
- Source/AI disclosure: Phase 3 assignment p.3; code drafted with AI assistance; inspect and explain before submission.
- Check: T1 calculation sheet; order-snapshot test in Orders JSON.
- Commit link: **add actual GitHub link after your commit**.

## 3A-02 — Keep data access in `DataStore`, not form event handlers

- Decision: `Data/DataStore.cs` implements `Reload()`, `SaveAll()` and `AddSampleOrder()`; `Forms/SavedDataForm.cs` calls these methods.
- How: the demo form displays the returned objects; the service writes JSON to a stable LocalAppData folder.
- Why: presentation and persistent storage are separate, allowing 3B/3C features to reuse the same data classes.
- Alternative considered: write JSON directly inside a button handler; rejected because it mixes responsibilities and is harder to test.
- Source/AI disclosure: Phase 3 assignment pp.4–5; AI-assisted code draft.
- Check: Persistence-01 close/reopen, Persistence-02 reload button.
- Commit link: **add actual GitHub link after your commit**.

## 3A-03 — Copy menu price into each order item

- Decision: `Models/OrderItem.cs` constructor snapshots `ProductId`, `ProductName`, and `UnitPrice`; `Models/BakeryOrder.cs` totals saved lines.
- How: an existing order does not recalculate unit prices by looking up the current catalog.
- Why: later menu price changes must not alter earlier customer orders.
- Alternative considered: store only the product ID and dynamically query today's price; rejected because old order totals could change.
- Source/AI disclosure: Phase 3 assignment p.3; AI-assisted code draft.
- Check: Snapshot-01 change menu price, reopen order JSON and compare saved order UnitPrice.
- Commit link: **add actual GitHub link after your commit**.

## Additional decisions to discuss in 3B–3D

- Seasonal dates in menu JSON, including seasons crossing January (`BakeryProduct.IsAvailableOn`).
- Passwords are salted PBKDF2 SHA-256 hashes (`Customer.SetPassword`).
- Confirmation codes use `OBB-YYMMDD-###` for sample orders (`DataStore.AddSampleOrder`).
- Required pricing is delegated to `PricingService` (planned for 3C).
- Required operations checks go in `SchedulingService` (planned for 3C).
- Form-level input validation and service-level checks are separated (planned for 3B/3C).

**Do not claim completed 3C features during 3A.**
