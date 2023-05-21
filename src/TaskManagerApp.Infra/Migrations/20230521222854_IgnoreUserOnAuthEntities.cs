using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class IgnoreUserOnAuthEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_UserCreatedId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_UserUpdatedId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserCreatedId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserUpdatedId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserCreatedId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserUpdatedId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCreatedId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserUpdatedId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserCreatedId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserUpdatedId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserCreatedId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserUpdatedId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserUpdatedId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserUpdatedId",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserUpdatedId",
                table: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UserCreatedId", "UserUpdatedId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCreatedId",
                table: "Users",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserUpdatedId",
                table: "Users",
                column: "UserUpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserCreatedId",
                table: "UserRole",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserUpdatedId",
                table: "UserRole",
                column: "UserUpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserCreatedId",
                table: "Role",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserUpdatedId",
                table: "Role",
                column: "UserUpdatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_UserCreatedId",
                table: "Role",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_UserUpdatedId",
                table: "Role",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserCreatedId",
                table: "UserRole",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserUpdatedId",
                table: "UserRole",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserCreatedId",
                table: "Users",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserUpdatedId",
                table: "Users",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
