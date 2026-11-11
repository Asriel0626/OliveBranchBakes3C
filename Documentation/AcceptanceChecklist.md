# Phase 2 Acceptance Checklist

- [x] Named Visual Studio folders (Forms, Models, Services, Assets, Navigation).
- [x] Six planned forms represented in navigation diagram and C# form files.
- [x] Customer ordering prototype with sample catalog, category picker, empty basket and pickup preview.
- [x] Cottage bakery palette consistently assigned through standard WinForms Designer properties.
- [x] Basic accessibility: readable type, label text, explicit TabIndex for key controls, large buttons, scrollable content window.
- [x] Domain model and services contain documented stubs without implementation logic.
- [x] Phase 1 project metadata preserved, original form files backed up.
- [x] README and English video narration guide included.
- [ ] **Run and test in Visual Studio on Windows** — cannot be verified in this Linux sandbox.
- [ ] **Record screen demonstration** — must be completed on Windows by student.

## Windows test path
1. Open `OliveBranchBakes.sln` in Visual Studio 2022 with the .NET Desktop Development workload.
2. In Solution Explorer, set `OliveBranchBakes` as Startup Project if required.
3. Press F5; Welcome must appear.
4. Test Welcome → ORDER → SUMMARY → ACCOUNT → ORDER → WELCOME.
5. Test WELCOME → STAFF → PREVIEW ADMIN CONSOLE → BACK TO STAFF LOGIN.
6. Click **ADD +**, **SIGN IN (PREVIEW)** and **PLACE ORDER (PREVIEW)** to verify notices and the absence of business operations.
7. Resize window down to minimum; check whether vertical scrolling reaches all controls; press Tab through customer input controls.
8. Close the form; the application should exit normally.
