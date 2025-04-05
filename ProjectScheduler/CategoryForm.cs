using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler
{
    public partial class CategoryForm : Form
    {
        public SchedulerCategory? Target { get; set; }
        public bool ConfirmClick { get => _confirm_click; }
        public string ConfirmButtonText { 
            get => confirm_btn.Text; 
            set => confirm_btn.Text = value; 
        }


        private bool _confirm_click;
        private Color ChosenColor { 
            get => 
                Color.FromArgb(
            (int)red_numeric.Value,
            (int)green_numeric.Value, 
            (int)blue_numeric.Value);
        }

        public CategoryForm()
        {
            InitializeComponent();

            _confirm_click = false;

            color_Scroll(null, null);
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            if (Target == null)
            {
                MessageBox.Show("Error loading category data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            name_textbox.Text = Target.Name;
            description_textbox.Text = Target.Description;

            red_numeric.Value = Target.ColorRed;
            green_numeric.Value = Target.ColorGreen;
            blue_numeric.Value = Target.ColorBlue;

            color_panel.BackColor = ChosenColor;

        }

        private void color_Scroll(object sender, EventArgs e)
        {
            color_panel.BackColor = ChosenColor;
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty)
            {
                MessageBox.Show("The name field must be filled in", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Target.Name = name_textbox.Text;
            Target.Description = description_textbox.Text;
            Target.ColorRed = ChosenColor.R;
            Target.ColorGreen = ChosenColor.G;
            Target.ColorBlue = ChosenColor.B;
            _confirm_click = true;
            Close();
        }
    }
}
