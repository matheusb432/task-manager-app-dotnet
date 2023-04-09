using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class TimesheetConfiguration : BaseEntityConfiguration<Timesheet>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Timesheet> builder)
        {
            builder.HasMany(x => x.TaskItems).WithOne(x => x.Timesheet).HasForeignKey(x => x.TimesheetId);
            builder.HasMany(x => x.TimesheetNotes).WithOne(x => x.Timesheet).HasForeignKey(x => x.TimesheetId);
        }
    }
}