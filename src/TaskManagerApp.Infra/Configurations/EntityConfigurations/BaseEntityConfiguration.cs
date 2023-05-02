using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("getdate()").HasColumnType("datetime");
            builder.Property(x => x.UserCreatedId).IsRequired(false);
            builder.Property(x => x.UserUpdatedId).IsRequired(false);
            builder.HasOne(x => x.UserCreated).WithMany().HasForeignKey(x => x.UserCreatedId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.UserUpdated).WithMany().HasForeignKey(x => x.UserUpdatedId).OnDelete(DeleteBehavior.NoAction);

            ConfigureOtherProperties(builder);
        }

        public abstract void ConfigureOtherProperties(EntityTypeBuilder<T> builder);
    }
}