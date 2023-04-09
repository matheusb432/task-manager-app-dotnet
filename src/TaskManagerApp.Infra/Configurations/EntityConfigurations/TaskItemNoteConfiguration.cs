using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class TaskItemNoteConfiguration : BaseEntityConfiguration<TaskItemNote>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<TaskItemNote> builder)
        {
            builder.Property(x => x.Comment).IsUnicode(false);
            builder.HasOne(x => x.TaskItem).WithMany(x => x.TaskItemNotes).HasForeignKey(x => x.TaskItemId);
        }
    }
}