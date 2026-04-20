using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordRules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    len = table.Column<int>(type: "integer", nullable: false),
                    is_digit = table.Column<bool>(type: "boolean", nullable: false),
                    is_lower = table.Column<bool>(type: "boolean", nullable: false),
                    is_symbol = table.Column<bool>(type: "boolean", nullable: false),
                    is_upper = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRules", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WeakPasswords",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pattern = table.Column<string>(type: "text", nullable: false),
                    password_rule_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeakPasswords", x => x.id);
                    table.ForeignKey(
                        name: "FK_WeakPasswords_PasswordRules_password_rule_id",
                        column: x => x.password_rule_id,
                        principalTable: "PasswordRules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PasswordRules",
                columns: new[] { "id", "is_digit", "is_lower", "is_symbol", "is_upper", "len" },
                values: new object[] { 1, false, false, false, false, 4 });

            migrationBuilder.InsertData(
                table: "WeakPasswords",
                columns: new[] { "id", "password_rule_id", "pattern" },
                values: new object[,]
                {
                    { 1, 1, "P@ssw0rd" },
                    { 2, 1, "password" },
                    { 3, 1, "admin" },
                    { 4, 1, "123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeakPasswords_password_rule_id",
                table: "WeakPasswords",
                column: "password_rule_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeakPasswords");

            migrationBuilder.DropTable(
                name: "PasswordRules");
        }
    }
}
