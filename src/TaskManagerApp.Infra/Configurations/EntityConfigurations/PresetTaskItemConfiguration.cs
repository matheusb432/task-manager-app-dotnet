using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class PresetTaskItemConfiguration : BaseEntityConfiguration<PresetTaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<PresetTaskItem> builder)
        {
            builder.Property(x => x.Title).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.UserCreatedId).IsRequired(true);
            builder.Property(x => x.Importance).HasDefaultValue(1);
            builder.Property(x => x.Comment).IsUnicode(false).IsRequired(false);
            builder
                .HasMany(x => x.ProfilePresetTaskItems)
                .WithOne(x => x.PresetTaskItem)
                .HasForeignKey(x => x.PresetTaskItemId);
            builder
                .HasMany(x => x.TaskItems)
                .WithOne(x => x.PresetTaskItem)
                .HasForeignKey(x => x.PresetTaskItemId);
        }
    }
}
