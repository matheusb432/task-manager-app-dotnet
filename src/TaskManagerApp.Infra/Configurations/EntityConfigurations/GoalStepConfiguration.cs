using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class GoalStepConfiguration : BaseEntityConfiguration<GoalStep>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<GoalStep> builder)
        {
            builder.Property(x => x.Title).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Finished).HasDefaultValue(false);
            builder.HasOne(x => x.Goal).WithMany(x => x.GoalSteps).HasForeignKey(x => x.GoalId);
        }
    }
}