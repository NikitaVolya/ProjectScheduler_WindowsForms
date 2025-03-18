using Project;
using ShedulerObjects;

namespace ProjectScheduler
{
    public partial class ProjectPropertiesForm : Form
    {
        public string FilePath { get; set; }
        public SchedulerProject SchedulerProjectObject { get; set; }

        public ProjectPropertiesForm()
        {
            InitializeComponent();
        }

        private void ProjectProperties_Load(object sender, EventArgs e)
        {
            name_textbox.Text = SchedulerProjectObject.Name;
            description_textbox.Text = SchedulerProjectObject.Description;

            DispalayMembers();
            DisplayCategories();
        }

        private void DispalayMembers()
        {
            members_listbox.Items.Clear();

            foreach (SchedulerMember member in SchedulerProjectObject.ProjectMembers)
                members_listbox.Items.Add($"{member.Name} {member.Surname}");
        }

        private void DisplayCategories()
        {
            categories_listbox.Items.Clear();
            foreach (SchedulerCategory category in SchedulerProjectObject.ProjectCategories)
                categories_listbox.Items.Add(category.Name);
        }
        private void add_member_btn_Click(object sender, EventArgs e)
        {
            MemberForm window = new MemberForm();
            window.ShowDialog();

            if (!window.ConfirmClick)
                return;

            SchedulerProjectObject.ProjectMembers.Add(window.SchedulerMemberObject);
            DispalayMembers();
        }

        private void delete_member_btn_Click(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem is null)
                return;

            SchedulerMember selected_member = SchedulerProjectObject.ProjectMembers[members_listbox.SelectedIndex];

            if (!(SchedulerProjectObject.Tasks.Find(x => !(x.TaskOwner is null) && x.TaskOwner == selected_member) is null))
            {
                DialogResult result = MessageBox.Show("If you delete this project member, all tasks associated with him will be deleted. Do you want to do this?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            SchedulerProjectObject.Tasks.RemoveAll(x => !(x.TaskOwner is null) && x.TaskOwner == selected_member);
            SchedulerProjectObject.ProjectMembers.Remove(selected_member);
            DispalayMembers();
        }

        private void members_listbox_DoubleClick(object sender, EventArgs e)
        {
            SchedulerMember selected_member = SchedulerProjectObject.ProjectMembers[members_listbox.SelectedIndex];
            MemberForm window = new MemberForm();
            window.SchedulerMemberObject = selected_member;
            window.ConfirmButtonText = "Save";
            window.ShowDialog();
            DispalayMembers();
        }

        private void add_category_btn_Click(object sender, EventArgs e)
        {
            CategoryForm window = new CategoryForm();
            window.ShowDialog();

            if (!window.ConfirmClick)
                return;
            SchedulerProjectObject.ProjectCategories.Add(window.SchedulerCategoryObject);
            DisplayCategories();
        }

        private void delete_category_btn_Click(object sender, EventArgs e)
        {
            if (categories_listbox.SelectedItem is null)
                return;

            SchedulerCategory selected_category = SchedulerProjectObject.ProjectCategories[categories_listbox.SelectedIndex];
            if (!(SchedulerProjectObject.Tasks.Find(x => !(x.TaskCategory is null) && x.TaskCategory == selected_category) is null))
            {
                DialogResult result = MessageBox.Show("If you delete this project category, all tasks associated with him will be deleted. Do you want to do this?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            SchedulerProjectObject.Tasks.RemoveAll(x => !(x.TaskCategory is null) && x.TaskCategory == selected_category);
            SchedulerProjectObject.ProjectCategories.Remove(selected_category);
            DisplayCategories();
        }

        private void categories_listbox_DoubleClick(object sender, EventArgs e)
        {
            SchedulerCategory selected_member = SchedulerProjectObject.ProjectCategories[categories_listbox.SelectedIndex];
            CategoryForm window = new CategoryForm();
            window.SchedulerCategoryObject = selected_member;
            window.ConfirmButtonText = "Save";
            window.ShowDialog();
            DispalayMembers();
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            SchedulerProjectObject.Name = name_textbox.Text;
            SchedulerProjectObject.Description = description_textbox.Text;
        }
    }
}
