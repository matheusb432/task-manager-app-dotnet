using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCreatedAndUpdatedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresetTaskItems_Users_UserId",
                table: "PresetTaskItems"
            );

            migrationBuilder.DropForeignKey(name: "FK_Profiles_Users_UserId", table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Users_UserId",
                table: "Timesheets"
            );

            migrationBuilder.DropIndex(name: "IX_Timesheets_Date_UserId", table: "Timesheets");

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "Users",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "Users",
                type: "int",
                nullable: true
            );

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Timesheets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int"
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Timesheets",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime"
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "Timesheets",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "TimesheetNotes",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "TimesheetNotes",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "TaskItems",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "TaskItems",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "TaskItemNotes",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "TaskItemNotes",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "ProfileTypes",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "ProfileTypes",
                type: "int",
                nullable: true
            );

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Profiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int"
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "Profiles",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "ProfilePresetTaskItem",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "ProfilePresetTaskItem",
                type: "int",
                nullable: true
            );

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PresetTaskItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int"
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "PresetTaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "PresetTaskItems",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "GoalTaskItems",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "GoalTaskItems",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "GoalSteps",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "GoalSteps",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "Goals",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "Goals",
                type: "int",
                nullable: true
            );

            migrationBuilder.UpdateData(
                table: "ProfileTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null }
            );

            migrationBuilder.UpdateData(
                table: "ProfileTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null }
            );

            migrationBuilder.UpdateData(
                table: "ProfileTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null }
            );

            migrationBuilder.UpdateData(
                table: "ProfileTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null }
            );

            migrationBuilder.UpdateData(
                table: "ProfileTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCreatedId",
                table: "Users",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserUpdatedId",
                table: "Users",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_Date_UserCreatedId",
                table: "Timesheets",
                columns: new[] { "Date", "UserCreatedId" },
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_UserCreatedId",
                table: "Timesheets",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_UserUpdatedId",
                table: "Timesheets",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetNotes_UserCreatedId",
                table: "TimesheetNotes",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetNotes_UserUpdatedId",
                table: "TimesheetNotes",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserCreatedId",
                table: "TaskItems",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserUpdatedId",
                table: "TaskItems",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemNotes_UserCreatedId",
                table: "TaskItemNotes",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TaskItemNotes_UserUpdatedId",
                table: "TaskItemNotes",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypes_UserCreatedId",
                table: "ProfileTypes",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypes_UserUpdatedId",
                table: "ProfileTypes",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserCreatedId",
                table: "Profiles",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserUpdatedId",
                table: "Profiles",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePresetTaskItem_UserCreatedId",
                table: "ProfilePresetTaskItem",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePresetTaskItem_UserUpdatedId",
                table: "ProfilePresetTaskItem",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PresetTaskItems_UserCreatedId",
                table: "PresetTaskItems",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PresetTaskItems_UserUpdatedId",
                table: "PresetTaskItems",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GoalTaskItems_UserCreatedId",
                table: "GoalTaskItems",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GoalTaskItems_UserUpdatedId",
                table: "GoalTaskItems",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GoalSteps_UserCreatedId",
                table: "GoalSteps",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_GoalSteps_UserUpdatedId",
                table: "GoalSteps",
                column: "UserUpdatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserCreatedId",
                table: "Goals",
                column: "UserCreatedId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserUpdatedId",
                table: "Goals",
                column: "UserUpdatedId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserCreatedId",
                table: "Goals",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserUpdatedId",
                table: "Goals",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_GoalSteps_Users_UserCreatedId",
                table: "GoalSteps",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_GoalSteps_Users_UserUpdatedId",
                table: "GoalSteps",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_GoalTaskItems_Users_UserCreatedId",
                table: "GoalTaskItems",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_GoalTaskItems_Users_UserUpdatedId",
                table: "GoalTaskItems",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PresetTaskItems_Users_UserCreatedId",
                table: "PresetTaskItems",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PresetTaskItems_Users_UserId",
                table: "PresetTaskItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PresetTaskItems_Users_UserUpdatedId",
                table: "PresetTaskItems",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePresetTaskItem_Users_UserCreatedId",
                table: "ProfilePresetTaskItem",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePresetTaskItem_Users_UserUpdatedId",
                table: "ProfilePresetTaskItem",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserCreatedId",
                table: "Profiles",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserUpdatedId",
                table: "Profiles",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileTypes_Users_UserCreatedId",
                table: "ProfileTypes",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileTypes_Users_UserUpdatedId",
                table: "ProfileTypes",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItemNotes_Users_UserCreatedId",
                table: "TaskItemNotes",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItemNotes_Users_UserUpdatedId",
                table: "TaskItemNotes",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserCreatedId",
                table: "TaskItems",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserUpdatedId",
                table: "TaskItems",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TimesheetNotes_Users_UserCreatedId",
                table: "TimesheetNotes",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_TimesheetNotes_Users_UserUpdatedId",
                table: "TimesheetNotes",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Users_UserCreatedId",
                table: "Timesheets",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Users_UserId",
                table: "Timesheets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Users_UserUpdatedId",
                table: "Timesheets",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserCreatedId",
                table: "Users",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserUpdatedId",
                table: "Users",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Goals_Users_UserCreatedId", table: "Goals");

            migrationBuilder.DropForeignKey(name: "FK_Goals_Users_UserUpdatedId", table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalSteps_Users_UserCreatedId",
                table: "GoalSteps"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_GoalSteps_Users_UserUpdatedId",
                table: "GoalSteps"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_GoalTaskItems_Users_UserCreatedId",
                table: "GoalTaskItems"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_GoalTaskItems_Users_UserUpdatedId",
                table: "GoalTaskItems"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_PresetTaskItems_Users_UserCreatedId",
                table: "PresetTaskItems"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_PresetTaskItems_Users_UserId",
                table: "PresetTaskItems"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_PresetTaskItems_Users_UserUpdatedId",
                table: "PresetTaskItems"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePresetTaskItem_Users_UserCreatedId",
                table: "ProfilePresetTaskItem"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePresetTaskItem_Users_UserUpdatedId",
                table: "ProfilePresetTaskItem"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserCreatedId",
                table: "Profiles"
            );

            migrationBuilder.DropForeignKey(name: "FK_Profiles_Users_UserId", table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserUpdatedId",
                table: "Profiles"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileTypes_Users_UserCreatedId",
                table: "ProfileTypes"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileTypes_Users_UserUpdatedId",
                table: "ProfileTypes"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItemNotes_Users_UserCreatedId",
                table: "TaskItemNotes"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItemNotes_Users_UserUpdatedId",
                table: "TaskItemNotes"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserCreatedId",
                table: "TaskItems"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserUpdatedId",
                table: "TaskItems"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TimesheetNotes_Users_UserCreatedId",
                table: "TimesheetNotes"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_TimesheetNotes_Users_UserUpdatedId",
                table: "TimesheetNotes"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Users_UserCreatedId",
                table: "Timesheets"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Users_UserId",
                table: "Timesheets"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_Users_UserUpdatedId",
                table: "Timesheets"
            );

            migrationBuilder.DropForeignKey(name: "FK_Users_Users_UserCreatedId", table: "Users");

            migrationBuilder.DropForeignKey(name: "FK_Users_Users_UserUpdatedId", table: "Users");

            migrationBuilder.DropIndex(name: "IX_Users_UserCreatedId", table: "Users");

            migrationBuilder.DropIndex(name: "IX_Users_UserUpdatedId", table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_Date_UserCreatedId",
                table: "Timesheets"
            );

            migrationBuilder.DropIndex(name: "IX_Timesheets_UserCreatedId", table: "Timesheets");

            migrationBuilder.DropIndex(name: "IX_Timesheets_UserUpdatedId", table: "Timesheets");

            migrationBuilder.DropIndex(
                name: "IX_TimesheetNotes_UserCreatedId",
                table: "TimesheetNotes"
            );

            migrationBuilder.DropIndex(
                name: "IX_TimesheetNotes_UserUpdatedId",
                table: "TimesheetNotes"
            );

            migrationBuilder.DropIndex(name: "IX_TaskItems_UserCreatedId", table: "TaskItems");

            migrationBuilder.DropIndex(name: "IX_TaskItems_UserUpdatedId", table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItemNotes_UserCreatedId",
                table: "TaskItemNotes"
            );

            migrationBuilder.DropIndex(
                name: "IX_TaskItemNotes_UserUpdatedId",
                table: "TaskItemNotes"
            );

            migrationBuilder.DropIndex(
                name: "IX_ProfileTypes_UserCreatedId",
                table: "ProfileTypes"
            );

            migrationBuilder.DropIndex(
                name: "IX_ProfileTypes_UserUpdatedId",
                table: "ProfileTypes"
            );

            migrationBuilder.DropIndex(name: "IX_Profiles_UserCreatedId", table: "Profiles");

            migrationBuilder.DropIndex(name: "IX_Profiles_UserUpdatedId", table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_ProfilePresetTaskItem_UserCreatedId",
                table: "ProfilePresetTaskItem"
            );

            migrationBuilder.DropIndex(
                name: "IX_ProfilePresetTaskItem_UserUpdatedId",
                table: "ProfilePresetTaskItem"
            );

            migrationBuilder.DropIndex(
                name: "IX_PresetTaskItems_UserCreatedId",
                table: "PresetTaskItems"
            );

            migrationBuilder.DropIndex(
                name: "IX_PresetTaskItems_UserUpdatedId",
                table: "PresetTaskItems"
            );

            migrationBuilder.DropIndex(
                name: "IX_GoalTaskItems_UserCreatedId",
                table: "GoalTaskItems"
            );

            migrationBuilder.DropIndex(
                name: "IX_GoalTaskItems_UserUpdatedId",
                table: "GoalTaskItems"
            );

            migrationBuilder.DropIndex(name: "IX_GoalSteps_UserCreatedId", table: "GoalSteps");

            migrationBuilder.DropIndex(name: "IX_GoalSteps_UserUpdatedId", table: "GoalSteps");

            migrationBuilder.DropIndex(name: "IX_Goals_UserCreatedId", table: "Goals");

            migrationBuilder.DropIndex(name: "IX_Goals_UserUpdatedId", table: "Goals");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "Users");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "Users");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "Timesheets");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "Timesheets");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "TimesheetNotes");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "TimesheetNotes");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "TaskItems");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "TaskItems");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "TaskItemNotes");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "TaskItemNotes");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "ProfileTypes");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "ProfileTypes");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "Profiles");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "Profiles");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "ProfilePresetTaskItem");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "ProfilePresetTaskItem");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "PresetTaskItems");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "PresetTaskItems");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "GoalTaskItems");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "GoalTaskItems");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "GoalSteps");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "GoalSteps");

            migrationBuilder.DropColumn(name: "UserCreatedId", table: "Goals");

            migrationBuilder.DropColumn(name: "UserUpdatedId", table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Timesheets",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date"
            );

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PresetTaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_Date_UserId",
                table: "Timesheets",
                columns: new[] { "Date", "UserId" },
                unique: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_PresetTaskItems_Users_UserId",
                table: "PresetTaskItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_Users_UserId",
                table: "Timesheets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}
