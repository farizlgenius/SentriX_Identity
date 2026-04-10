using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "Roles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 1,
                column: "location_id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_location_id",
                table: "Roles",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Locations_location_id",
                table: "Roles",
                column: "location_id",
                principalTable: "Locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Locations_location_id",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_location_id",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Roles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 1,
                column: "description",
                value: "System Administrator");
        }
    }
}
