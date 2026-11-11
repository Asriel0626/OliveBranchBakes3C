# Olive Branch Bakes — Phase 2 Navigation Diagram

```mermaid
flowchart TD
    W[Welcome Form] -->|Explore the menu| O[Customer Ordering Form]
    W -->|My account| A[Customer Account Form]
    W -->|Staff| L[Administrator Login Form]
    O -->|Review planned order| S[Order Summary Form]
    O <-->|My account / continue browsing| A
    A -->|Order summary| S
    S -->|Back to menu| O
    S -->|Customer account| A
    L -->|Preview console; no authentication| C[Administrator Console]
    C -->|Back to staff login| L
    O -->|Header navigation| W
    A -->|Header navigation| W
    S -->|Header navigation| W
    L -->|Header navigation| W
    C -->|Header navigation| W
```

**Actual Phase 2 behavior:** every arrow above is a UI navigation action. The five main pages are accessible using the shared top navigation. The admin console is deliberately reached via the **Preview Admin Console** button on the admin login page. The top **STAFF** item returns to admin login.

**Not implemented:** sign-in, accounts, cart persistence, pricing math, payment, inventory, database, or real order administration.
