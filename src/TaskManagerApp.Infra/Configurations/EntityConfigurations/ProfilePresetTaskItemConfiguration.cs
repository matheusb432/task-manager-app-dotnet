﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Infra.Configurations.EntityConfigurations
{
    internal class ProfilePresetTaskItemConfiguration : BaseEntityConfiguration<ProfilePresetTaskItem>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<ProfilePresetTaskItem> builder)
        {
            builder.HasOne(x => x.Profile)
                .WithMany(x => x.ProfilePresetTaskItems)
                .HasForeignKey(x => x.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.PresetTaskItem)
                .WithMany(x => x.ProfilePresetTaskItems)
                .HasForeignKey(x => x.PresetTaskItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}