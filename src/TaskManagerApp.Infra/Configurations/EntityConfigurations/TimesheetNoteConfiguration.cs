using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class TimesheetNoteConfiguration : BaseEntityConfiguration<TimesheetNote>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<TimesheetNote> builder)
        {
            builder.Property(x => x.Comment).IsUnicode(false);
            builder.HasOne(x => x.Timesheet).WithMany(x => x.TimesheetNotes).HasForeignKey(x => x.TimesheetId);
        }
    }
}