using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class TaskItemConfiguration : BaseEntityConfiguration<TaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<TaskItem> builder)
        {
            builder.Property(x => x.Title).IsUnicode(false).HasMaxLength(250);
            builder.HasOne(x => x.Timesheet).WithMany(x => x.TaskItems).HasForeignKey(x => x.TimesheetId);
            builder.HasMany(x => x.TaskItemNotes).WithOne(x => x.TaskItem).HasForeignKey(x => x.TaskItemId);
            builder.HasMany(x => x.GoalTaskItems).WithOne(x => x.TaskItem).HasForeignKey(x => x.TaskItemId);
        }
    }
}