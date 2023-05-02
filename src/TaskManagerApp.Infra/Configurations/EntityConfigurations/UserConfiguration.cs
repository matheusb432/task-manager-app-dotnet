using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    public sealed class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.UserName).IsUnicode(false).HasMaxLength(100);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.PasswordHash).IsUnicode(false).HasMaxLength(100);
            // TODO clean
            //builder.HasMany(x => x.PresetTaskItems).WithOne(x => x.UserCreated).HasForeignKey(x => x.UserCreatedId);
            //builder.HasMany(x => x.Timesheets).WithOne(x => x.UserCreated).HasForeignKey(x => x.UserCreatedId);
            //builder.HasMany(x => x.Profiles).WithOne(x => x.UserCreated).HasForeignKey(x => x.UserCreatedId);
        }
    }
}