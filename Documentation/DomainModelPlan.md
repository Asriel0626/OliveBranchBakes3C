# Candidate Domain Model — Phase 2 Stubs

No instructor-approved class diagram was provided in the attached Phase 1 Visual Studio ZIP. The following **proposed** classes are therefore intentionally empty, pending review against approved requirements:

- `Customer`: future customer account/contact data
- `BakeryProduct`: menu entry, category, display price, availability
- `BakeryOrder`: a customer's order with status and pickup details
- `OrderItem`: individual ordered bakery product and quantity
- `PickupWindow`: available pickup interval and capacity
- `Administrator`: staff identity/authorization
- `OrderStatus` enum: candidate order lifecycle state vocabulary (not connected to screens)

Service boundaries (all empty): `CatalogService`, `OrderService`, `CustomerAccountService`, `AdministratorService`, `PickupService`.

Relationship sketch for later phases: `Customer` 1 → many `BakeryOrder`; `BakeryOrder` 1 → many `OrderItem`; `OrderItem` many → 1 `BakeryProduct`; `BakeryOrder` → 1 `PickupWindow` (proposed only).

**Phase 2 does not implement any persistence, business rules, or account/password operations.**
