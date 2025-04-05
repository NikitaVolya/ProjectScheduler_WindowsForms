using ProjectScheduler.DAL;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler
{
    public partial class MainMenuForm : Form
    {
        private SchedulerProjectServise _project_servise;

        private SchedulerProject? SelectedProject
        {
            get {
                if (recent_project_listbox.SelectedItem == null)
                    return null;
                return _project_servise.GetAllProjects().ElementAtOrDefault(recent_project_listbox.SelectedIndex);
            }
        }

        public MainMenuForm()
        {
            InitializeComponent();
            Text = "Project sheduler main menu";

            _project_servise = new SchedulerProjectServise();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            DisplayRecentProject();
        }

        public void DisplayRecentProject()
        {
            recent_project_listbox.Items.Clear();
            foreach (var element in _project_servise.GetAllProjects())
                recent_project_listbox.Items.Add(element.Name);
        }

        private void recent_project_listbox_DoubleClick(object sender, EventArgs e)
        {
            WorkForm work_form = new WorkForm();

            SchedulerProject? project = SelectedProject;
            if (project == null)
            {
                MessageBox.Show("Error in load data", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            work_form.Target = project;
            work_form.MenuWindow = this;

            Hide();
            work_form.ShowDialog();
            work_form.Dispose();
        }

        private void create_project_btn_Click(object sender, EventArgs e)
        {
            ProjectForm window = new ProjectForm();
            window.Target = new SchedulerProject
            {
                Name = "New Project",
                Description = "Description",
                SchedulerMembers = new List<SchedulerMember>()
            };
            window.MainMenuWindow = this;
            window.Hide();
            window.ShowDialog();
            if (!window.ConfirmClick)
                return;

            _project_servise.AddProject(window.Target);
            DisplayRecentProject();
        }
        private void remove_project_btn_Click(object sender, EventArgs e)
        {
            _project_servise.RemoveProject(SelectedProject);
            DisplayRecentProject();
        }

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchedulerProject? project = SelectedProject;
            if (project == null)
                return;

            var obj = new DataObject(DataFormats.Text, project.Name);
            Clipboard.SetDataObject(obj, true);
        }
    }
}
