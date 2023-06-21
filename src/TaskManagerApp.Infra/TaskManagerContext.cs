using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Extensions;
using TaskManagerApp.Infra.Utils;

namespace TaskManagerApp.Infra
{
    public sealed class TaskManagerContext : DbContext
    {
        internal readonly ICurrentUserProvider CurrentUserProvider;

        public TaskManagerContext(
            DbContextOptions options,
            ICurrentUserProvider currentUserProvider
        ) : base(options)
        {
            CurrentUserProvider = currentUserProvider;
        }

        public DbSet<PresetTaskItem> PresetTaskItems { get; set; } = null!;
        public DbSet<Profile> Profiles { get; set; } = null!;
        public DbSet<ProfileType> ProfileTypes { get; set; } = null!;
        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<Timesheet> Timesheets { get; set; } = null!;
        public DbSet<TimesheetNote> TimesheetNotes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;

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
            var userId = CurrentUserProvider.UserId;
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

        public async Task<int> SaveChangesWithoutUserTrackingAsync(
            CancellationToken cancellationToken = default
        )
        {
            var now = DateTime.Now;

            this.SetPropOnAdded("CreatedAt", now);
            this.UpdatePropOnChange("UpdatedAt", now);

            return await base.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);
        }
    }
}
