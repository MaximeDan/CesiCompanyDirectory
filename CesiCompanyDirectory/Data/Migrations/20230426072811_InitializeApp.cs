using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CesiCompanyDirectory.Migrations
{
    /// <inheritdoc />
    public partial class InitializeApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_Service", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_Site", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    userName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordHash = table.Column<string>(type: "text", nullable: true),
                    securityStamp = table.Column<string>(type: "text", nullable: true),
                    concurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    phoneNumber = table.Column<string>(type: "text", nullable: true),
                    phoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleId = table.Column<string>(type: "text", nullable: false),
                    claimType = table.Column<string>(type: "text", nullable: true),
                    claimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_RoleClaims", x => x.id);
                    table.ForeignKey(
                        name: "fK_RoleClaims_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    phoneNumber = table.Column<string>(type: "text", nullable: false),
                    mobileNumber = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    picture = table.Column<string>(type: "text", nullable: true),
                    serviceId = table.Column<int>(type: "integer", nullable: true),
                    siteId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_Employee", x => x.id);
                    table.ForeignKey(
                        name: "fK_Employee_services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Service",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fK_Employee_sites_siteId",
                        column: x => x.siteId,
                        principalTable: "Site",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<string>(type: "text", nullable: false),
                    claimType = table.Column<string>(type: "text", nullable: true),
                    claimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_UserClaims", x => x.id);
                    table.ForeignKey(
                        name: "fK_UserClaims_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    loginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    providerDisplayName = table.Column<string>(type: "text", nullable: true),
                    userId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_UserLogins", x => new { x.loginProvider, x.providerKey });
                    table.ForeignKey(
                        name: "fK_UserLogins_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    userId = table.Column<string>(type: "text", nullable: false),
                    roleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_UserRoles", x => new { x.userId, x.roleId });
                    table.ForeignKey(
                        name: "fK_UserRoles_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fK_UserRoles_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    userId = table.Column<string>(type: "text", nullable: false),
                    loginProvider = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_UserTokens", x => new { x.userId, x.loginProvider, x.name });
                    table.ForeignKey(
                        name: "fK_UserTokens_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "iX_Employee_serviceId",
                table: "Employee",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "iX_Employee_siteId",
                table: "Employee",
                column: "siteId");

            migrationBuilder.CreateIndex(
                name: "iX_RoleClaims_roleId",
                table: "RoleClaims",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "normalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "iX_UserClaims_userId",
                table: "UserClaims",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "iX_UserLogins_userId",
                table: "UserLogins",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "iX_UserRoles_roleId",
                table: "UserRoles",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "normalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "normalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
