using Microsoft.EntityFrameworkCore;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler.DAL.Repositories
{
    internal class SchedulerProjectRepository
    {
        private AppDbContext _context;
        public SchedulerProjectRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(SchedulerProject project)
        {
            _context.SchedulerProjects.Add(project);
            _context.SaveChanges();
        }
        public void AddRange(List<SchedulerProject> projects)
        {
            _context.SchedulerProjects.AddRange(projects);
            _context.SaveChanges();
        }
        public void AddProjectMember(SchedulerProject project, SchedulerMember member)
        {
            member.SchedulerProject = project;
            project.SchedulerMembers.Add(member);
            _context.SchedulerProjects.Update(project);
            _context.SaveChanges();
        }
        public void Remove(SchedulerProject project)
        {
            _context.SchedulerProjects.Remove(project);
            _context.SaveChanges();
        }
        public void Update(SchedulerProject project)
        {
            _context.SchedulerProjects.Update(project);
            _context.SaveChanges();
        }

        public IEnumerable<SchedulerProject> GetAll()
        {
            return _context.SchedulerProjects
                .Include(p => p.SchedulerTasks)
                .Include(p => p.SchedulerMembers)
                .Include(p => p.SchedulerCategories);
        }

        public SchedulerProject? GetById(int id)
        {
            return GetAll()
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public SchedulerProject? GetByName(string name)
        {
            return GetAll()
                .Where(p => p.Name == name)
                .FirstOrDefault();
        }
    }
}
