

namespace ProjectScheduler.DAL.Entities
{
    public enum SchedulerStatus
    {
        Planned,
        InProgress,
        Done
    }

    public class SchedulerTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public SchedulerStatus Status { get; set; }

        public int ProjectId { get; set; }
        public SchedulerProject SchedulerProject { get; set; }

        public int OwnerId { get; set; }
        public SchedulerMember SchedulerOwner { get; set; }

        public int CategoryId { get; set; }
        public SchedulerCategory SchedulerCategory { get; set; }
    }
}
