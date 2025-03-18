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
        static private uint _global_id = 0;
        static private uint GetNewId { get => _global_id++; }
        private uint _id;
        
        public uint Id { get => _id; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ShedulerObject(string name, string description)
        {
            _id = GetNewId;
            Name = name;
            Description = description;
        }

        public override string ToString() => $"[ShedulerObject {_id} | {Name}]";
        public override int GetHashCode() => base.GetHashCode();
        public override bool Equals(object? obj) => base.Equals(obj);
        public static bool operator ==(ShedulerObject a, ShedulerObject y) => a._id == y._id;
        public static bool operator !=(ShedulerObject a, ShedulerObject y) => !(a == y);
    }

    public class SchedulerMember : ShedulerObject
    {
        public string Surname { get; set; }
        public string FullName { get => $"{Name} {Surname}"; }

        public SchedulerMember(string name, string surname, string description) : base(name, description)
        {
            Surname = surname;
        }
    }

    public class SchedulerCategory : ShedulerObject
    {
        public Color CategoryColor { get; set; }

        public SchedulerCategory(string name, string description, Color categoryColor) : base(name, description)
        {
            CategoryColor = categoryColor;
        }
    }

    public class SchedulerTask : ShedulerObject
    {
        public SchedulerTaskStatus Status { get; set; }
        public SchedulerCategory? TaskCategory { get; set; }
        public SchedulerMember? TaskOwner { get; set; }
        public DateTime Deadline { get; set; }

        public Color TaskCategoryColor { get => (TaskCategory is null ? Color.White : TaskCategory.CategoryColor); }
        public string TaskCategoryName { get => (TaskCategory is null ? "" : TaskCategory.Name); }
        public string TaskOwnerFullName { get => (TaskOwner is null ? "" : TaskOwner.FullName); }

        public SchedulerTask(string name, string description, SchedulerTaskStatus status, DateTime deadline, 
            SchedulerCategory? taskCategory = null, SchedulerMember? taskOwner = null) : base(name, description)
        {
            Status = status;
            TaskCategory = taskCategory;
            TaskOwner = taskOwner;
            Deadline = deadline;
        }
    }

    public class SchedulerProject : ShedulerObject
    {
        public List<SchedulerTask> Tasks { get; set; }
        public List<SchedulerCategory> ProjectCategories { get; set; }
        public List<SchedulerMember> ProjectMembers { get; set; }

        public SchedulerProject(string name, string description) : base(name, description)
        {

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

        private static XElement ProjectTaskToXML(SchedulerTask task, SchedulerProject project)
        {
            return new XElement("Task",
                    new XElement("TaskName", task.Name),
                    new XElement("TaskDescription", task.Description),
                    new XElement("TaskStatus", task.Status),
                    new XElement("TaskCategory", (task.TaskCategory is null ? -1 : project.ProjectCategories.IndexOf(task.TaskCategory))),
                    new XElement("TaskOwner", (task.TaskOwner is null ? -1 : project.ProjectMembers.IndexOf(task.TaskOwner))),
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
                    new XElement("ProjectTasks", (from task in project.Tasks select ProjectTaskToXML(task, project)).ToArray())
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

            Color category_color = Color.FromArgb(int.Parse(r_element.Value), int.Parse(g_element.Value), int.Parse(b_element.Value));
            return new SchedulerCategory(name_element.Value, description_element.Value, category_color);
            
        }

        private static SchedulerMember ProjectMemberParse(XElement data)
        {
            XElement name_element = data.Descendants("MemberName").First();
            XElement surname_element = data.Descendants("MemberSurname").First();
            XElement description_element = data.Descendants("MemberDescription").First();

            return new SchedulerMember(name_element.Value, surname_element.Value, description_element.Value);
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
                    int owner_index = int.Parse(task_data.Descendants("TaskOwner").First().Value);
                    int category_index = int.Parse(task_data.Descendants("TaskCategory").First().Value);
                    SchedulerMember? owner = (owner_index == -1 ? null : members[owner_index]);
                    SchedulerCategory? category = (category_index == -1 ? null : categories[category_index]);

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
                    DateTime task_deadline_date = DateTime.Parse(task_deadline.Value);
                    tasks.Add(new SchedulerTask(task_name.Value, task_description.Value, status, task_deadline_date, category, owner));
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
            catch (Exception e)
            {
                MessageBox.Show("Error during opening project " + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            color_panel.BackColor = task.TaskCategoryColor;
            color_panel.Size = new Size(body.Width - 10, 15);
            color_panel.Location = new Point(5, 10);

            Label category_label = new Label();
            category_label.Text = task.TaskOwnerFullName;
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
            owner_label.Text = task.TaskOwnerFullName;
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
