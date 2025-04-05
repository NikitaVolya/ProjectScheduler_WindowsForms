using Microsoft.EntityFrameworkCore;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler.DAL.Repositories
{
    internal class SchedulerCategoryRepository
    {
        private AppDbContext _context;
        public SchedulerCategoryRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(SchedulerCategory category)
        {
            _context.SchedulerCategories.Add(category);
            _context.SaveChanges();
        }
        public void AddRange(List<SchedulerCategory> category)
        {
            _context.SchedulerCategories.AddRange(category);
            _context.SaveChanges();
        }
        public void Remove(SchedulerCategory category)
        {
            _context.SchedulerCategories.Remove(category);
            _context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<SchedulerCategory> categories)
        {
            _context.SchedulerCategories.RemoveRange(categories);
            _context.SaveChanges();
        }
        public void Update(SchedulerCategory category)
        {
            _context.SchedulerCategories.Update(category);
            _context.SaveChanges();
        }

        public IEnumerable<SchedulerCategory> GetAll()
        {
            return _context.SchedulerCategories;
        }

        public SchedulerCategory? GetById(int id)
        {
            return _context.SchedulerCategories
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }
        public bool ExistWithId(int id)
        {
            return _context.SchedulerCategories
                .Any(c => c.Id == id);
        }
        public IEnumerable<SchedulerCategory> GetAllByProjectId(int project_id)
        {
            return _context.SchedulerCategories
                .Where(c => c.SchedulerProjectId == project_id);
        }
    }
}
