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
            builder.Property(x => x.Created).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Updated).HasDefaultValueSql("getdate()");

            ConfigureOtherProperties(builder);
        }

        public abstract void ConfigureOtherProperties(EntityTypeBuilder<T> builder);
    }
}