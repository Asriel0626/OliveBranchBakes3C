# Phase 3A 3–5 minute video: exact presentation / screen actions

**Before recording:** Run Visual Studio on your Windows PC. The assigned seasonal item is Sweet potato pie, operations rule is O1 Pie capacity, and pricing rule is P5 Plan ahead. If you previously ran V4 on the same Windows account, verify the demo window shows these labels; if not, use SET VARIANT. Do not show your full student ID. Make your real GitHub commits and week1-3A release; do not claim an uncreated release.

## 0:00–0:30 — Introduction and Variant Card

**Show:** Welcome page and open `VIEW SAVED DATA`.

**Say:** “Hello, my name is EnYan Chen. Today is [recording date]. This is the Olive Branch Bakes ordering system, Phase 3A. My GitHub repository is [actual repository URL]. My Variant Card is Sweet potato pie, O1 Pie capacity, and P5 Plan ahead. This first checkpoint focuses on models and saving data, not the completed checkout.”

## 0:30–1:25 — Explain model classes and seed data

**Show:** Solution Explorer → Models → `BakeryProduct.cs`, `OrderItem.cs`, `BakeryOrder.cs`; the Menu and Customers tabs.

**Say:** “I continued my Phase 2 class structure instead of starting a new solution. BakeryProduct stores a unique ID, category, name, decimal price, and seasonal availability dates. OrderItem stores a copy of the item's price and calculates its line total from price times quantity. BakeryOrder contains an item list, contact and pickup information, and its order status. I prepared fifteen regular items plus my selected seasonal item, three sample customers, and eight sample orders.”

## 1:25–2:30 — Save, close, restart, reload

**Show:** First display `Data/DataStore.cs` (`Reload`, `Write`, `AddSampleOrder`) and explain the method sequence. Then switch to Orders tab → count eight on first run → `SAVE SAMPLE ORDER` → count increases to nine → `OPEN DATA FOLDER` → `orders.json` in a text editor → close the entire application → press F5 again → open demo → show record still exists → `RELOAD JSON`.

**Say:** “DataStore serializes the models into JSON files in the user's LocalAppData folder. Adding a demonstration record writes the updated orders list to orders.json. I will completely close and restart the application now. Notice that the ninth order is still present. This proves the file is saved to disk, rather than existing only in memory. Reload JSON also reads the saved records without resetting them.”

## 2:30–3:25 — Calculations prepared BEFORE implementation

**Show:** `Models/OrderItem.cs` and explain `UnitPrice`, `Quantity`, `LineTotal` directly in the code; then switch to `docs/TestTable.xlsx`, first test or the `T1 Hand Math` sheet.

**Say:** “Before implementing the full pricing service, I wrote expected values in a spreadsheet. In T1, two sourdough loaves are fifteen dollars, six chocolate chip cookies are thirteen dollars and fifty cents, and one apple pie is twenty-two dollars. The subtotal is fifty dollars and fifty cents. Because pickup is three days away, P5 gives no advance discount and does not charge a rush fee. Tax at eight point five percent is 4.2925 dollars, so the displayed total is fifty-four dollars and seventy-nine cents. T2 and T3 compare just below seven days versus exactly seven days; T6 and T7 test twelve pies versus thirteen pies across orders for the same pickup date.”

## 3:25–4:15 — Decisions, commits, limitations

**Show:** `docs/DesignDecisions.md`, `docs/DeveloperJournal.md`, `docs/ChangeLog.md`, Git Changes and your REAL commits.

**Say:** “I chose decimal instead of double because money needs precise arithmetic. I separated DataStore from the forms so future ordering screens can reuse the same data. I also save unit prices inside order items so future menu changes will not change old orders. My actual first-week commits are [describe each actual commit]. The cart, checkout, account sign-in and pricing enforcement are not complete in 3A; those belong to later checkpoints.”

## Final checklist

- Own voice, 3–5 minutes.
- At least two-thirds explaining actual classes/methods and showing code.
- Start with name, date, repository, and all Variant Card labels.
- Show save → CLOSE → REOPEN → data remains.
- Show calculation sheet and weekly REAL commit list.
- Submit **release URL**, **GitHub release source ZIP** and **video**.
