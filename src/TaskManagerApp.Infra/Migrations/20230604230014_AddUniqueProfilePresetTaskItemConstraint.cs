using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueProfilePresetTaskItemConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfilePresetTaskItem_ProfileId",
                table: "ProfilePresetTaskItem");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePresetTaskItem_ProfileId_PresetTaskItemId",
                table: "ProfilePresetTaskItem",
                columns: new[] { "ProfileId", "PresetTaskItemId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfilePresetTaskItem_ProfileId_PresetTaskItemId",
                table: "ProfilePresetTaskItem");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePresetTaskItem_ProfileId",
                table: "ProfilePresetTaskItem",
                column: "ProfileId");
        }
    }
}
