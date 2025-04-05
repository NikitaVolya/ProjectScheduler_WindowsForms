using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler
{
    public partial class ProjectForm : Form
    {
        public SchedulerProject Target { get; set; }
        public MainMenuForm MainMenuWindow { get; set; }
        public bool ConfirmClick { get => _confrim_click; }


        private bool _confrim_click;

        public ProjectForm()
        {
            InitializeComponent();
        }

        private void CreateProjectForm_Load(object sender, EventArgs e)
        {
            name_textbox.Text = Target.Name;
            description_textbox.Text = Target.Description;
        }
        private void CreateProjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenuWindow.Show();
        }

        private void DispalayMembers()
        {
            members_listbox.Items.Clear();
            foreach (SchedulerMember member in Target.SchedulerMembers)
                members_listbox.Items.Add($"{member.FirstName} {member.LastName}");
        }

        private void add_member_btn_Click(object sender, EventArgs e)
        {
            MemberForm window = new MemberForm();
            window.Target = new SchedulerMember
            {
                FirstName = "Firstname",
                LastName = "Surname",
                Description = "Description"
            };
            window.ShowDialog();

            if (!window.ConfirmClick)
                return;
            Target.SchedulerMembers.Add(window.Target);
            DispalayMembers();
        }
        private void members_listbox_DoubleClick(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem is null)
                return;

            MemberForm window = new MemberForm();

            window.Target = Target.SchedulerMembers[members_listbox.SelectedIndex];
            window.ConfirmButtonText = "save";
            window.ShowDialog();

            DispalayMembers();
        }
        private void delete_member_btn_Click(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem is null)
                return;
            int index = members_listbox.SelectedIndex;
            Target.SchedulerMembers.RemoveAt(index);
            DispalayMembers();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty)
            {
                MessageBox.Show("The project name field must be filled in!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Target.Name = name_textbox.Text;
            Target.Description = description_textbox.Text;
            _confrim_click = true;

            Close();
        }
    }
}
