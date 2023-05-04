using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerApp.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTestUserToSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "UserCreatedId", "UserName", "UserUpdatedId" },
                values: new object[] { 1, "test@example.com", "Test User", "AQAAAAEAACcQAAAAEP9cuKzijGwu9rDTOEX6twF0kns/esm9KijT4K+wu4xxO4+IVafQGcyxnmMFc2gyXg==", null, "test_user", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
