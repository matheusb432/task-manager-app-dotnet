using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class TimesheetConfiguration : BaseEntityConfiguration<Timesheet>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Timesheet> builder)
        {
            builder.HasIndex(x => new { x.Date, x.UserCreatedId }).IsUnique();
            builder.Property(x => x.Date).HasColumnType("date");
            builder.Property(x => x.UserCreatedId).IsRequired(true);
            builder
                .HasMany(x => x.Tasks)
                .WithOne(x => x.Timesheet)
                .HasForeignKey(x => x.TimesheetId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(x => x.Notes)
                .WithOne(x => x.Timesheet)
                .HasForeignKey(x => x.TimesheetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
