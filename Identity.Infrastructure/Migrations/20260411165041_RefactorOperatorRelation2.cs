using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorOperatorRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Companies_company_id",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Departments_department_id",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Positions_position_id",
                table: "Operators");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Companies_company_id",
                table: "Operators",
                column: "company_id",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Departments_department_id",
                table: "Operators",
                column: "department_id",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Positions_position_id",
                table: "Operators",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Companies_company_id",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Departments_department_id",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Positions_position_id",
                table: "Operators");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Companies_company_id",
                table: "Operators",
                column: "company_id",
                principalTable: "Companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Departments_department_id",
                table: "Operators",
                column: "department_id",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Positions_position_id",
                table: "Operators",
                column: "position_id",
                principalTable: "Positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
