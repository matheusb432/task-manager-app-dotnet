using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class TimesheetNoteConfiguration : BaseEntityConfiguration<TimesheetNote>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<TimesheetNote> builder)
        {
            builder.Property(x => x.Comment).IsUnicode(false);
            builder.HasOne(x => x.Timesheet).WithMany(x => x.Notes).HasForeignKey(x => x.TimesheetId);
        }
    }
}