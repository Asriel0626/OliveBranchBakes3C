# Interface Design — Phase 2

Palette: cream `#FBF7ED`, olive `#4F623E`, dark olive `#37492C`, warm brown `#694B36`, honey gold `#DFB451`, restrained seasonal terracotta `#A6684F`, soft sage `#E8EEDB`.

Font: Segoe UI throughout, 9–27 pt hierarchy. Interactive buttons use a minimum of 43 px height and major actions 50–59 px. Text fields are 37–40 px, aligned with associated labels. Customer navigation provides five consistent header destinations and an admin console through the staff preview page. TabIndex is assigned sequentially (header first, then form fields and buttons). 

The prototype has 6 actual WinForms forms, each a conventional partial designer-editable Form. Anchored header navigation, scrollable body, and a minimum window size support conventional Windows monitors and tablets, with landscape tablet use recommended at 100% scaling.

Phase 2 nonfunctional scope: no real orders, payment, auth, inventory, database, or session persistence.
