# Checkpoint 3B — 3–5 minute demonstration

Use your own voice. Show the source code for at least two-thirds of the recording, as the assignment requests. Replace the placeholders with your actual recording date and repository URL.

**0:00–0:15 | Introduction — show WELCOME and ORDER**

> Hello, my name is EnYan Chen. Today is [date]. This is the `week2-3B` version of my Olive Branch Bakes project. My variant is Sweet Potato Pie, O1 Pie Capacity, and P5 Plan Ahead. In 3B, I implemented category browsing and a working shopping cart.

**0:15–1:50 | Explain ShoppingCartService.cs (code)**

> The ShoppingCartService holds the current cart. The Add method checks the item and quantity. If the product is already in the cart, it increases the quantity instead of creating another line. SetQuantity and Remove update the cart. The Subtotal property sums the line totals using decimal values.

Open `ShoppingCartService.cs` and point to `Add`, `SetQuantity`, `Remove`, and `Subtotal`. Explain one new method line by line, especially how `Add` prevents duplicates.

**1:50–3:10 | Explain catalog, seasonal and form logic (code)**

> CatalogService filters the saved menu by category and date. The sweet potato pie is only available from November first through December thirty-first. In the ORDER form, changing the menu date refreshes the visible products. The form displays the results, while the service handles cart rules.

Open `CatalogService.cs`, `BakeryProduct.cs` (`IsAvailableOn`) and `CustomerOrderForm.cs` (`RenderFilteredProducts`).

**3:10–3:45 | Live cart demo**

> Here I select Breads and add two sourdough loaves. The cart shows fifteen dollars. Next, I add chocolate chip cookies, change a quantity, and remove a product. The running subtotal updates right away. When I open SUMMARY, I can still see my current cart, because both pages share the same cart service.

Demonstrate Breads → ADD + twice; Cookies → ADD +; +/- and REMOVE; SUMMARY → ORDER. Show running subtotal.

**3:45–4:10 | Seasonal demo and code**

> I will change the menu date. On October thirty-first, the seasonal sweet potato pie is not available. On November first, it appears. These seasonal dates are stored in the product model. The full pickup rules and checkout will be completed in Phase 3C.

Briefly show the `IsAvailableOn()` method in code, then change MENU DATE between 10/31/2026 and 11/01/2026 and choose Seasonal. This keeps the majority of the recording focused on code explanation.

**4:10–4:30 | GitHub and close**

> These are my Week 2 commits and release. The cart, category filtering and live subtotal are completed in this phase. The final pricing, account and order confirmation features will be added later. Thank you for watching.

Show actual GitHub commits and the `week2-3B` release. Do not claim untested functionality or invent commits.
