﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagerApp.Infra;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    [DbContext(typeof(TaskManagerContext))]
    [Migration("20230502194210_AddUserCreatedAndUpdatedIds")]
    partial class AddUserCreatedAndUpdatedIds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.GoalStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Finished")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("GoalSteps");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.GoalTaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.Property<int>("TaskItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("TaskItemId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("GoalTaskItems");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.PresetTaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<short?>("Time")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("PresetTaskItems");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<short>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)1);

                    b.Property<int>("ProfileTypeId")
                        .HasColumnType("int");

                    b.Property<short?>("TasksTarget")
                        .HasColumnType("smallint");

                    b.Property<short?>("TimeTarget")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileTypeId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.ProfilePresetTaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("PresetTaskItemId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PresetTaskItemId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("ProfilePresetTaskItem");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.ProfileType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DateRangeEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateRangeStart")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("ProfileTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Weekdays",
                            Type = "weekday",
                            UpdatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Weekends",
                            Type = "weekend",
                            UpdatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Holidays",
                            Type = "holiday",
                            UpdatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRangeEnd = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRangeStart = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "January 2023",
                            Type = "custom",
                            UpdatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRangeEnd = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateRangeStart = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "2022",
                            Type = "custom",
                            UpdatedAt = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<short>("Importance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)1);

                    b.Property<short?>("Rating")
                        .HasColumnType("smallint");

                    b.Property<short?>("Time")
                        .HasColumnType("smallint");

                    b.Property<int>("TimesheetId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TimesheetId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("TaskItems");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.TaskItemNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("TaskItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskItemId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("TaskItemNotes");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<bool?>("Finished")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserUpdatedId");

                    b.HasIndex("Date", "UserCreatedId")
                        .IsUnique();

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.TimesheetNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("TimesheetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TimesheetId");

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("TimesheetNotes");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UserUpdatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserCreatedId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.HasIndex("UserUpdatedId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Goal", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.GoalStep", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.Goal", "Goal")
                        .WithMany("GoalSteps")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Goal");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.GoalTaskItem", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.Goal", "Goal")
                        .WithMany("GoalTaskItems")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.TaskItem", "TaskItem")
                        .WithMany("GoalTaskItems")
                        .HasForeignKey("TaskItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Goal");

                    b.Navigation("TaskItem");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.PresetTaskItem", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", null)
                        .WithMany("PresetTaskItems")
                        .HasForeignKey("UserId");

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Profile", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.ProfileType", "ProfileType")
                        .WithMany("Profiles")
                        .HasForeignKey("ProfileTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", null)
                        .WithMany("Profiles")
                        .HasForeignKey("UserId");

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ProfileType");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.ProfilePresetTaskItem", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.PresetTaskItem", "PresetTaskItem")
                        .WithMany("ProfilePresetTaskItems")
                        .HasForeignKey("PresetTaskItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.Profile", "Profile")
                        .WithMany("ProfilePresetTaskItems")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("PresetTaskItem");

                    b.Navigation("Profile");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.ProfileType", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.TaskItem", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.Timesheet", "Timesheet")
                        .WithMany("TaskItems")
                        .HasForeignKey("TimesheetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Timesheet");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.TaskItemNote", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.TaskItem", "TaskItem")
                        .WithMany("TaskItemNotes")
                        .HasForeignKey("TaskItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("TaskItem");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Timesheet", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", null)
                        .WithMany("Timesheets")
                        .HasForeignKey("UserId");

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.TimesheetNote", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.Timesheet", "Timesheet")
                        .WithMany("TimesheetNotes")
                        .HasForeignKey("TimesheetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Timesheet");

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.User", b =>
                {
                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaskManagerApp.Domain.Models.User", "UserUpdated")
                        .WithMany()
                        .HasForeignKey("UserUpdatedId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserCreated");

                    b.Navigation("UserUpdated");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Goal", b =>
                {
                    b.Navigation("GoalSteps");

                    b.Navigation("GoalTaskItems");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.PresetTaskItem", b =>
                {
                    b.Navigation("ProfilePresetTaskItems");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Profile", b =>
                {
                    b.Navigation("ProfilePresetTaskItems");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.ProfileType", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.TaskItem", b =>
                {
                    b.Navigation("GoalTaskItems");

                    b.Navigation("TaskItemNotes");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.Timesheet", b =>
                {
                    b.Navigation("TaskItems");

                    b.Navigation("TimesheetNotes");
                });

            modelBuilder.Entity("TaskManagerApp.Domain.Models.User", b =>
                {
                    b.Navigation("PresetTaskItems");

                    b.Navigation("Profiles");

                    b.Navigation("Timesheets");
                });
#pragma warning restore 612, 618
        }
    }
}
