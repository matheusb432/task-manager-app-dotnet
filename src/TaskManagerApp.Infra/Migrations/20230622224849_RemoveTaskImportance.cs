using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTaskImportance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importance",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "PresetTaskItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Importance",
                table: "TaskItems",
                type: "smallint",
                nullable: false,
                defaultValue: (short)1);

            migrationBuilder.AddColumn<short>(
                name: "Importance",
                table: "PresetTaskItems",
                type: "smallint",
                nullable: false,
                defaultValue: (short)1);
        }
    }
}
