using ProjectScheduler.DAL;
using ProjectScheduler.DAL.Entities;
using ProjectScheduler.SchedulerObjects;

namespace ProjectScheduler
{
    public partial class WorkForm : Form
    {
        public SchedulerProject? Target { get; set; }
        public MainMenuForm MenuWindow { get; set; }

        private SchedulerProjectServise _project_servise;
        private SchedulerTask? _current_task;

        public WorkForm()
        {
            InitializeComponent();

            _project_servise = new SchedulerProjectServise();
            _current_task = null;
        }
        private void WorkForm_Load(object sender, EventArgs e)
        {
            if (Target == null)
            {
                MessageBox.Show("Project not found!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            Text = "Project sheduler | " + Target.Name;
            DisplaySchedulerTasks();
        }
        private void WorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuWindow.DisplayRecentProject();
            MenuWindow.Show();
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
                var panel_task = _project_servise.GetProjectTasksByStatus(Target, i).ToList();
                foreach (SchedulerTask task in panel_task)
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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void propertysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectPropertiesForm window = new ProjectPropertiesForm();
            window.Target = Target;
            window.ProjectServise = _project_servise;
            window.ShowDialog();
            window.Dispose();
            DisplaySchedulerTasks();
        }

        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskForm window = new TaskForm();

            window.Target = new SchedulerTask
            {
                Name = "New task",
                Description = "Description",
                DeadLine = DateTime.Now,
                SchedulerProject = Target,
            };
            window.ProjectServise = _project_servise;
            window.ShowDialog();
            if (!window.ConfirmClick)
                return;

            SchedulerTask new_task = window.Target;
            window.Dispose();
            _project_servise.AddProjectTask(Target, new_task);
            DisplaySchedulerTasks();
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm window = new CategoryForm();
            window.Target = new SchedulerCategory
            {
                Name = "New category",
                Description = "Description",
                SchedulerProject = Target
            };
            window.ShowDialog();

            if (!window.ConfirmClick)
                return;
            SchedulerCategory new_category = window.Target;
            window.Dispose();
            _project_servise.AddProjectCategory(Target, new_category);
        }


        private SchedulerTask? GetTaskByPanel(Panel panel)
        {
            int task_id = (int)((NumericUpDown)panel.Controls[0]).Value;
            return _project_servise.GetProjectTaskById(task_id);
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

            SchedulerStatus new_status = 0;
            if (x > 560)
                new_status = SchedulerStatus.Done;
            else if (x > 300)
                new_status = SchedulerStatus.InProgress;
            else
                new_status = SchedulerStatus.Planned;

            SchedulerTask task = GetTaskByPanel((Panel)sender);
            if (task is null)
                return;
            if (task.Status == new_status)
                return;

            task.Status = new_status;
            _project_servise.UpdateProjectTask(task);
            DisplaySchedulerTasks();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_current_task is null)
                return;

            TaskForm window = new TaskForm();
            _current_task.SchedulerProject = Target;
            window.Target = _current_task;
            window.ProjectServise = _project_servise;
            window.ShowDialog();
            window.Dispose();
            DisplaySchedulerTasks();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_current_task is null)
                return;

            DialogResult result = MessageBox.Show("Do you want to delete the task?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                _project_servise.RemoveProjectTask(Target, _current_task);
            DisplaySchedulerTasks();
        }
    }
}
