
using ShedulerObjects;
using System.Text;
using System;
using static System.Windows.Forms.DataFormats;
using System.Diagnostics;
using System.IO;

namespace Project
{
    public partial class MainMenuForm : Form
    {
        private struct ProjectListElement
        {
            public string ProjectPath, ProjectName;
        }
        private List<ProjectListElement> _projects;

        public MainMenuForm()
        {
            InitializeComponent();
            _projects = new List<ProjectListElement>();
        }

        public void AddProject(string path)
        {
            string? project_name = XMLSchedulerParser.ProjectNameParse(path);
            if (project_name is null)
            {
                MessageBox.Show("Error in load project : " + path, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _projects.Add(new ProjectListElement { ProjectPath = path, ProjectName = project_name });
            DisplayRecentProject();
        }

        public void DisplayRecentProject()
        {
            recent_project_listbox.Items.Clear();
            foreach (var element in _projects)
                recent_project_listbox.Items.Add(element.ProjectName);
        }

        private void load_file()
        {
            _projects.Clear();
            recent_project_listbox.Items.Clear();
            string[] data = File.ReadAllLines("recent_projects.txt");
            foreach (string item in data)
                AddProject(item);
            save_to_file();
        }

        private void save_to_file()
        {
            string data = String.Empty;
            foreach (ProjectListElement item in _projects)
                data += item.ProjectPath + "\n";
            File.WriteAllText("recent_projects.txt", data);
        }

        private void add_project_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                AddProject(file);
                save_to_file();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Text = "Project sheduler main menu";
            load_file();
        }

        private void remove_project_btn_Click(object sender, EventArgs e)
        {
            if (recent_project_listbox.SelectedItem is null)
                return;
            _projects.RemoveAt(recent_project_listbox.SelectedIndex);
            DisplayRecentProject();
            save_to_file();
        }

        private void recent_project_listbox_DoubleClick(object sender, EventArgs e)
        {
            if (recent_project_listbox.SelectedItem is null)
                return;


            WorkForm workForm = new WorkForm();

            workForm.ProjectPath = _projects[recent_project_listbox.SelectedIndex].ProjectPath;
            workForm.MenuWindow = this;

            workForm.Show();
            Hide();
            load_file();
        }

        private void create_project_btn_Click(object sender, EventArgs e)
        {
            ProjectForm window = new ProjectForm();
            window.MainMenuWindow = this;

            window.Show();
            Hide();
        }

        private void copyPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (recent_project_listbox.SelectedItem is null)
                return;
            ProjectListElement element = _projects[recent_project_listbox.SelectedIndex];
            var obj = new System.Windows.Forms.DataObject(DataFormats.Text, element.ProjectPath);
            Clipboard.SetDataObject(obj, true);
        }

        private void showInExploerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (recent_project_listbox.SelectedItem is null)
                return;
            ProjectListElement element = _projects[recent_project_listbox.SelectedIndex];
            string? path = string.Join("\\", element.ProjectPath.Split("\\").SkipLast(1));
            if (path is null)
                return;
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = path,
                UseShellExecute = true,
                Verb = "open",
            });
        }

        private void delete_project_btn_Click(object sender, EventArgs e)
        {
            if (recent_project_listbox.SelectedItem is null)
                return;

            ProjectListElement element = _projects[recent_project_listbox.SelectedIndex];
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the project {element.ProjectName} ?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;
            File.Delete(element.ProjectPath);
            remove_project_btn_Click(sender, e);
        }
    }
}
