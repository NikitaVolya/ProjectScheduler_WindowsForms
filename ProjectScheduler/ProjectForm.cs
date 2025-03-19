using ShedulerObjects;

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

            if (!window.ConfirmClick)
                return;

            _members.Add(window.SchedulerMemberObject);
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

        private void members_listbox_DoubleClick(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem is null)
                return;

            MemberForm window = new MemberForm();
            window.SchedulerMemberObject = _members[members_listbox.SelectedIndex];
            window.ConfirmButtonText = "save";
            window.ShowDialog();

            DispalayMembers();
        }

        private void delete_member_btn_Click(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem is null)
                return;
            int index = members_listbox.SelectedIndex;
            _members.RemoveAt(index);
            DispalayMembers();
        }

        private void choice_location_btn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                _new_file_path = folderBrowserDialog.SelectedPath;
        }
    }
}
