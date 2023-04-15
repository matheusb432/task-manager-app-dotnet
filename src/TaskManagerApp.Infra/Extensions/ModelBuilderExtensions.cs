﻿using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Utils;

namespace TaskManagerApp.Infra.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileType>()
                .HasData(
                  new ProfileType
                  {
                      Id = 1,
                      Name = "Weekdays",
                      Type = ProfileTypes.Weekday,
                      CreatedAt = new DateTime(2023, 04, 15),
                      UpdatedAt = new DateTime(2023, 04, 15),
                  },
                  new ProfileType
                  {
                      Id = 2,
                      Name = "Weekends",
                      Type = ProfileTypes.Weekend,
                      CreatedAt = new DateTime(2023, 04, 15),
                      UpdatedAt = new DateTime(2023, 04, 15),
                  },
                  new ProfileType
                  {
                      Id = 3,
                      Name = "Holidays",
                      Type = ProfileTypes.Holiday,
                      CreatedAt = new DateTime(2023, 04, 15),
                      UpdatedAt = new DateTime(2023, 04, 15),
                  },
                  new ProfileType
                  {
                      Id = 4,
                      Name = "January 2023",
                      Type = ProfileTypes.Custom,
                      DateRangeStart = new DateTime(2023, 1, 1),
                      DateRangeEnd = new DateTime(2023, 2, 1),
                      CreatedAt = new DateTime(2023, 04, 15),
                      UpdatedAt = new DateTime(2023, 04, 15),
                  },
                  new ProfileType
                  {
                      Id = 5,
                      Name = "2022",
                      Type = ProfileTypes.Custom,
                      DateRangeStart = new DateTime(2022, 1, 1),
                      DateRangeEnd = new DateTime(2022, 12, 31),
                      CreatedAt = new DateTime(2023, 04, 15),
                      UpdatedAt = new DateTime(2023, 04, 15),
                  }
            );
        }
    }
}