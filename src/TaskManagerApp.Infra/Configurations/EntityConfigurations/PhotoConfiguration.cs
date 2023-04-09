using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class PhotoConfiguration : BaseEntityConfiguration<Photo>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Photo> builder)
            => builder.Property(e => e.Base64).IsUnicode(false);
    }
}