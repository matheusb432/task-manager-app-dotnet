using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class PresetTaskItemConfiguration : BaseEntityConfiguration<PresetTaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<PresetTaskItem> builder)
        {
            builder.Property(x => x.Title).IsUnicode(false).HasMaxLength(250);
            builder.HasOne(x => x.User).WithMany(x => x.PresetTaskItems).HasForeignKey(x => x.UserId);
            // TODO validate if ok on optional FK
            builder.HasOne(x => x.Profile).WithMany(x => x.PresetTaskItems).HasForeignKey(x => x.ProfileId);
        }
    }
}