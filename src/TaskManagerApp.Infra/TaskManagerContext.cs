using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Extensions;

namespace TaskManagerApp.Infra
{
    public sealed class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Goal> Goals { get; set; } = null!;
        public DbSet<GoalStep> GoalSteps { get; set; } = null!;
        public DbSet<GoalTaskItem> GoalTaskItems { get; set; } = null!;
        public DbSet<PresetTaskItem> PresetTaskItems { get; set; } = null!;
        public DbSet<Profile> Profiles { get; set; } = null!;
        public DbSet<ProfileType> ProfileTypes { get; set; } = null!;
        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<TaskItemNote> TaskItemNotes { get; set; } = null!;
        public DbSet<Timesheet> Timesheets { get; set; } = null!;
        public DbSet<TimesheetNote> TimesheetNotes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDeleteBehavior(modelBuilder);

            modelBuilder.SeedDatabase();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TaskManagerContext))!);
        }

        private void ConfigureDeleteBehavior(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}