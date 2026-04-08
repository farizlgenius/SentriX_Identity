using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_locationid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_locationid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "locationid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "city",
                table: "Locations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "locationid",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "id",
                keyValue: 1,
                column: "city",
                value: "SentriX");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "location_id", "locationid" },
                values: new object[] { 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Users_locationid",
                table: "Users",
                column: "locationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_locationid",
                table: "Users",
                column: "locationid",
                principalTable: "Locations",
                principalColumn: "id");
        }
    }
}
