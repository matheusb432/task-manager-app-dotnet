using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class GoalTaskItemConfiguration : BaseEntityConfiguration<GoalTaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<GoalTaskItem> builder)
        {
            builder.Property(x => x.GoalId).IsRequired();
            builder.Property(x => x.TaskItemId).IsRequired();
            builder.HasOne(x => x.Goal).WithMany(x => x.GoalTaskItems).HasForeignKey(x => x.GoalId);
            builder.HasOne(x => x.TaskItem).WithMany(x => x.GoalTaskItems).HasForeignKey(x => x.TaskItemId);
        }
    }
}