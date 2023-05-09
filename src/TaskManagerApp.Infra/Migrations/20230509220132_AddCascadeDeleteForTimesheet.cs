using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeleteForTimesheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Timesheets_TimesheetId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TimesheetNotes_Timesheets_TimesheetId",
                table: "TimesheetNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Timesheets_TimesheetId",
                table: "TaskItems",
                column: "TimesheetId",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimesheetNotes_Timesheets_TimesheetId",
                table: "TimesheetNotes",
                column: "TimesheetId",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Timesheets_TimesheetId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TimesheetNotes_Timesheets_TimesheetId",
                table: "TimesheetNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Timesheets_TimesheetId",
                table: "TaskItems",
                column: "TimesheetId",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimesheetNotes_Timesheets_TimesheetId",
                table: "TimesheetNotes",
                column: "TimesheetId",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
