using Microsoft.EntityFrameworkCore;
using ProjectScheduler.DAL.Entities;

namespace ProjectScheduler.DAL.Repositories
{
    internal class SchedulerMemberRepository
    {
        private AppDbContext _context;
        public SchedulerMemberRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(SchedulerMember member)
        {
            _context.SchedulerMembers.Add(member);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<SchedulerMember> member)
        {
            _context.SchedulerMembers.AddRange(member);
            _context.SaveChanges();
        }
        public void Remove(SchedulerMember member)
        {
            _context.SchedulerMembers.Remove(member);
            _context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<SchedulerMember> schedulerMembers)
        {
            _context.SchedulerMembers.RemoveRange(schedulerMembers);
            _context.SaveChanges();
        }
        public void Update(SchedulerMember member)
        {
            _context.SchedulerMembers.Update(member);
            _context.SaveChanges();
        }

        public IEnumerable<SchedulerMember> GetAll()
        {
            return _context.SchedulerMembers;
        }

        public SchedulerMember? GetById(int id)
        {
            return _context.SchedulerMembers.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool ExistWithId(int id)
        {
            return _context.SchedulerMembers.Any(c => c.Id == id);
        }

        public IEnumerable<SchedulerMember> GetAllByProjectId(int project_id)
        {
            return _context.SchedulerMembers
                .Where(m => m.SchedulerProject.Id == project_id);
        }
    }
}
