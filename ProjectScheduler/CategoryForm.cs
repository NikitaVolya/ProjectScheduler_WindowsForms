using ShedulerObjects;

namespace Project
{
    public partial class CategoryForm : Form
    {
        public SchedulerProject ProjectObject { get; set; }
        public SchedulerCategory SchedulerCategoryObject { get; set; }
        private bool _confirm_btn_click;
        public bool ConfirmClick { get => _confirm_btn_click; }
        public string ConfirmButtonText { get => confirm_btn.Text; set => confirm_btn.Text = value; }

        public CategoryForm()
        {
            InitializeComponent();

            SchedulerCategoryObject = new SchedulerCategory("", "", Color.White);
            _confirm_btn_click = false;

            color_Scroll(null, null);
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty)
            {
                MessageBox.Show("The name field must be filled in", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SchedulerCategoryObject.Name = name_textbox.Text;
            SchedulerCategoryObject.Description = description_textbox.Text;
            SchedulerCategoryObject.CategoryColor = color_panel.BackColor;
            _confirm_btn_click = true;
            Close();
        }

        private void color_Scroll(object sender, EventArgs e)
        {
            color_panel.BackColor = Color.FromArgb((int)red_numeric.Value, (int)green_numeric.Value, (int)blue_numeric.Value);
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            name_textbox.Text = SchedulerCategoryObject.Name;
            description_textbox.Text = SchedulerCategoryObject.Description;
            color_panel.BackColor = SchedulerCategoryObject.CategoryColor;
            red_numeric.Value = SchedulerCategoryObject.CategoryColor.R;
            green_numeric.Value = SchedulerCategoryObject.CategoryColor.G;
            blue_numeric.Value = SchedulerCategoryObject.CategoryColor.B;
        }
    }
}
