namespace OliveBranchBakes
{
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
        }

        private void buttonProjectinformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
              "Project Name: OliveBranchBakes\n\n" +
              "Student Name: EnYan Chen\n\n" +
              "Current Phase: Phase 1 - Customer Requirements and Scope\n\n" +
              "Class Name and Number: Object-Oriented Programming CS3388\n\n" +
              "Date: September 28, 2026\n\n" +
              "Project Description: A simple Windows Forms project for helping Olive Branch Bakes deal with their orders from all the guests.",
              "Project Information"
          );
        }
    }
}
