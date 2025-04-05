

namespace ProjectScheduler.DAL.Entities
{
    public class SchedulerProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<SchedulerCategory> SchedulerCategories { get; set; }
        public List<SchedulerMember> SchedulerMembers { get; set; }
        public List<SchedulerTask> SchedulerTasks { get; set; }
    }
}
