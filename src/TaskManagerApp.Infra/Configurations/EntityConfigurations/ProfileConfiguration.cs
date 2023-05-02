using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class ProfileConfiguration : BaseEntityConfiguration<Profile>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(x => x.Name).IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.TimeTarget).IsRequired(false);
            builder.Property(x => x.TasksTarget).IsRequired(false);
            builder.Property(x => x.Priority).HasDefaultValue(1);
            builder.Property(x => x.UserCreatedId).IsRequired(true);
            builder.HasOne(x => x.ProfileType).WithMany(x => x.Profiles).HasForeignKey(x => x.ProfileTypeId);
            builder.HasMany(x => x.ProfilePresetTaskItems).WithOne(x => x.Profile).HasForeignKey(x => x.ProfileId);
        }
    }
}