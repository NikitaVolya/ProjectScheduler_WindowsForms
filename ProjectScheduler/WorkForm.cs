using System.Windows.Forms;
using System.Xml.Linq;
using ProjectScheduler;
using ShedulerObjects;

namespace Project
{
    public partial class WorkForm : Form
    {
        private SchedulerProject _scheduler_project;
        private SchedulerTask? _current_task;
        private bool _project_saving;

        public string ProjectPath { get; set; }
        public MainMenuForm MenuWindow { get; set; }

        public WorkForm()
        {
            InitializeComponent();
            _current_task = null;
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            if (ProjectPath is null)
            {
                MessageBox.Show("Project not found!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            _scheduler_project = XMLSchedulerParser.ProjectParse(ProjectPath);
            _project_saving = true;

            if (_scheduler_project is null)
            {
                Close();
                return;
            }

            Text = "Project sheduler | " + _scheduler_project.Name;
            DisplaySchedulerTasks();
        }

        private void DisplaySchedulerTasks()
        {
            progress_panel.Controls.Clear();
            planned_panel.Controls.Clear();
            done_panel.Controls.Clear();
            Panel[] panels = { planned_panel, progress_panel, done_panel };

            for (int i = 0; i < 3; i++)
            {
                int j = 20;
                foreach (SchedulerTask task in _scheduler_project.Tasks.FindAll(x => (int)x.Status == i))
                {
                    Panel task_panel = TaskSchedulerPanel.CreatePanel(task, this);
                    task_panel.Location = new Point(15, j);

                    task_panel.MouseDown += task_panel_MouseDown;
                    task_panel.MouseUp += task_panel_MouseUp;
                    task_panel.ContextMenuStrip = task_context_menu;

                    foreach (Control control in task_panel.Controls)
                    {
                        control.MouseDown += (obj, e) => task_panel_MouseDown(task_panel, e);
                        control.MouseUp += (obj, e) => task_panel_MouseUp(task_panel, e);
                    }
                    panels[i].Controls.Add(task_panel);
                    j += 220;
                }
            }

        }

        private void WorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_project_saving)
            {
                DialogResult result = MessageBox.Show("Do you want to save project?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
            }
            MenuWindow.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void propertysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectPropertiesForm window = new ProjectPropertiesForm();
            window.FilePath = ProjectPath;
            window.SchedulerProjectObject = _scheduler_project;
            window.ShowDialog();
            _project_saving = false;
            DisplaySchedulerTasks();
        }

        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskForm window = new TaskForm();

            window.SchedulerProjectObject = _scheduler_project;
            window.ShowDialog();
            if (!window.ConfirmClick)
                return;

            _scheduler_project.Tasks.Add(window.SchedulerTaskObject);
            _project_saving = false;
            DisplaySchedulerTasks();
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm window = new CategoryForm();
            window.ProjectObject = _scheduler_project;
            window.SchedulerCategoryObject = new SchedulerCategory("New category", "", Color.White);
            window.ShowDialog();

            if (!window.ConfirmClick)
                return;

            _scheduler_project.ProjectCategories.Add(window.SchedulerCategoryObject);
            _project_saving = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XMLSchedulerWriter.SaveToXML(_scheduler_project, ProjectPath);
            _project_saving = true;
        }

        private SchedulerTask? GetTaskByPanel(Panel panel)
        {
            int task_id = (int)((NumericUpDown)panel.Controls[0]).Value;
            return _scheduler_project.Tasks.Find(x => x.Id == task_id);
        }

        private void task_panel_MouseDown(object sender, MouseEventArgs e)
        {
            _current_task = GetTaskByPanel((Panel)sender);
        }


        private void task_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_current_task is null)
                return;

            int x = Cursor.Position.X - Location.X;

            SchedulerTaskStatus new_status = 0;
            if (x > 725)
                new_status = SchedulerTaskStatus.Done;
            else if (x > 375)
                new_status = SchedulerTaskStatus.InProgress;
            else
                new_status = SchedulerTaskStatus.Planned;

            SchedulerTask task = GetTaskByPanel((Panel)sender);
            if (task is null)
                return;
            if (task.Status == new_status)
                return;

            task.Status = new_status;
            _scheduler_project.Tasks.Remove(task);
            _scheduler_project.Tasks.Add(task);
            _project_saving = true;
            _current_task = null;
            _project_saving = false;
            DisplaySchedulerTasks();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_current_task is null)
                return;

            DialogResult result = MessageBox.Show("Do you want to delete the task?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                _scheduler_project.Tasks.Remove(_current_task);
            DisplaySchedulerTasks();
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_current_task is null)
                return;

            TaskForm window = new TaskForm();

            window.SchedulerProjectObject = _scheduler_project;
            window.SchedulerTaskObject = _current_task;

            window.ShowDialog();
            _project_saving = true;
            DisplaySchedulerTasks();
        }
    }
}
