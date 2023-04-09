using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class GoalConfiguration : BaseEntityConfiguration<Goal>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Goal> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(250).IsUnicode(false);
            builder.Property(e => e.Image).HasMaxLength(200).IsUnicode(false).IsRequired(false);
            builder.Property(e => e.Description).IsUnicode(false).IsRequired(false);
            builder.HasMany(e => e.GoalSteps).WithOne(gs => gs.Goal).HasForeignKey(gs => gs.GoalId);
            builder.HasMany(e => e.GoalTaskItems).WithOne(gti => gti.Goal).HasForeignKey(gti => gti.GoalId);
        }
    }
}