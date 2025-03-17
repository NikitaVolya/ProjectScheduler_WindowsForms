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
    public partial class MemberForm : Form
    {
        private SchedulerMember? _return_project_member;
        public SchedulerMember? ModifyMember { get; set; }

        public SchedulerMember? ReturnProjectMember => _return_project_member;

        public MemberForm()
        {
            InitializeComponent();

            ModifyMember = null;
        }

        private void cancel_create_handler()
        {
            MessageBox.Show("Incorect input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty)
            { 
                cancel_create_handler();
                return; 
            }
            if (surname_textbox.Text == String.Empty)
            {
                cancel_create_handler();
                return;
            }

            _return_project_member = new SchedulerMember
            {
                Name = name_textbox.Text,
                Surname = surname_textbox.Text,
                Description = description_textbox.Text
            };
            Close();
        }

        private void CreateMember_Load(object sender, EventArgs e)
        {
            _return_project_member = null;

            if (!(ModifyMember is null))
            {
                create_btn.Text = "Modify";
                name_textbox.Text = ModifyMember.Name;
                surname_textbox.Text = ModifyMember.Surname;
                description_textbox.Text = ModifyMember.Description;
            }
        }

        private void input_filter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
        }

        private void MemberForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(((int)e.KeyChar).ToString());
        }
    }
}
