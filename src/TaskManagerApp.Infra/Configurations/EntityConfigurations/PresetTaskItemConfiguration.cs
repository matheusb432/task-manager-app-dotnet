using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class PresetTaskItemConfiguration : BaseEntityConfiguration<PresetTaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<PresetTaskItem> builder)
        {
            builder.Property(x => x.Title).IsUnicode(false).HasMaxLength(250);
            builder.HasOne(x => x.User).WithMany(x => x.PresetTaskItems).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.ProfilePresetTaskItems).WithOne(x => x.PresetTaskItem).HasForeignKey(x => x.PresetTaskItemId);
        }
    }
}