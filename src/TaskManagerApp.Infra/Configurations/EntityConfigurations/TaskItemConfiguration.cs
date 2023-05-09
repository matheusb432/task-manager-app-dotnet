using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class TaskItemConfiguration : BaseEntityConfiguration<TaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<TaskItem> builder)
        {
            builder.Property(x => x.Title).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Importance).HasDefaultValue(1);
            builder.Property(x => x.Comment).IsUnicode(false);
            builder.HasOne(x => x.Timesheet).WithMany(x => x.TaskItems).HasForeignKey(x => x.TimesheetId);
            builder.HasMany(x => x.GoalTaskItems).WithOne(x => x.TaskItem).HasForeignKey(x => x.TaskItemId);
        }
    }
}