# Bakery Variant Card — assigned selection

**Student-specific item and rule labels (without revealing the full student ID)**

| Category | Assigned label | Required behavior |
| --- | --- | --- |
| Seasonal item | **Sweet potato pie 9 inch** | **$21.00**; available **Nov 1–Dec 31** only; store season dates in menu data |
| Operations | **O1 — Pie capacity** | At most **12 pies total across all orders** for a pickup date; reject the 13th pie and display remaining availability |
| Pricing | **P5 — Plan ahead** | Place order **at least 7 days** before pickup: take **$0.50 off each pie and cake**. Place order **less than 48 hours** before pickup: add **$5.00 rush fee** |

## Core calculation order

1. Subtotal = sum(quantity × unit price). Use `decimal`.
2. Discount = $0.50 × eligible pie/cake units when `pickup - order >= 168 hours`.
3. Rush fee = $5.00 when `pickup - order < 48 hours`; at exactly 48h, fee is $0.
4. Taxable amount = subtotal − discount + fee.
5. Tax = taxable amount × **8.5%**; total = taxable amount + unrounded tax. Round only displayed/saved totals to 2 digits.
6. All orders must also meet general pickup rules: at least 24 hours ahead, within 30 days, no Thanksgiving or December 25.
7. O1 uses **date-wide existing pie count + new cart pie count**; equality to 12 is allowed; greater than 12 is blocked.

## Phase 3A implementation boundary

- 3A has **stored rule labels**, **seeded seasonal menu item**, **precalculated test expectations** and **JSON persistence**.
- **P5 discount and O1 validation are not yet enforced by checkout code**. They are planned for 3C.
- The existing `SAVE SAMPLE ORDER` is a data persistence demonstration, **not** a validated customer order.
- The test cases in `TestTable.xlsx` are preimplementation expectations; `Actual status` remains unfilled until the working service is implemented and tested.

### Existing saved data note

On a **new machine / first app run**, settings initialize to the assigned seasonal item/O1/P5 automatically. If an earlier V4 app was already opened on the same Windows account, its `settings.json` persists in `%LOCALAPPDATA%\OliveBranchBakes\Phase3A`, regardless of which ZIP you open. To update **without deleting existing orders**, use Welcome → **VIEW SAVED DATA** → enter **only the last three digits** → **SET VARIANT**; verify Sweet potato pie, O1 and P5.
