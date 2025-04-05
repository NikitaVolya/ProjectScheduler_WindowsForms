
using ProjectScheduler.DAL;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler
{
    public partial class ProjectPropertiesForm : Form
    {
        public SchedulerProject? Target { get; set; }
        public SchedulerProjectServise ProjectServise;

        private SchedulerMember? SelectedMember { get => Target?.SchedulerMembers.ElementAtOrDefault(members_listbox.SelectedIndex); }
        private SchedulerCategory? SelectedCategory { get => Target?.SchedulerCategories.ElementAtOrDefault(categories_listbox.SelectedIndex); }


        public ProjectPropertiesForm()
        {
            InitializeComponent();
        }

        private void ProjectProperties_Load(object sender, EventArgs e)
        {
            if (Target == null)
            {
                MessageBox.Show("Project not found!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            name_textbox.Text = Target.Name;
            description_textbox.Text = Target.Description;

            UpdateMembersList();
            UpdateCategoriesList();
        }

        private void UpdateMembersList()
        {
            members_listbox.Items.Clear();
            foreach (SchedulerMember member in ProjectServise.GetProjectMembersByProjectId(Target.Id))
                members_listbox.Items.Add($"{member.FirstName} {member.LastName}");
        }
        private void members_listbox_DoubleClick(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem is null)
                return;

            MemberForm window = new MemberForm();
            window.Target = SelectedMember;
            window.ConfirmButtonText = "Save";
            window.ShowDialog();

            bool confirm_click = window.ConfirmClick;
            window.Dispose();

            if (!confirm_click)
                return;

            ProjectServise.UpdateProject(Target);
            UpdateMembersList();
        }
        private void add_member_btn_Click(object sender, EventArgs e)
        {
            MemberForm create_member_window = new MemberForm();
            create_member_window.Target = new SchedulerMember
            {
                FirstName = "New member",
                LastName = "Surname",
                Description = "Description"
            };
            create_member_window.ShowDialog();

            if (!create_member_window.ConfirmClick)
                return;
            SchedulerMember new_member = create_member_window.Target;
            create_member_window.Dispose();

            ProjectServise.AddProjectMember(Target, new_member);
            UpdateMembersList();
        }
        private void delete_member_btn_Click(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem is null)
                return;

            SchedulerMember selected_member = SelectedMember;

            if (ProjectServise.ExisteTaskWithOwnerId(selected_member.Id))
            {
                DialogResult result = MessageBox.Show("If you delete this project member, all tasks associated with him will be deleted. Do you want to do this?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            ProjectServise.RemoveProjectMember(selected_member.Id);
            UpdateMembersList();
        }


        private void UpdateCategoriesList()
        {
            categories_listbox.Items.Clear();
            foreach (SchedulerCategory category in Target.SchedulerCategories)
                categories_listbox.Items.Add(category.Name);
        }
        private void categories_listbox_DoubleClick(object sender, EventArgs e)
        {
            if (categories_listbox.SelectedItem is null)
                return;

            CategoryForm window = new CategoryForm();
            window.Target = SelectedCategory;
            window.ConfirmButtonText = "Save";
            window.ShowDialog();

            if (!window.ConfirmClick)
                return;

            ProjectServise.UpdateProject(Target);

            UpdateMembersList();
        }
        private void add_category_btn_Click(object sender, EventArgs e)
        {
            CategoryForm create_category_window = new CategoryForm();
            create_category_window.Target = new SchedulerCategory
            {
                Name = "New category",
                Description = "Description"
            };
            create_category_window.ShowDialog();

            if (!create_category_window.ConfirmClick)
                return;

            ProjectServise.AddProjectCategory(Target, create_category_window.Target);
            UpdateCategoriesList();
        }

        private void delete_category_btn_Click(object sender, EventArgs e)
        {
            if (categories_listbox.SelectedItem is null)
                return;

            SchedulerCategory selected_category = SelectedCategory;
            if (ProjectServise.GetProjectTasksByCategoryId(selected_category.Id).Count() != 0)
            {
                DialogResult result = MessageBox.Show("If you delete this project category, all tasks associated with him will be deleted. Do you want to do this?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            ProjectServise.RemoveProjectCategory(selected_category);
            UpdateCategoriesList();
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            Target.Name = name_textbox.Text;
            Target.Description = description_textbox.Text;

            ProjectServise.UpdateProject(Target);
        }
    }
}
