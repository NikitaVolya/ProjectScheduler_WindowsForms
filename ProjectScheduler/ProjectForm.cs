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

namespace Project
{
    public partial class ProjectForm : Form
    {
        private List<SchedulerMember> _members;
        private string _new_file_path;
        private string? _new_project_path;

        public MainMenuForm MainMenuWindow { get; set; }

        public string? NewProjectFilePath { get => _new_project_path; }

        public ProjectForm()
        {

            _members = new List<SchedulerMember>();

            _new_file_path = Directory.GetCurrentDirectory();
            _new_project_path = null;

            InitializeComponent();
        }

        private void CreateProjectForm_Load(object sender, EventArgs e)
        {
            
        }

        private void DispalayMembers()
        {
            members_listbox.Items.Clear();

            foreach (SchedulerMember member in _members)
                members_listbox.Items.Add($"{member.Name} {member.Surname}");
        }

        private void add_member_btn_Click(object sender, EventArgs e)
        {
            MemberForm window = new MemberForm();
            window.ShowDialog();

            if (window.ReturnProjectMember is null)
                return;

            if (_members.Contains(window.ReturnProjectMember))
            {
                MessageBox.Show("Member with same full name already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _members.Add(window.ReturnProjectMember);
            DispalayMembers();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty)
            {
                MessageBox.Show("The project name field must be filled in!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SchedulerProject new_project = new SchedulerProject(name_textbox.Text, description_textbox.Text);
            new_project.ProjectMembers = _members;
            _new_project_path = _new_file_path + "\\" + name_textbox.Text.ToLower().Replace(' ', '_') + ".xml";

            XMLSchedulerWriter.SaveToXML(new_project, _new_project_path);

            MainMenuWindow.AddProject(_new_project_path);

            Close();
        }

        private void CreateProjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenuWindow.Show();
        }

        private SchedulerMember? GetSelectedMember()
        {
            string? selected_member_fullname = members_listbox.SelectedItem?.ToString();

            return _members.Find(member =>member.FullName == selected_member_fullname);
        }

        private void members_listbox_DoubleClick(object sender, EventArgs e)
        {
            SchedulerMember? selected_member = GetSelectedMember();

            if (selected_member is null)
                return;

            MemberForm window = new MemberForm();

            
            SchedulerMember tmp = selected_member.Clone() as SchedulerMember;
            window.ModifyMember = selected_member;
            window.ShowDialog();

            if (window.ReturnProjectMember is null)
                return;

            if (window.ReturnProjectMember == selected_member)
                return;

            if (_members.Contains(window.ReturnProjectMember))
            {
                MessageBox.Show("Member with same full name already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _members.Remove(selected_member);
            _members.Add(window.ReturnProjectMember);

            DispalayMembers();
        }

        private void delete_member_btn_Click(object sender, EventArgs e)
        {
            SchedulerMember? selected_member = GetSelectedMember();

            if (selected_member is null)
                return;

            _members.Remove(selected_member);
            DispalayMembers();
        }

        private void choice_location_btn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                _new_file_path = folderBrowserDialog.SelectedPath;
        }
    }
}
