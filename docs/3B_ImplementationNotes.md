# Phase 3B implementation decisions — review before your journal

- **Shared cart service**: `Services/ShoppingCartService.cs` keeps one cart for ORDER and SUMMARY. Forms show results; they do not calculate totals or apply limits themselves. The cart is session-only until 3C introduces order placement.
- **Duplicate lines**: `ShoppingCartService.Add()` merges equal product IDs. The service validates whole-number quantities and limits a single cart line to 99 units for usability; the assigned O1 daily pie limit is not enforced here because 3C will validate an actual pickup date across saved orders.
- **Money**: `CartItem.UnitPrice` is a decimal snapshot when the item is added; `LineTotal` and `Subtotal` use decimal, with dollar formatting only when shown.
- **Seasonal browsing**: `CatalogService.AvailableOn()` and `BakeryProduct.IsAvailableOn()` use the selected menu date. The preview menu date does not reserve pickup time. The cart removes seasonal products that become invalid when the date changes.
- **Navigating pages**: `Data/AppData.cs` holds one `ShoppingCartService`, while `Navigation/BakeryMainForm.cs` continues to host pages within a single top-level window.
- **Compatibility**: saved Phase 3A data and JSON order records were not migrated or deleted. The cart is separate from the saved sample-order demonstration.

Before submitting, write your own dated explanation in `DesignDecisions.md` and `DeveloperJournal.md`, include your actual test results and commit links, and disclose substantial AI assistance as required. These notes do not replace your own account of the work.
