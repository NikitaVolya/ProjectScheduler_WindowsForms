using Microsoft.EntityFrameworkCore;
using ProjectScheduler.DAL.Entities;
using ProjectScheduler.DAL.Repositories;

namespace ProjectScheduler.DAL
{
    public class SchedulerProjectServise
    {
        private SchedulerProjectRepository _project_repository;
        private SchedulerMemberRepository _member_repository;
        private SchedulerTaskRepository _task_repository;
        private SchedulerCategoryRepository _category_repository;

        public SchedulerProjectServise()
        {
            _project_repository = new SchedulerProjectRepository();
            _member_repository = new SchedulerMemberRepository();
            _task_repository = new SchedulerTaskRepository();
            _category_repository = new SchedulerCategoryRepository();
        }
        public IEnumerable<SchedulerMember> GetProjectMembersByProjectId(int project_id)
        {
            return _member_repository.GetAllByProjectId(project_id);
        }
        public IEnumerable<SchedulerCategory> GetProjectCategoriesByProjectId(int project_id)
        {
            return _category_repository.GetAllByProjectId(project_id);
        }
        public IEnumerable<SchedulerTask> GetProjectTasksByStatus(SchedulerProject project, int status)
        {
            return _task_repository.GeTasksByProject(project.Id).Where(t => t.Status == (SchedulerStatus)status);
        }
        public bool ExisteTaskWithOwnerId(int owner_id)
        {
            return _task_repository.GetAll().Any(t => t.OwnerId == owner_id);
        }
        public IEnumerable<SchedulerTask> GetProjectTasksByCategoryId(int category_id)
        {
            return _task_repository.GetAll().Where(t => t.CategoryId == category_id);
        }
        public void AddProject(SchedulerProject project)
        {
            _project_repository.Add(project);
        }
        public void AddProjectCategory(SchedulerProject project, SchedulerCategory category)
        {
            category.SchedulerProject = project;
            project.SchedulerCategories.Add(category);
            UpdateProject(project);
        }
        public void AddProjectMember(SchedulerProject project, SchedulerMember member)
        {
            member.SchedulerProject = project;
            project.SchedulerMembers.Add(member);
            _project_repository.Update(project);
        }
        public void AddProjectTask(SchedulerProject project, SchedulerTask task)
        {
            task.SchedulerProject = project;
            project.SchedulerTasks.Add(task);
            _project_repository.Update(project);
        }
        public SchedulerTask? GetProjectTaskById(int task_id)
        {
            return _task_repository.GetTaskById(task_id);
        }
        public void UpdateProject(SchedulerProject project)
        {
            _project_repository.Update(project);
        }
        public void UpdateProjectTask(SchedulerTask test)
        {
            _task_repository.Update(test);
        }
        public void RemoveProject(SchedulerProject? project)
        {
            if (project is null)
                return;
            _project_repository.Remove(project);
        }

        public void RemoveProjectTask(SchedulerProject project, SchedulerTask task)
        {
            project.SchedulerTasks.Remove(task);
            UpdateProject(project);
        }
        public void RemoveProjectTaskRange(IEnumerable<SchedulerTask> tasks)
        {
            _task_repository.RemoveRange(tasks);
        }
        public void RemoveProjectMember(int member_id)
        {
            if (!_member_repository.ExistWithId(member_id))
                return;
            var tasks = _task_repository.GetTasksByMemberId(member_id);
            if (tasks.Count() > 0)
                _task_repository.RemoveRange(tasks);
            SchedulerMember? member = _member_repository.GetById(member_id);
            _member_repository.Remove(member);
        }
        public void RemoveProjectCategory(SchedulerCategory category)
        {
            _category_repository.Remove(category);
        }
        public IEnumerable<SchedulerProject> GetAllProjects()
        {
            return _project_repository.GetAll();
        }
    }
}
