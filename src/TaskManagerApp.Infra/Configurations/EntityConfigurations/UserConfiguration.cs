using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    public sealed class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<User> builder)
        {
            builder.Ignore(x => x.UserCreated);
            builder.Ignore(x => x.UserUpdated);
            builder.Ignore(x => x.UserCreatedId);
            builder.Ignore(x => x.UserUpdatedId);

            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.UserName).IsUnicode(false).HasMaxLength(100);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.PasswordHash).IsUnicode(false).HasMaxLength(100);
            builder.HasMany(e => e.UserRoles).WithOne(gs => gs.User).HasForeignKey(gs => gs.UserId);
        }
    }
}
