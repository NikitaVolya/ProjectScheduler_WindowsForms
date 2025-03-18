using ShedulerObjects;

namespace Project
{
    public partial class MemberForm : Form
    {
        public SchedulerMember SchedulerMemberObject { get; set; }
        private bool _confirm_btn_click;
        public bool ConfirmClick { get => _confirm_btn_click; }
        public string ConfirmButtonText { get => confirm_btn.Text; set => confirm_btn.Text = value; }

        public MemberForm()
        {
            InitializeComponent();
            SchedulerMemberObject = new SchedulerMember("", "", "");
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty || surname_textbox.Text == String.Empty)
            {
                MessageBox.Show("Incorect input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            SchedulerMemberObject.Name = name_textbox.Text;
            SchedulerMemberObject.Surname = surname_textbox.Text;
            SchedulerMemberObject.Description = description_textbox.Text;
            _confirm_btn_click = true;
            Close();
        }

        private void CreateMember_Load(object sender, EventArgs e)
        {
            name_textbox.Text = SchedulerMemberObject.Name;
            surname_textbox.Text = SchedulerMemberObject.Surname;
            description_textbox.Text = SchedulerMemberObject.Description;
        }

        private void input_filter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
    }
}
