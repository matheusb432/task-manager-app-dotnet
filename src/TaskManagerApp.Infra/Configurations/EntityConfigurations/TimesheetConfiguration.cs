using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class TimesheetConfiguration : BaseEntityConfiguration<Timesheet>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Timesheet> builder)
        {
            builder.HasIndex(x => new { x.Date, x.UserId }).IsUnique();
            builder.Property(x => x.Date).HasColumnType("datetime");
            builder.HasMany(x => x.TaskItems).WithOne(x => x.Timesheet).HasForeignKey(x => x.TimesheetId);
            builder.HasMany(x => x.TimesheetNotes).WithOne(x => x.Timesheet).HasForeignKey(x => x.TimesheetId);
        }
    }
}