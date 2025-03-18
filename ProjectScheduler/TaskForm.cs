using ShedulerObjects;

namespace Project
{
    public partial class TaskForm : Form
    {
        public SchedulerProject SchedulerProjectObject { get; set; }
        public SchedulerTask SchedulerTaskObject { get; set; }
        public string ConfirmButtonText { get => confirm_btn.Text; set => confirm_btn.Text = value; }

        private bool _confirm_btn_click;
        public bool ConfirmClick { get => _confirm_btn_click; }

        public TaskForm()
        {
            InitializeComponent();
            _confirm_btn_click = false;
            SchedulerTaskObject = new SchedulerTask("New task", "", SchedulerTaskStatus.Planned, DateTime.Now);
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            update_categories();

            foreach (var member in SchedulerProjectObject.ProjectMembers)
                owner_combobox.Items.Add(member.FullName);

            if (SchedulerTaskObject is null)
                throw new Exception("Task From error");

            name_textbox.Text = SchedulerTaskObject.Name;
            description_textbox.Text = SchedulerTaskObject.Description;
            category_combobox.Text = SchedulerTaskObject.TaskOwnerFullName;
            owner_combobox.Text = SchedulerTaskObject.TaskOwnerFullName;
            deadlineDateTimePicker.Value = SchedulerTaskObject.Deadline;

            confirm_btn.Text = ConfirmButtonText;
        }

        private void update_categories()
        {
            category_combobox.Items.Clear();
            foreach (var category in SchedulerProjectObject.ProjectCategories)
                category_combobox.Items.Add(category.Name);
            category_combobox.SelectedIndex = SchedulerProjectObject.ProjectCategories.IndexOf(SchedulerTaskObject.TaskCategory);
        }

        private void add_category_btn_Click(object sender, EventArgs e)
        {
            CategoryForm window = new CategoryForm();
            window.ProjectObject = SchedulerProjectObject;
            window.ShowDialog();
            if (!window.ConfirmClick)
                return;
            SchedulerProjectObject.ProjectCategories.Add(window.SchedulerCategoryObject);
            SchedulerTaskObject.TaskCategory = window.SchedulerCategoryObject;
            update_categories();
        }

        private void category_combobox_ValueMemberChanged(object sender, EventArgs e)
        {
            if (category_combobox.SelectedItem is null)
                return;
            SchedulerCategory category = SchedulerProjectObject.ProjectCategories[category_combobox.SelectedIndex];
            color_panel.BackColor = category.CategoryColor;
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

            SchedulerMember? owner = SchedulerProjectObject.ProjectMembers.Find(x => x.FullName == owner_combobox.Text);
            SchedulerCategory? category = SchedulerProjectObject.ProjectCategories.Find(x => x.Name == category_combobox.Text);
            if (owner is null || category is null)
            {
                MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }   


            SchedulerTaskObject.Name = name_textbox.Text;
            SchedulerTaskObject.Description = description_textbox.Text;
            SchedulerTaskObject.TaskOwner = owner;
            SchedulerTaskObject.TaskCategory = category;
            SchedulerTaskObject.Deadline = deadlineDateTimePicker.Value;
            _confirm_btn_click = true;
            Close();
        }
    }
}
