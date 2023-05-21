using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UserCreatedId = table.Column<int>(type: "int", nullable: true),
                    UserUpdatedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Role_Users_UserUpdatedId",
                        column: x => x.UserUpdatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UserCreatedId = table.Column<int>(type: "int", nullable: true),
                    UserUpdatedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserUpdatedId",
                        column: x => x.UserUpdatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt", "UserCreatedId", "UserUpdatedId" },
                values: new object[] { 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "UserName" },
                values: new object[] { "admin@example.com", "Admin User", "admin_user" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedAt", "RoleId", "UpdatedAt", "UserCreatedId", "UserId", "UserUpdatedId" },
                values: new object[] { 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserCreatedId",
                table: "Role",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserUpdatedId",
                table: "Role",
                column: "UserUpdatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserCreatedId",
                table: "UserRole",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserUpdatedId",
                table: "UserRole",
                column: "UserUpdatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "UserName" },
                values: new object[] { "test@example.com", "Test User", "test_user" });
        }
    }
}
