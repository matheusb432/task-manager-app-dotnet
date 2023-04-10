using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class ProfileTypeConfiguration : BaseEntityConfiguration<ProfileType>
    {
        public override void ConfigureOtherProperties(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProfileType> builder)
        {
            builder.Property(x => x.Name).IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.Type).IsUnicode(false).HasMaxLength(50);
        }
    }
}