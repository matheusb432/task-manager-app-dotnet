using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Extensions;
using TaskManagerApp.Infra.Utils;

namespace TaskManagerApp.Infra
{
    public sealed class TaskManagerContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskManagerContext(
            DbContextOptions options,
            IHttpContextAccessor httpContextAccessor
        ) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Goal> Goals { get; set; } = null!;
        public DbSet<GoalStep> GoalSteps { get; set; } = null!;
        public DbSet<GoalTaskItem> GoalTaskItems { get; set; } = null!;
        public DbSet<PresetTaskItem> PresetTaskItems { get; set; } = null!;
        public DbSet<Profile> Profiles { get; set; } = null!;
        public DbSet<ProfileType> ProfileTypes { get; set; } = null!;
        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<Timesheet> Timesheets { get; set; } = null!;
        public DbSet<TimesheetNote> TimesheetNotes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDeleteBehavior(modelBuilder);

            modelBuilder.SeedDatabase();

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(typeof(TaskManagerContext))!
            );
        }

        private void ConfigureDeleteBehavior(ModelBuilder modelBuilder)
        {
            foreach (
                var relationship in modelBuilder.Model
                    .GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys())
            )
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default
        )
        {
            var userId = int.Parse(
                _httpContextAccessor.HttpContext.User.FindFirst("UserId")?.Value ?? "-1"
            );
            var now = DateTime.Now;

            this.SetPropOnAdded("CreatedAt", now);
            this.UpdatePropOnChange("UpdatedAt", now);
            if (userId > 0)
            {
                this.SetPropOnAdded("UserCreatedId", userId);
                this.UpdatePropOnChange("UserUpdatedId", userId);
            }

            return await base.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);
        }
    }
}
