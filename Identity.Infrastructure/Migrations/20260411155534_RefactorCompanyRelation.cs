using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorCompanyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Locations_location_id",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "UserLocations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Companies_location_id",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "Companies");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "RefreshTokenAudits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Locations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Features",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Departments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Countries",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CompanyLocation",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLocation", x => new { x.company_id, x.location_id });
                    table.ForeignKey(
                        name: "FK_CompanyLocation_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyLocation_Locations_location_id",
                        column: x => x.location_id,
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    operator_id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    middlename = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    mobile = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    position_id = table.Column<int>(type: "integer", nullable: true),
                    department_id = table.Column<int>(type: "integer", nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.id);
                    table.ForeignKey(
                        name: "FK_Operators_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operators_Departments_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operators_Positions_position_id",
                        column: x => x.position_id,
                        principalTable: "Positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operators_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorLocations",
                columns: table => new
                {
                    operator_id = table.Column<int>(type: "integer", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorLocations", x => new { x.location_id, x.operator_id });
                    table.ForeignKey(
                        name: "FK_OperatorLocations_Locations_location_id",
                        column: x => x.location_id,
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorLocations_Operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "Operators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 1,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 2,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 3,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 4,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 5,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 6,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 7,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 8,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 9,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 10,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 11,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 12,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 13,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 14,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 15,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 16,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 17,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 18,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 19,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 20,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 21,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 22,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 23,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 24,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 25,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 26,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 27,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 28,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 29,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 30,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 31,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 32,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 33,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 34,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 35,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 36,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 37,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 38,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 39,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 40,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 41,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 42,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 43,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 44,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 45,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 46,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 47,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 48,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 49,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 50,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 51,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 52,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 53,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 54,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 55,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 56,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 57,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 58,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 59,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 60,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 61,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 62,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 63,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 64,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 65,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 66,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 67,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 68,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 69,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 70,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 71,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 72,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 73,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 74,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 75,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 76,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 77,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 78,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 79,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 80,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 81,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 82,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 83,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 84,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 85,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 86,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 87,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 88,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 89,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 90,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 91,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 92,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 93,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 94,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 95,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 96,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 97,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 98,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 99,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 100,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 101,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 102,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 103,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 104,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 105,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 106,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 107,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 108,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 109,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 110,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 111,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 112,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 113,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 114,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 115,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 116,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 117,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 118,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 119,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 120,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 121,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 122,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 123,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 124,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 125,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 126,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 127,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 128,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 129,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 130,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 131,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 132,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 133,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 134,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 135,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 136,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 137,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 138,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 139,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 140,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 141,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 142,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 143,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 144,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 145,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 146,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 147,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 148,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 149,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 150,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 151,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 152,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 153,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 154,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 155,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 156,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 157,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 158,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 159,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 160,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 161,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 162,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 163,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 164,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 165,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 166,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 167,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 168,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 169,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 170,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 171,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 172,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 173,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 174,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 175,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 176,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 177,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 1,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 2,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 3,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "id",
                keyValue: 4,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "id",
                keyValue: 1,
                column: "is_active",
                value: true);

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "id", "company_id", "department_id", "email", "firstname", "gender", "is_active", "lastname", "middlename", "mobile", "operator_id", "password", "position_id", "role_id", "title", "username" },
                values: new object[] { 1, null, null, "admin@sentrix.com", "Administrator", "Male", true, "SentriX", "", "", "ADMIN001", "100000.lG1/4V/VRPZsbhf/Zqc4xw==.6vYcf+wEMSgqcaNhoZEdM9PaPxx2ZUErZhQbeMxo5OY=", null, 1, "Mr", "admin" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 1,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 2,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 3,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: 4,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 1,
                column: "is_active",
                value: true);

            migrationBuilder.InsertData(
                table: "OperatorLocations",
                columns: new[] { "location_id", "operator_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLocation_location_id",
                table: "CompanyLocation",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorLocations_operator_id",
                table: "OperatorLocations",
                column: "operator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_company_id",
                table: "Operators",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_department_id",
                table: "Operators",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_position_id",
                table: "Operators",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_role_id",
                table: "Operators",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyLocation");

            migrationBuilder.DropTable(
                name: "OperatorLocations");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "RefreshTokenAudits");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    department_id = table.Column<int>(type: "integer", nullable: true),
                    position_id = table.Column<int>(type: "integer", nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    email = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    middlename = table.Column<string>(type: "text", nullable: false),
                    mobile = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Departments_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Positions_position_id",
                        column: x => x.position_id,
                        principalTable: "Positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLocations",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocations", x => new { x.location_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_UserLocations_Locations_location_id",
                        column: x => x.location_id,
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLocations_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "company_id", "department_id", "email", "firstname", "gender", "lastname", "middlename", "mobile", "password", "position_id", "role_id", "title", "user_id", "username" },
                values: new object[] { 1, null, null, "admin@sentrix.com", "Administrator", "Male", "SentriX", "", "", "100000.lG1/4V/VRPZsbhf/Zqc4xw==.6vYcf+wEMSgqcaNhoZEdM9PaPxx2ZUErZhQbeMxo5OY=", null, 1, "Mr", "ADMIN001", "admin" });

            migrationBuilder.InsertData(
                table: "UserLocations",
                columns: new[] { "location_id", "user_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_location_id",
                table: "Companies",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_user_id",
                table: "UserLocations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_company_id",
                table: "Users",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_department_id",
                table: "Users",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_position_id",
                table: "Users",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Locations_location_id",
                table: "Companies",
                column: "location_id",
                principalTable: "Locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
