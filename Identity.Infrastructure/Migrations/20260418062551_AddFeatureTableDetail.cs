using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFeatureTableDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "location");

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "alert");

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "id", "is_active", "name" },
                values: new object[,]
                {
                    { 5, true, "operator" },
                    { 6, true, "device" },
                    { 7, true, "control" },
                    { 8, true, "monitor" },
                    { 9, true, "monitorgroup" },
                    { 10, true, "acr" },
                    { 11, true, "user" },
                    { 12, true, "group" },
                    { 13, true, "area" },
                    { 14, true, "time" },
                    { 15, true, "trigger" },
                    { 16, true, "map" },
                    { 17, true, "report" },
                    { 18, true, "setting" },
                    { 19, true, "tools" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "id", "feature_id", "is_active", "is_created", "is_deleted", "is_enabled", "is_updated", "role_id" },
                values: new object[,]
                {
                    { 5, 5, true, true, true, true, true, 1 },
                    { 6, 6, true, true, true, true, true, 1 },
                    { 7, 7, true, true, true, true, true, 1 },
                    { 8, 8, true, true, true, true, true, 1 },
                    { 9, 9, true, true, true, true, true, 1 },
                    { 10, 10, true, true, true, true, true, 1 },
                    { 11, 11, true, true, true, true, true, 1 },
                    { 12, 12, true, true, true, true, true, 1 },
                    { 13, 13, true, true, true, true, true, 1 },
                    { 14, 14, true, true, true, true, true, 1 },
                    { 15, 15, true, true, true, true, true, 1 },
                    { 16, 16, true, true, true, true, true, 1 },
                    { 17, 17, true, true, true, true, true, 1 },
                    { 18, 18, true, true, true, true, true, 1 },
                    { 19, 19, true, true, true, true, true, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "reports");

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "settings");
        }
    }
}
