using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TaskManagerApp.Infra.Utils
{
    public static class InfraUtils
    {
        public static readonly string DefaultConnectionName = "TaskManagerAppConnection";

        public static readonly string DefaultConnection =
            "Server=.\\SQLEXPRESS;Database=TaskManagerAppDB;Trusted_Connection=True;";

        public static string GetEnv(string key) =>
            Environment.GetEnvironmentVariable(key) ?? string.Empty;

        public static void SetPropOnAdded(this DbContext ctx, string property, dynamic value)
        {
            foreach (var entry in GetPropertyEntries(ctx, property))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(property).CurrentValue = value;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(property).IsModified = false;
                }
            }
        }

        public static void UpdatePropOnChange(this DbContext ctx, string property, dynamic value)
        {
            foreach (var entry in GetPropertyEntries(ctx, property))
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property(property).CurrentValue = value;
                }
                else
                {
                    entry.Property(property).IsModified = false;
                }
            }
        }

        private static IEnumerable<EntityEntry> GetPropertyEntries(DbContext ctx, string property)
        {
            return ctx.ChangeTracker
                .Entries()
                .Where(entry => entry.Entity.GetType().GetProperty(property) != null);
        }
    }
}
