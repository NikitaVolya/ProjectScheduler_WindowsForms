

namespace ProjectScheduler.DAL.Entities
{
    public class SchedulerCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ColorRed { get; set; }
        public int ColorGreen { get; set; }
        public int ColorBlue { get; set; }

        public int SchedulerProjectId { get; set; }
        public SchedulerProject SchedulerProject { get; set; }
    }
}
