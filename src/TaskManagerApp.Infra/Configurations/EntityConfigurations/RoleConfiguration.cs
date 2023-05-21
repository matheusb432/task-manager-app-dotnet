using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class RoleConfiguration : BaseEntityConfiguration<Role>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Role> builder)
        {
            builder.Ignore(x => x.UserCreated);
            builder.Ignore(x => x.UserUpdated);
            builder.Ignore(x => x.UserCreatedId);
            builder.Ignore(x => x.UserUpdatedId);

            builder.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
            builder.HasMany(e => e.UserRoles).WithOne(gs => gs.Role).HasForeignKey(gs => gs.RoleId);
        }
    }
}
