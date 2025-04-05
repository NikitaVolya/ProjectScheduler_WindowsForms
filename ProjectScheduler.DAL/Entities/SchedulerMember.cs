

namespace ProjectScheduler.DAL.Entities
{
    public class SchedulerMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public int SchedulerProjectId { get; set; }
        public SchedulerProject SchedulerProject { get; set; }
    }
}
