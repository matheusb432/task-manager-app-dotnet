using System.Reflection;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp.Infra
{
    public sealed class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; } = null!;

        public DbSet<Photo> Photos { get; set; } = null!;

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
