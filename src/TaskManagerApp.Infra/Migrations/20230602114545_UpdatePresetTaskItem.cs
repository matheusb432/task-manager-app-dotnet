using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePresetTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "PresetTaskItems",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Importance",
                table: "PresetTaskItems",
                type: "smallint",
                nullable: false,
                defaultValue: (short)1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "PresetTaskItems");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "PresetTaskItems");
        }
    }
}
