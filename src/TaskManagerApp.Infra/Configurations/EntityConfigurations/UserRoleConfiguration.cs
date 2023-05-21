using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal sealed class UserRoleConfiguration : BaseEntityConfiguration<UserRole>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<UserRole> builder)
        {
            builder.Ignore(x => x.UserCreated);
            builder.Ignore(x => x.UserUpdated);
            builder.Ignore(x => x.UserCreatedId);
            builder.Ignore(x => x.UserUpdatedId);

            builder.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
        }
    }
}
