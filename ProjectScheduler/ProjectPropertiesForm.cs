using Project;
using ShedulerObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private SchedulerMember? GetSelectedMember()
        {
            string? selected_member_fullname = members_listbox.SelectedItem?.ToString();

            return SchedulerProjectObject.ProjectMembers.Find(member => member.FullName == selected_member_fullname);
        }

        private void delete_member_btn_Click(object sender, EventArgs e)
        {


            SchedulerMember? selected_member = GetSelectedMember();

            if (selected_member is null)
                return;

            if (!(SchedulerProjectObject.Tasks.Find(x => x.TaskOwner == selected_member) is null))
            {
                DialogResult result = MessageBox.Show("If you delete this project member, all tasks associated with him will be deleted. Do you want to do this?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            SchedulerProjectObject.Tasks.RemoveAll(x => x.TaskOwner == selected_member);
            SchedulerProjectObject.ProjectMembers.Remove(selected_member);
            DispalayMembers();
        }

        private void add_member_btn_Click(object sender, EventArgs e)
        {
            MemberForm window = new MemberForm();
            window.ShowDialog();

            if (window.ReturnProjectMember is null)
                return;

            if (SchedulerProjectObject.ProjectMembers.Contains(window.ReturnProjectMember))
            {
                MessageBox.Show("Member with same full name already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SchedulerProjectObject.ProjectMembers.Add(window.ReturnProjectMember);
            DispalayMembers();
        }

        private void change_btn_Click(object sender, EventArgs e)
        {
            SchedulerProjectObject.Name = name_textbox.Text;
            SchedulerProjectObject.Description = description_textbox.Text;
        }
    }
}
