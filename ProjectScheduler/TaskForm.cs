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
    public partial class TaskForm : Form
    {
        public SchedulerProject ProjectObject { get; set; }
        public SchedulerTask? TaskToUpdate { get; set; }

        public TaskForm()
        {
            InitializeComponent();
            TaskToUpdate = null;
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            update_categories();

            foreach (var member in ProjectObject.ProjectMembers)
                owner_combobox.Items.Add(member.FullName);

            if (!(TaskToUpdate is null))
            {
                name_textbox.Text = TaskToUpdate.Name;
                description_textbox.Text = TaskToUpdate.Description;
                category_combobox.Text = TaskToUpdate.TaskCategory.Name;
                owner_combobox.Text = TaskToUpdate.TaskOwner.FullName;
                deadlineDateTimePicker.Value = TaskToUpdate.Deadline;
                create_btn.Text = "Change";
            }
        }

        private void update_categories()
        {
            foreach (var category in ProjectObject.ProjectCategories)
                category_combobox.Items.Add(category.Name);
        }

        private void add_category_btn_Click(object sender, EventArgs e)
        {
            CategoryForm window = new CategoryForm();
            window.ProjectObject = ProjectObject;
            window.ShowDialog();

            update_categories();
        }

        private void category_combobox_ValueMemberChanged(object sender, EventArgs e)
        {
            string category_name = category_combobox.Text;
            SchedulerCategory? category = ProjectObject.ProjectCategories.Find(x => x.Name == category_name);
            if (category is null)
                return;
            color_panel.BackColor = category.CategoryColor;
        }

        private void create_cancel_message()
        {
            MessageBox.Show("All filds mast be full!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (name_textbox.Text == String.Empty || category_combobox.Text == String.Empty ||
                owner_combobox.Text == String.Empty)
            {
                create_cancel_message();
                return;
            }
            if (deadlineDateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show("dead line cancel message");
                return;
            }

            SchedulerMember? owner = ProjectObject.ProjectMembers.Find(x => x.FullName == owner_combobox.Text);
            SchedulerCategory? category = ProjectObject.ProjectCategories.Find(x => x.Name == category_combobox.Text);
            if (owner is null || category is null)
            {
                MessageBox.Show("Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (TaskToUpdate is null)
            {
                SchedulerTask new_project = new SchedulerTask
                {
                    Name = name_textbox.Text,
                    Description = description_textbox.Text,
                    TaskOwner = owner,
                    TaskCategory = category,
                    Deadline = deadlineDateTimePicker.Value
                };

                if (ProjectObject.Tasks.Contains(new_project))
                {
                    MessageBox.Show("task already exist");
                    return;
                }

                ProjectObject.Tasks.Add(new_project);
            } else
            {
                TaskToUpdate.Name = name_textbox.Text;
                TaskToUpdate.Description = description_textbox.Text;
                TaskToUpdate.TaskOwner = owner;
                TaskToUpdate.TaskCategory = category;
                TaskToUpdate.Deadline = deadlineDateTimePicker.Value;
            }
            Close();
        }
    }
}
