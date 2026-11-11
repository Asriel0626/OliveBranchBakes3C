# Designer compatibility fix

The first version generated WinForms via `UI/BakeryFormBase` and C# constructors. That structure prevented Visual Studio Designer from loading derived forms properly.

**Corrected:** Every screen is now a standalone `Form` partial class, with one code-behind file and one generated-designer-style `*.Designer.cs` file. Each Designer file contains `InitializeComponent`, field declarations, standard Windows Forms components, event hookups, and Dispose. Project XML explicitly records the Designer dependency. No custom Form base class remains.

Navigation still uses the application context; the prototype has no real ordering/login logic. All sample visual assets reside in Assets and are loaded only if present to avoid errors in the designer.
