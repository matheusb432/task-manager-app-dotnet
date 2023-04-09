using TaskManagerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
            => builder.Property(e => e.Base64).IsUnicode(false);
    }
}
