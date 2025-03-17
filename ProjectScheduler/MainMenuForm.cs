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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();

        }

        public void AddProject(string path)
        {
            recent_project_listbox.Items.Add(path);
            save_to_file();
        }

        private void load_file()
        {
            string[] data = File.ReadAllLines("recent_projects.txt");
            foreach (string item in data)
                recent_project_listbox.Items.Add(item);
        }

        private void save_to_file()
        {
            string data = String.Empty;
            foreach (string item in recent_project_listbox.Items)
                data += item + "\n";
            File.WriteAllText("recent_projects.txt", data);
        }

        private void add_project_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                AddProject(file);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Text = "Project sheduler main menu";

            load_file();
        }

        private void remove_project_btn_Click(object sender, EventArgs e)
        {
            recent_project_listbox.Items.Remove(recent_project_listbox.SelectedItem);
            save_to_file();
        }

        private void recent_project_listbox_DoubleClick(object sender, EventArgs e)
        {
            var selected = recent_project_listbox.SelectedItem;
            if (selected is null)
                return;

            WorkForm workForm = new WorkForm();

            workForm.ProjectPath = selected.ToString();
            workForm.MenuWindow = this;

            workForm.Show();
            Hide();
        }

        private void create_project_btn_Click(object sender, EventArgs e)
        {
            ProjectForm window = new ProjectForm();
            window.MainMenuWindow = this;

            window.Show();
            Hide();
        }

        private void recent_project_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
