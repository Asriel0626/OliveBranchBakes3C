# Checkpoint 3B — Manual UI tests

Record the **actual result** and **Pass/Fail** after running the application in Visual Studio. The table below contains **expected results**, not claims that tests have already passed.

| Test | Steps | Expected result | Actual result | Pass/Fail |
| --- | --- | --- | --- | --- |
| B1 | Open ORDER, choose Breads | Only bread products appear | | |
| B2 | Choose Cookies, then All baked goods | Cookies only; then all available products | | |
| B3 | Set MENU DATE to 10/31/2026 and filter Seasonal | No 319 sweet potato pie | | |
| B4 | Set MENU DATE to 11/01/2026 and filter Seasonal | Sweet potato pie appears at $21.00 | | |
| B5 | Click ADD + for one sourdough loaf | Basket contains one line, $7.50 subtotal | | |
| B6 | Add the same sourdough again | One line with quantity 2; subtotal $15.00 | | |
| B7 | Add three chocolate chip cookies | Subtotal $21.75 ($15.00 + $6.75) | | |
| B8 | Click minus for a cookie | Quantity 2; subtotal $19.50 | | |
| B9 | Click REMOVE on the sourdough row | Bread removed; subtotal $4.50 | | |
| B10 | Click SUMMARY then ORDER | Same cart/subtotal shown on both screens | | |
| B11 | Click CLEAR | Cart empty; subtotal $0.00 | | |
| B12 | Add seasonal pie on 11/01/2026, then change MENU DATE to 10/31/2026 | The pie disappears from the cart with an explanatory message | | |
| B13 | Add item until maximum 99; try to add one more | Extra quantity rejected; no duplicate line or subtotal change | | |
| B14 | Maximize and restore window on ORDER | Catalog and basket remain usable, controls visible and scrollable | | |

**Note:** Product examples assume the original seed prices. If your saved `products.json` differs, verify and record actual current prices before testing. The shopping cart is an in-memory 3B feature; it is not expected to survive a restart or create an order confirmation. Full O1 capacity and P5 pricing are for 3C.

## Automated tests

Run `dotnet run --project Tests/Phase3BCartTests.csproj` to test add, merge, set quantity, remove, clear, upper/lower bounds, seasonal boundaries and price snapshots. Use `dotnet run --project Tests/Phase3ADataTests.csproj` to check that JSON persistence still works.
