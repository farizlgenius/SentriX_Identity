using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorOperatorRelation3 : Migration
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

            migrationBuilder.RenameColumn(
                name: "position_id",
                table: "Operators",
                newName: "Positionid");

            migrationBuilder.RenameColumn(
                name: "department_id",
                table: "Operators",
                newName: "Departmentid");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "Operators",
                newName: "Companyid");

            migrationBuilder.RenameIndex(
                name: "IX_Operators_position_id",
                table: "Operators",
                newName: "IX_Operators_Positionid");

            migrationBuilder.RenameIndex(
                name: "IX_Operators_department_id",
                table: "Operators",
                newName: "IX_Operators_Departmentid");

            migrationBuilder.RenameIndex(
                name: "IX_Operators_company_id",
                table: "Operators",
                newName: "IX_Operators_Companyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Companies_Companyid",
                table: "Operators",
                column: "Companyid",
                principalTable: "Companies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Departments_Departmentid",
                table: "Operators",
                column: "Departmentid",
                principalTable: "Departments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_Positions_Positionid",
                table: "Operators",
                column: "Positionid",
                principalTable: "Positions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Companies_Companyid",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Departments_Departmentid",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_Positions_Positionid",
                table: "Operators");

            migrationBuilder.RenameColumn(
                name: "Positionid",
                table: "Operators",
                newName: "position_id");

            migrationBuilder.RenameColumn(
                name: "Departmentid",
                table: "Operators",
                newName: "department_id");

            migrationBuilder.RenameColumn(
                name: "Companyid",
                table: "Operators",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_Operators_Positionid",
                table: "Operators",
                newName: "IX_Operators_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_Operators_Departmentid",
                table: "Operators",
                newName: "IX_Operators_department_id");

            migrationBuilder.RenameIndex(
                name: "IX_Operators_Companyid",
                table: "Operators",
                newName: "IX_Operators_company_id");

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
    }
}
