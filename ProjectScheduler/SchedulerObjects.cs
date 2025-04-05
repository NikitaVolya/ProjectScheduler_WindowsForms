
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler.SchedulerObjects
{

    public class TaskSchedulerPanel
    {

        static public Panel CreatePanel(SchedulerTask task, WorkForm window)
        {
            Panel body = new Panel();
            body.BackColor = Color.White;
            body.Size = new Size(250, 200);

            Panel color_panel = new Panel();
            color_panel.BackColor = Color.FromArgb(task.SchedulerCategory.ColorRed, task.SchedulerCategory.ColorGreen, task.SchedulerCategory.ColorBlue);
            color_panel.Size = new Size(body.Width - 10, 15);
            color_panel.Location = new Point(5, 10);

            Label category_label = new Label();
            category_label.Text = task.SchedulerCategory.Name;
            category_label.Font = new Font("Segoe", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            category_label.Size = new Size(body.Width, 25);
            category_label.Location = new Point(15, 55);

            Label title_label = new Label();
            title_label.Text = task.Name;
            title_label.Font = new Font("Segoe", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            title_label.Size = new Size(body.Width, 25);
            title_label.Location = new Point(15, 30);

            Label date_label = new Label();
            date_label.Text = task.DeadLine.ToString("d");
            date_label.Font = new Font("Segoe", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            date_label.Location = new Point(15, 80);
            date_label.Size = new Size(body.Width, 25);

            Label owner_label = new Label();
            owner_label.Text = task.SchedulerOwner.FirstName + " " + task.SchedulerOwner.LastName;
            owner_label.Font = new Font("Segoe", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            owner_label.Location = new Point(15, 105);
            owner_label.Size = new Size(body.Width, 25);

            Label description_label = new Label();
            description_label.Text = task.Description;
            description_label.Font = new Font("Segoe", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            description_label.Location = new Point(15, 135);
            description_label.ForeColor = Color.Gray;
            description_label.Size = new Size(body.Width, body.Height / 3);

            NumericUpDown task_id = new NumericUpDown();
            task_id.Value = task.Id;
            task_id.Visible = false;

            body.Controls.Add(task_id);
            body.Controls.Add(color_panel);
            body.Controls.Add(title_label);
            body.Controls.Add(category_label);
            body.Controls.Add(date_label);
            body.Controls.Add(owner_label);
            body.Controls.Add(description_label);

            return body;
        }
    }
}
