using Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShedulerObjects
{
    public enum SchedulerTaskStatus
    {
        Planned,
        InProgress,
        Done
    }

    public class ShedulerObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SchedulerMember : ShedulerObject, ICloneable
    {
        public string Surname { get; set; }

        public string FullName { get => $"{Name} {Surname}"; }

        public override string ToString() => FullName;
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object? obj) => GetHashCode() == obj?.GetHashCode();

        public static bool operator ==(SchedulerMember x, SchedulerMember y) => !(x is null) && x.Equals(y);
        public static bool operator !=(SchedulerMember x, SchedulerMember y) => !(x == y);

        public object Clone() => new SchedulerMember { Name = this.Name, Surname = this.Surname, Description = this.Description };
    }

    public class SchedulerCategory : ShedulerObject
    {
        public Color CategoryColor { get; set; }

        public static bool operator==(SchedulerCategory x, SchedulerCategory y) => x.Name == y.Name;
        public static bool operator!=(SchedulerCategory x, SchedulerCategory ya) => !(x == ya);

        public override string ToString() => $"Categoty: {Name}";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object? obj) => GetHashCode()==obj?.GetHashCode();
    }

    public class SchedulerTask : ShedulerObject
    {
        public SchedulerTaskStatus Status { get; set; }
        public SchedulerCategory TaskCategory { get; set; }
        public SchedulerMember TaskOwner { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class SchedulerProject : ShedulerObject
    {
        public List<SchedulerTask> Tasks { get; set; }
        public List<SchedulerCategory> ProjectCategories { get; set; }
        public List<SchedulerMember> ProjectMembers { get; set; }

        public SchedulerProject(string name, string description)
        {
            Name = name;
            Description = description;

            Tasks = new List<SchedulerTask>();
            ProjectCategories = new List<SchedulerCategory>();
            ProjectMembers = new List<SchedulerMember>();
        }
    }

    public class XMLSchedulerWriter
    {
        private static XElement ProjectCategoryToXML(SchedulerCategory category)
        {
            return new XElement("Category",
                    new XElement("CategoryName", category.Name),
                    new XElement("CategoryDescription", category.Description),
                    new XElement("CategoryColor",
                            new XElement("R", category.CategoryColor.R),
                            new XElement("G", category.CategoryColor.G),
                            new XElement("B", category.CategoryColor.B)
                        )
                    );
        }

        private static XElement ProjectMemberToXML(SchedulerMember member)
        {
            return new XElement("Member",
                    new XElement("MemberName", member.Name),
                    new XElement("MemberSurname", member.Surname),
                    new XElement("MemberDescription", member.Description)
                );
        }

        private static XElement ProjectTaskToXML(SchedulerTask task)
        {
            return new XElement("Task",
                    new XElement("TaskName", task.Name),
                    new XElement("TaskDescription", task.Description),
                    new XElement("TaskStatus", task.Status),
                    new XElement("TaskCategory", task.TaskCategory),
                    new XElement("TaskOwner", task.TaskOwner.FullName),
                    new XElement("TaskDeadline", task.Deadline.ToString())
                );
        }

        private static XElement ProjectToXML(SchedulerProject project)
        {
            return new XElement("Poject",
                    new XElement("ProjectName", project.Name),
                    new XElement("ProjectDescription", project.Description),
                    new XElement("ProjectMembers", (from member in project.ProjectMembers select ProjectMemberToXML(member)).ToArray()),
                    new XElement("ProjectCategories", (from category in project.ProjectCategories select ProjectCategoryToXML(category)).ToArray()),
                    new XElement("ProjectTasks", (from task in project.Tasks select ProjectTaskToXML(task)).ToArray())
                );
        }

        public static void SaveToXML(SchedulerProject project, string file_path)
        {
            File.WriteAllText(file_path, ProjectToXML(project).ToString());
        }
    }

    public class XMLSchedulerParser
    {
        private static SchedulerCategory ProjectCategoryParse(XElement data)
        {
            XElement name_element = data.Descendants("CategoryName").First();
            XElement description_element = data.Descendants("CategoryDescription").First();
            XElement r_element = data.Descendants("R").First();
            XElement g_element = data.Descendants("G").First();
            XElement b_element = data.Descendants("B").First();

            return new SchedulerCategory
            {
                Name = name_element.Value,
                Description = description_element.Value,
                CategoryColor = Color.FromArgb(
                        int.Parse(r_element.Value),
                        int.Parse(g_element.Value),
                        int.Parse(b_element.Value)
                    )
            };
        }

        private static SchedulerMember ProjectMemberParse(XElement data)
        {
            XElement name_element = data.Descendants("MemberName").First();
            XElement surname_element = data.Descendants("MemberSurname").First();
            XElement description_element = data.Descendants("MemberDescription").First();

            return new SchedulerMember
            {
                Name = name_element.Value,
                Surname = surname_element.Value,
                Description = description_element.Value
            };
        }

        public static SchedulerProject? ProjectParse(string file_path)
        {
            try
            {
                XElement project_data = XElement.Load(file_path);
            
                List<SchedulerMember> members = (from member_data in project_data.Element("ProjectMembers")?.Elements()
                                               select ProjectMemberParse(member_data)).ToList();
                List<SchedulerCategory> categories = (from category_data in project_data.Element("ProjectCategories")?.Elements()
                                                    select ProjectCategoryParse(category_data)).ToList();

                List<SchedulerTask> tasks = new List<SchedulerTask>();

                foreach (XElement task_data in project_data.Element("ProjectTasks")?.Elements())
                {
                    string? task_owner = task_data.Descendants("TaskOwner").First().Value;
                    string? category_name = task_data.Descendants("TaskCategory").First().Value;

                    SchedulerMember? owner = members.Find(e => e.FullName == task_owner);
                    if (owner is null)
                        throw new Exception("Error during SchedulerTask.SchedulerMember in XML file");

                    SchedulerCategory? category = categories.Find(e => e.ToString() == category_name);
                    if (category is null)
                        throw new Exception("Error during SchedulerTask.SchedulerCategory in XML file");

                    XElement task_name = task_data.Descendants("TaskName").First();
                    XElement task_description = task_data.Descendants("TaskDescription").First();
                    XElement task_deadline = task_data.Descendants("TaskDeadline").First();
                    XElement task_status = task_data.Descendants("TaskStatus").First();

                    SchedulerTaskStatus status = SchedulerTaskStatus.Planned;
                    switch (task_status.Value)
                    {
                        case "Planned":
                            status = SchedulerTaskStatus.Planned;
                            break;
                        case "InProgress":
                            status = SchedulerTaskStatus.InProgress;
                            break;
                        case "Done":
                            status = SchedulerTaskStatus.Done;
                            break;
                        default:
                            throw new Exception("Error during SchedulerTask.TaskStatus in XML file");
                    }

                    tasks.Add(new SchedulerTask
                    {
                        Name = task_name.Value,
                        Description = task_description.Value,
                        Deadline = DateTime.Parse(task_deadline.Value),
                        TaskOwner = owner,
                        TaskCategory = category,
                        Status = status
                    });
                }

                XElement? project_name = project_data.Element("ProjectName");
                XElement? project_description = project_data.Element("ProjectDescription");

                if (project_name is null || project_description is null)
                    throw new Exception("Error during SchedulerTask in XML file");

                SchedulerProject rep = new SchedulerProject(project_name.Value, project_description.Value);
                rep.ProjectMembers = members;
                rep.ProjectCategories = categories;
                rep.Tasks = tasks;
                return rep;
            }
            catch
            {
                MessageBox.Show("Error during opening project", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

    public class TaskSchedulerPanel
    {

        static public Panel CreatePanel(SchedulerTask task, WorkForm window)
        {
            Panel body = new Panel();
            body.BackColor = Color.White;
            body.Size = new Size(280, 200);

            Panel color_panel = new Panel();
            color_panel.BackColor = task.TaskCategory.CategoryColor;
            color_panel.Size = new Size(body.Width - 10, 15);
            color_panel.Location = new Point(5, 10);

            Label category_label = new Label();
            category_label.Text = task.TaskCategory.Name;
            category_label.Font = new Font("Segoe", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            category_label.Size = new Size(body.Width, 25);
            category_label.Location = new Point(15, 55);

            Label title_label = new Label();
            title_label.Text = task.Name;
            title_label.Font = new Font("Segoe", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            title_label.Size = new Size(body.Width, 25);
            title_label.Location = new Point(15, 30);

            Label date_label = new Label();
            date_label.Text = task.Deadline.ToString("d");
            date_label.Font = new Font("Segoe", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            date_label.Location = new Point(15, 80);
            date_label.Size = new Size(body.Width, 25);

            Label owner_label = new Label();
            owner_label.Text = task.TaskOwner.FullName;
            owner_label.Font = new Font("Segoe", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            owner_label.Location = new Point(15, 105);
            owner_label.Size = new Size(body.Width, 25);

            Label description_label = new Label();
            description_label.Text = task.Description;
            description_label.Font = new Font("Segoe", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            description_label.Location = new Point(15, 135);
            description_label.ForeColor = Color.Gray;
            description_label.Size = new Size(body.Width, body.Height / 3);

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
