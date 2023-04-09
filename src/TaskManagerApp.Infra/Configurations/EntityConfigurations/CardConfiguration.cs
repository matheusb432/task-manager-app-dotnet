using TaskManagerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.Status).HasMaxLength(100).IsUnicode(false).IsRequired(false);
            builder.HasOne(e => e.Photo).WithOne(p => p.Card).HasForeignKey<Card>(c => c.PhotoId);
        }
    }
}
