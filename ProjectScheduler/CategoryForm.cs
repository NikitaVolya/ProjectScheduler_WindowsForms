using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShedulerObjects;

namespace Project
{
    public partial class CategoryForm : Form
    {
        public SchedulerProject ProjectObject { get; set; }

        public CategoryForm()
        {
            InitializeComponent();

            color_Scroll(null, null);
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty)
            {
                MessageBox.Show("The name field must be filled in", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SchedulerCategory new_category = new SchedulerCategory
            {
                Name = name_textbox.Text,
                Description = description_textbox.Text,
                CategoryColor = color_panel.BackColor
            };

            if (ProjectObject.ProjectCategories.Contains(new_category))
            {
                MessageBox.Show("The category with this name is already exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProjectObject.ProjectCategories.Add(new_category);
            Close();
        }

        private void color_Scroll(object sender, EventArgs e)
        {
            color_panel.BackColor = Color.FromArgb((int)red_numeric.Value, (int)green_numeric.Value, (int)blue_numeric.Value);
        }
    }
}
