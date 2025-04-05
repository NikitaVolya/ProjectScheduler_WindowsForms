using ProjectScheduler.DAL;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler
{
    public partial class TaskForm : Form
    {
        public SchedulerTask? Target { get; set; }
        public SchedulerProjectServise ProjectServise { get; set; }

        public bool ConfirmClick { get => _confirm_btn_click; }
        public string ConfirmButtonText { get => confirm_btn.Text; set => confirm_btn.Text = value; }

        private SchedulerProjectServise _project_servise;
        private bool _confirm_btn_click;

        public TaskForm()
        {
            InitializeComponent();
            _project_servise = new SchedulerProjectServise();
            _confirm_btn_click = false;
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            update_categories();

            if (Target == null)
            {
                MessageBox.Show("Error in load data", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (var member in Target.SchedulerProject.SchedulerMembers)
                owner_combobox.Items.Add(member.FirstName + " " + member.LastName);


            name_textbox.Text = Target.Name;
            description_textbox.Text = Target.Description;
            category_combobox.Text = Target?.SchedulerCategory?.Name;
            owner_combobox.Text = Target?.SchedulerOwner?.FirstName + " " + Target?.SchedulerOwner?.LastName;
            deadlineDateTimePicker.Value = Target.DeadLine;

            confirm_btn.Text = ConfirmButtonText;
        }

        private void update_categories()
        {
            category_combobox.Items.Clear();
            foreach (var category in Target.SchedulerProject.SchedulerCategories)
                category_combobox.Items.Add(category.Name);
            category_combobox.SelectedItem = null;
        }
        private void category_combobox_ValueMemberChanged(object sender, EventArgs e)
        {
            if (category_combobox.SelectedItem is null)
                return;
            SchedulerCategory category = Target.SchedulerProject.SchedulerCategories[category_combobox.SelectedIndex];
            Target.SchedulerCategory = category;
            color_panel.BackColor = Color.FromArgb(category.ColorRed, category.ColorGreen, category.ColorBlue);
        }
        private void add_category_btn_Click(object sender, EventArgs e)
        {
            CategoryForm window = new CategoryForm();
            window.Target = new SchedulerCategory
            {
                Name = "New Category",
                Description = "Description",
                ColorRed = 255,
                ColorGreen = 255,
                ColorBlue = 255
            };
            window.ShowDialog();
            if (!window.ConfirmClick)
                return;

            SchedulerCategory new_category = window.Target;
            _project_servise.AddProjectCategory(Target.SchedulerProject, new_category);
            update_categories();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty || category_combobox.Text == String.Empty ||
                owner_combobox.Text == String.Empty)
            {
                MessageBox.Show("All filds mast be full!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (deadlineDateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Deadline cancel message");
                return;
            }

            SchedulerMember? owner = Target.SchedulerProject.SchedulerMembers[owner_combobox.SelectedIndex];
            SchedulerCategory? category = Target.SchedulerProject.SchedulerCategories[category_combobox.SelectedIndex];
            if (owner is null || category is null)
            {
                MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }   

            Target.Name = name_textbox.Text;
            Target.Description = description_textbox.Text;
            Target.SchedulerOwner = owner;
            Target.SchedulerCategory = category;
            Target.DeadLine = deadlineDateTimePicker.Value;
            _confirm_btn_click = true;
            Close();
        }
    }
}
