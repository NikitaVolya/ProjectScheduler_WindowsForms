

using Microsoft.EntityFrameworkCore;

namespace ProjectScheduler.DAL
{
    using Entities;
    using Microsoft.Extensions.Configuration;

    internal class AppDbContext : DbContext
    {

        public DbSet<SchedulerProject> SchedulerProjects { get; set; }
        public DbSet<SchedulerMember> SchedulerMembers { get; set; }
        public DbSet<SchedulerCategory> SchedulerCategories { get; set; }
        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionStr = connection.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchedulerProject>()
                .HasMany(p => p.SchedulerCategories)
                .WithOne(c => c.SchedulerProject)
                .HasForeignKey(c => c.SchedulerProjectId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SchedulerProject>()
                .HasMany(p => p.SchedulerMembers)
                .WithOne(m => m.SchedulerProject)
                .HasForeignKey(m => m.SchedulerProjectId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SchedulerProject>()
                .HasMany(p => p.SchedulerTasks)
                .WithOne(t => t.SchedulerProject)
                .HasForeignKey(t => t.ProjectId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SchedulerTask>()
                .HasOne(t => t.SchedulerOwner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SchedulerTask>()
                .HasOne(t => t.SchedulerCategory)
                .WithMany()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SchedulerTask>()
                .Property(t => t.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
