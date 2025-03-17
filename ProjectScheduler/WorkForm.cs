using System.Windows.Forms;
using System.Xml.Linq;
using ProjectScheduler;
using ShedulerObjects;

namespace Project
{
    public partial class WorkForm : Form
    {
        private SchedulerProject _scheduler_project;
        private bool _holding_task;
        private SchedulerTask? _current_task;
        private bool _project_changing;

        public string ProjectPath { get; set; }
        public MainMenuForm MenuWindow { get; set; }

        public WorkForm()
        {
            InitializeComponent();
            _holding_task = false;
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

            if (_scheduler_project is null)
            {
                Application.Exit();
                return;
            }

            Text = "Project sheduler | " + _scheduler_project.Name;
            _project_changing = false;
            DiscplaySchedulerTasks();
        }

        private void DiscplaySchedulerTasks()
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
            MenuWindow.Show();
            if (_project_changing)
            {
                DialogResult result = MessageBox.Show("Do you want to save project?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void propertysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectPropertiesForm window = new ProjectPropertiesForm();
            window.FilePath = ProjectPath;
            window.SchedulerProjectObject = _scheduler_project;
            window.ShowDialog();

            DiscplaySchedulerTasks();
        }

        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskForm window = new TaskForm();

            int task_number = _scheduler_project.Tasks.Count;
            window.ProjectObject = _scheduler_project;
            window.ShowDialog();

            if (task_number != _scheduler_project.Tasks.Count)
                _project_changing = true;
            DiscplaySchedulerTasks();
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm window = new CategoryForm();
            window.ProjectObject = _scheduler_project;

            int category_number = _scheduler_project.ProjectCategories.Count;

            window.ShowDialog();
            if (category_number != _scheduler_project.ProjectCategories.Count)
                _project_changing = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => XMLSchedulerWriter.SaveToXML(_scheduler_project, ProjectPath);

        private SchedulerTask GetTaskByPanel(Panel panel)
        {
            Panel body = (Panel)panel;
            string title = ((Label)body.Controls[1]).Text;
            return _scheduler_project.Tasks.Find(x => x.Name == title);
        }

        private void task_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _holding_task = true;

            _current_task = GetTaskByPanel((Panel)sender);
        }


        private void task_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_holding_task)
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
            _holding_task = false;
            _project_changing = true;
            DiscplaySchedulerTasks();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_current_task is null)
                return;

            DialogResult result = MessageBox.Show("Do you want to delete the task?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                _scheduler_project.Tasks.Remove(_current_task);
            DiscplaySchedulerTasks();
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskForm window = new TaskForm();
            window.ProjectObject = _scheduler_project;
            window.TaskToUpdate = _current_task;
            window.ShowDialog();
            _project_changing = true;
            DiscplaySchedulerTasks();
        }
    }
}
