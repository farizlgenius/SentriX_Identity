using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiKeys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "text", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokenAudits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    hashed_refresh_token = table.Column<string>(type: "text", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    expired_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokenAudits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locations_Country_country_id",
                        column: x => x.country_id,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    feature_id = table.Column<int>(type: "integer", nullable: false),
                    is_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    is_created = table.Column<bool>(type: "boolean", nullable: false),
                    is_updated = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Permissions_Features_feature_id",
                        column: x => x.feature_id,
                        principalTable: "Features",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    postal_code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Companies_Locations_location_id",
                        column: x => x.location_id,
                        principalTable: "Locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    department_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    middlename = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    mobile = table.Column<string>(type: "text", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false),
                    locationid = table.Column<int>(type: "integer", nullable: true),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    position_id = table.Column<int>(type: "integer", nullable: true),
                    department_id = table.Column<int>(type: "integer", nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
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
                        name: "FK_Users_Locations_locationid",
                        column: x => x.locationid,
                        principalTable: "Locations",
                        principalColumn: "id");
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
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false)
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
                table: "Country",
                columns: new[] { "id", "code", "name" },
                values: new object[,]
                {
                    { 1, "AD", "Andorra" },
                    { 2, "AE", "United Arab Emirates" },
                    { 3, "AF", "Afghanistan" },
                    { 4, "AG", "Antigua and Barbuda" },
                    { 5, "AI", "Anguilla" },
                    { 6, "AL", "Albania" },
                    { 7, "AM", "Armenia" },
                    { 8, "AN", "Netherlands Antilles" },
                    { 9, "AO", "Angola" },
                    { 10, "AQ", "Antarctica" },
                    { 11, "AR", "Argentina" },
                    { 12, "AS", "American Samoa" },
                    { 13, "AT", "Austria" },
                    { 14, "AU", "Australia" },
                    { 15, "AW", "Aruba" },
                    { 16, "AZ", "Azerbaijan" },
                    { 17, "BA", "Bosnia and Herzegovina" },
                    { 18, "BB", "Barbados" },
                    { 19, "BD", "Bangladesh" },
                    { 20, "BE", "Belgium" },
                    { 21, "BF", "Burkina Faso" },
                    { 22, "BG", "Bulgaria" },
                    { 23, "BH", "Bahrain" },
                    { 24, "BI", "Burundi" },
                    { 25, "BJ", "Benin" },
                    { 26, "BM", "Bermuda" },
                    { 27, "BN", "Brunei" },
                    { 28, "BO", "Bolivia" },
                    { 29, "BR", "Brazil" },
                    { 30, "BS", "Bahamas" },
                    { 31, "BT", "Bhutan" },
                    { 32, "BV", "Bouvet Island" },
                    { 33, "BW", "Botswana" },
                    { 34, "BY", "Belarus" },
                    { 35, "BZ", "Belize" },
                    { 36, "CA", "Canada" },
                    { 37, "CC", "Cocos (Keeling) Islands" },
                    { 38, "CD", "Congo (DRC)" },
                    { 39, "CF", "Central African Republic" },
                    { 40, "CG", "Congo (Republic)" },
                    { 41, "CH", "Switzerland" },
                    { 42, "CI", "Côte d'Ivoire" },
                    { 43, "CK", "Cook Islands" },
                    { 44, "CL", "Chile" },
                    { 45, "CM", "Cameroon" },
                    { 46, "CN", "China" },
                    { 47, "CO", "Colombia" },
                    { 48, "CR", "Costa Rica" },
                    { 49, "CU", "Cuba" },
                    { 50, "CV", "Cape Verde" },
                    { 51, "CX", "Christmas Island" },
                    { 52, "CY", "Cyprus" },
                    { 53, "CZ", "Czech Republic" },
                    { 54, "DE", "Germany" },
                    { 55, "DJ", "Djibouti" },
                    { 56, "DK", "Denmark" },
                    { 57, "DM", "Dominica" },
                    { 58, "DO", "Dominican Republic" },
                    { 59, "DZ", "Algeria" },
                    { 60, "EC", "Ecuador" },
                    { 61, "EE", "Estonia" },
                    { 62, "EG", "Egypt" },
                    { 63, "EH", "Western Sahara" },
                    { 64, "ER", "Eritrea" },
                    { 65, "ES", "Spain" },
                    { 66, "ET", "Ethiopia" },
                    { 67, "FI", "Finland" },
                    { 68, "FJ", "Fiji" },
                    { 69, "FK", "Falkland Islands" },
                    { 70, "FM", "Micronesia" },
                    { 71, "FO", "Faroe Islands" },
                    { 72, "FR", "France" },
                    { 73, "GA", "Gabon" },
                    { 74, "GB", "United Kingdom" },
                    { 75, "GD", "Grenada" },
                    { 76, "GE", "Georgia" },
                    { 77, "GF", "French Guiana" },
                    { 78, "GG", "Guernsey" },
                    { 79, "GH", "Ghana" },
                    { 80, "GI", "Gibraltar" },
                    { 81, "GL", "Greenland" },
                    { 82, "GM", "Gambia" },
                    { 83, "GN", "Guinea" },
                    { 84, "GP", "Guadeloupe" },
                    { 85, "GQ", "Equatorial Guinea" },
                    { 86, "GR", "Greece" },
                    { 87, "GT", "Guatemala" },
                    { 88, "GU", "Guam" },
                    { 89, "GW", "Guinea-Bissau" },
                    { 90, "GY", "Guyana" },
                    { 91, "HK", "Hong Kong" },
                    { 92, "HN", "Honduras" },
                    { 93, "HR", "Croatia" },
                    { 94, "HT", "Haiti" },
                    { 95, "HU", "Hungary" },
                    { 96, "ID", "Indonesia" },
                    { 97, "IE", "Ireland" },
                    { 98, "IL", "Israel" },
                    { 99, "IN", "India" },
                    { 100, "IQ", "Iraq" },
                    { 101, "IR", "Iran" },
                    { 102, "IS", "Iceland" },
                    { 103, "IT", "Italy" },
                    { 104, "JM", "Jamaica" },
                    { 105, "JO", "Jordan" },
                    { 106, "JP", "Japan" },
                    { 107, "KE", "Kenya" },
                    { 108, "KH", "Cambodia" },
                    { 109, "KR", "South Korea" },
                    { 110, "KW", "Kuwait" },
                    { 111, "KZ", "Kazakhstan" },
                    { 112, "LA", "Laos" },
                    { 113, "LB", "Lebanon" },
                    { 114, "LK", "Sri Lanka" },
                    { 115, "LR", "Liberia" },
                    { 116, "LS", "Lesotho" },
                    { 117, "LT", "Lithuania" },
                    { 118, "LU", "Luxembourg" },
                    { 119, "LV", "Latvia" },
                    { 120, "LY", "Libya" },
                    { 121, "MA", "Morocco" },
                    { 122, "MC", "Monaco" },
                    { 123, "MD", "Moldova" },
                    { 124, "ME", "Montenegro" },
                    { 125, "MG", "Madagascar" },
                    { 126, "MV", "Maldives" },
                    { 127, "MX", "Mexico" },
                    { 128, "MY", "Malaysia" },
                    { 129, "MZ", "Mozambique" },
                    { 130, "NA", "Namibia" },
                    { 131, "NG", "Nigeria" },
                    { 132, "NL", "Netherlands" },
                    { 133, "NO", "Norway" },
                    { 134, "NP", "Nepal" },
                    { 135, "NZ", "New Zealand" },
                    { 136, "OM", "Oman" },
                    { 137, "PA", "Panama" },
                    { 138, "PE", "Peru" },
                    { 139, "PH", "Philippines" },
                    { 140, "PK", "Pakistan" },
                    { 141, "PL", "Poland" },
                    { 142, "PT", "Portugal" },
                    { 143, "QA", "Qatar" },
                    { 144, "RO", "Romania" },
                    { 145, "RS", "Serbia" },
                    { 146, "RU", "Russia" },
                    { 147, "RW", "Rwanda" },
                    { 148, "SA", "Saudi Arabia" },
                    { 149, "SE", "Sweden" },
                    { 150, "SG", "Singapore" },
                    { 151, "SI", "Slovenia" },
                    { 152, "SK", "Slovakia" },
                    { 153, "SN", "Senegal" },
                    { 154, "SO", "Somalia" },
                    { 155, "SR", "Suriname" },
                    { 156, "SV", "El Salvador" },
                    { 157, "SY", "Syria" },
                    { 158, "TH", "Thailand" },
                    { 159, "TJ", "Tajikistan" },
                    { 160, "TL", "Timor-Leste" },
                    { 161, "TM", "Turkmenistan" },
                    { 162, "TN", "Tunisia" },
                    { 163, "TR", "Turkey" },
                    { 164, "TW", "Taiwan" },
                    { 165, "TZ", "Tanzania" },
                    { 166, "UA", "Ukraine" },
                    { 167, "UG", "Uganda" },
                    { 168, "US", "United States" },
                    { 169, "UY", "Uruguay" },
                    { 170, "UZ", "Uzbekistan" },
                    { 171, "VA", "Vatican City" },
                    { 172, "VE", "Venezuela" },
                    { 173, "VN", "Vietnam" },
                    { 174, "YE", "Yemen" },
                    { 175, "ZA", "South Africa" },
                    { 176, "ZM", "Zambia" },
                    { 177, "ZW", "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "dashboard" },
                    { 2, "events" },
                    { 3, "reports" },
                    { 4, "settings" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 1, "System Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "id", "city", "country_id", "description", "name" },
                values: new object[] { 1, "SentriX", 158, "Default Location", "Main" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "id", "feature_id", "is_created", "is_deleted", "is_enabled", "is_updated", "role_id" },
                values: new object[,]
                {
                    { 1, 1, true, true, true, true, 1 },
                    { 2, 2, true, true, true, true, 1 },
                    { 3, 3, true, true, true, true, 1 },
                    { 4, 4, true, true, true, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "company_id", "department_id", "email", "firstname", "gender", "lastname", "location_id", "locationid", "middlename", "mobile", "password", "position_id", "role_id", "title", "user_id", "username" },
                values: new object[] { 1, null, null, "admin@sentrix.com", "Administrator", "Male", "SentriX", 0, null, "", "", "100000.lG1/4V/VRPZsbhf/Zqc4xw==.6vYcf+wEMSgqcaNhoZEdM9PaPxx2ZUErZhQbeMxo5OY=", null, 1, "Mr", "ADMIN001", "admin" });

            migrationBuilder.InsertData(
                table: "UserLocations",
                columns: new[] { "location_id", "user_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_location_id",
                table: "Companies",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_company_id",
                table: "Departments",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_country_id",
                table: "Locations",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_feature_id",
                table: "Permissions",
                column: "feature_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_role_id",
                table: "Permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_department_id",
                table: "Positions",
                column: "department_id");

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
                name: "IX_Users_locationid",
                table: "Users",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_position_id",
                table: "Users",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKeys");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RefreshTokenAudits");

            migrationBuilder.DropTable(
                name: "UserLocations");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
