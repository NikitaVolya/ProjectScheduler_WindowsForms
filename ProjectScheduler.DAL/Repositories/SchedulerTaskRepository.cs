using Microsoft.EntityFrameworkCore;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler.DAL.Repositories
{
    internal class SchedulerTaskRepository
    {
        private AppDbContext _context;
        public SchedulerTaskRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(SchedulerTask task)
        {
            _context.SchedulerTasks.Add(task);
            _context.SaveChanges();
        }
        public void AddRange(List<SchedulerTask> task)
        {
            _context.SchedulerTasks.AddRange(task);
            _context.SaveChanges();
        }
        public void Remove(SchedulerTask task)
        {
            _context.SchedulerTasks.Remove(task);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<SchedulerTask> tasks)
        {
            _context.SchedulerTasks.RemoveRange(tasks);
            _context.SaveChanges();
        }
        public void Update(SchedulerTask task)
        {
            _context.SchedulerTasks.Update(task);
            _context.SaveChanges();
        }
        public IEnumerable<SchedulerTask> GetAll()
        {
            return _context.SchedulerTasks
                .Include(t => t.SchedulerCategory)
                .Include(t => t.SchedulerOwner);
        }
        public IEnumerable<SchedulerTask> GeTasksByProject(int project_id)
        {
            return GetAll().Where(t => t.ProjectId == project_id);
        }
        public IEnumerable<SchedulerTask> GetTasksByMemberId(int member_id)
        {
            return GetAll().Where(t => t.OwnerId == member_id);
        }
        public SchedulerTask? GetTaskById(int id)
        {
            return GetAll()
                .Where(t => t.Id == id)
                .FirstOrDefault();
        }
    }
}
