using ProjectScheduler.DAL;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler
{
    public partial class MemberForm : Form
    {
        public SchedulerMember? Target { get; set; }

        public bool ConfirmClick { get => _confirm_btn_click; }
        public string ConfirmButtonText { get => confirm_btn.Text; set => confirm_btn.Text = value; }

        private bool _confirm_btn_click;

        public MemberForm()
        {
            InitializeComponent();
        }

        private void CreateMember_Load(object sender, EventArgs e)
        {
            if (Target == null)
            {
                MessageBox.Show("Error loading member data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            name_textbox.Text = Target.FirstName;
            surname_textbox.Text = Target.LastName;
            description_textbox.Text = Target.Description;
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty || surname_textbox.Text == String.Empty)
            {
                MessageBox.Show("Incorect input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            Target.FirstName = name_textbox.Text;
            Target.LastName = surname_textbox.Text;
            Target.Description = description_textbox.Text;
            _confirm_btn_click = true;
            Close();
        }

        private void input_filter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }
    }
}
