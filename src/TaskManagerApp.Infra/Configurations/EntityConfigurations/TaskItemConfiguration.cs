using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class TaskItemConfiguration : BaseEntityConfiguration<TaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<TaskItem> builder)
        {
            builder.Property(x => x.Title).IsRequired(false).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Comment).IsUnicode(false).IsRequired(false);
            builder.Property(x => x.Time).IsRequired(false);
            builder.Property(x => x.Rating).IsRequired(false);
            builder
                .HasOne(x => x.Timesheet)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TimesheetId);
        }
    }
}
