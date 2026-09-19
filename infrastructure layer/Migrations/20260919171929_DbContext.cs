using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure_layer.Migrations
{
    /// <inheritdoc />
    public partial class DbContext : Migration
    {
        // Fixed IDs
        private static readonly Guid AdminUserId =
            Guid.Parse("11111111-1111-1111-1111-111111111111");

        private static readonly Guid AdminRoleId =
            Guid.Parse("22222222-2222-2222-2222-222222222222");

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // =========================================================
            // 1. Existing Merchant change
            // =========================================================

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "Merchants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // =========================================================
            // 2. ASP.NET Identity - Roles
            // =========================================================

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false),

                    Name = table.Column<string>(
                        type: "nvarchar(256)",
                        maxLength: 256,
                        nullable: true),

                    NormalizedName = table.Column<string>(
                        type: "nvarchar(256)",
                        maxLength: 256,
                        nullable: true),

                    ConcurrencyStamp = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetRoles",
                        x => x.Id);
                });

            // =========================================================
            // 3. ASP.NET Identity - Users
            // =========================================================

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false),

                    FullName = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: false),

                    IsActive = table.Column<bool>(
                        type: "bit",
                        nullable: false),

                    CreatedAt = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: false),

                    UpdatedAt = table.Column<DateTime>(
                        type: "datetime2",
                        nullable: true),

                    UserName = table.Column<string>(
                        type: "nvarchar(256)",
                        maxLength: 256,
                        nullable: true),

                    NormalizedUserName = table.Column<string>(
                        type: "nvarchar(256)",
                        maxLength: 256,
                        nullable: true),

                    Email = table.Column<string>(
                        type: "nvarchar(256)",
                        maxLength: 256,
                        nullable: true),

                    NormalizedEmail = table.Column<string>(
                        type: "nvarchar(256)",
                        maxLength: 256,
                        nullable: true),

                    EmailConfirmed = table.Column<bool>(
                        type: "bit",
                        nullable: false),

                    PasswordHash = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),

                    SecurityStamp = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),

                    ConcurrencyStamp = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),

                    PhoneNumber = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),

                    PhoneNumberConfirmed = table.Column<bool>(
                        type: "bit",
                        nullable: false),

                    TwoFactorEnabled = table.Column<bool>(
                        type: "bit",
                        nullable: false),

                    LockoutEnd = table.Column<DateTimeOffset>(
                        type: "datetimeoffset",
                        nullable: true),

                    LockoutEnabled = table.Column<bool>(
                        type: "bit",
                        nullable: false),

                    AccessFailedCount = table.Column<int>(
                        type: "int",
                        nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUsers",
                        x => x.Id);
                });

            // =========================================================
            // 4. ASP.NET Identity - Role Claims
            // =========================================================

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(
                        type: "int",
                        nullable: false)
                        .Annotation(
                            "SqlServer:Identity",
                            "1, 1"),

                    RoleId = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false),

                    ClaimType = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),

                    ClaimValue = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetRoleClaims",
                        x => x.Id);

                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // =========================================================
            // 5. Admin Business Entity
            // =========================================================

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(
                        type: "int",
                        nullable: false)
                        .Annotation(
                            "SqlServer:Identity",
                            "1, 1"),

                    UserId = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_Admins",
                        x => x.Id);

                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            // =========================================================
            // 6. ASP.NET Identity - User Claims
            // =========================================================

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(
                        type: "int",
                        nullable: false)
                        .Annotation(
                            "SqlServer:Identity",
                            "1, 1"),

                    UserId = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false),

                    ClaimType = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),

                    ClaimValue = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserClaims",
                        x => x.Id);

                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // =========================================================
            // 7. ASP.NET Identity - User Logins
            // =========================================================

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(
                        type: "nvarchar(450)",
                        nullable: false),

                    ProviderKey = table.Column<string>(
                        type: "nvarchar(450)",
                        nullable: false),

                    ProviderDisplayName = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true),

                    UserId = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserLogins",
                        x => new
                        {
                            x.LoginProvider,
                            x.ProviderKey
                        });

                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // =========================================================
            // 8. ASP.NET Identity - User Roles
            // =========================================================

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false),

                    RoleId = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserRoles",
                        x => new
                        {
                            x.UserId,
                            x.RoleId
                        });

                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // =========================================================
            // 9. ASP.NET Identity - User Tokens
            // =========================================================

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(
                        type: "uniqueidentifier",
                        nullable: false),

                    LoginProvider = table.Column<string>(
                        type: "nvarchar(450)",
                        nullable: false),

                    Name = table.Column<string>(
                        type: "nvarchar(450)",
                        nullable: false),

                    Value = table.Column<string>(
                        type: "nvarchar(max)",
                        nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_AspNetUserTokens",
                        x => new
                        {
                            x.UserId,
                            x.LoginProvider,
                            x.Name
                        });

                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // =========================================================
            // 10. Indexes
            // =========================================================

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_UserId",
                table: "Merchants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_UserId",
                table: "Couriers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            // =========================================================
            // 11. Foreign Keys
            // =========================================================

            migrationBuilder.AddForeignKey(
                name: "FK_Couriers_AspNetUsers_UserId",
                table: "Couriers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_AspNetUsers_UserId",
                table: "Merchants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            // =========================================================
            // 12. INSERT ADMIN ROLE
            // =========================================================

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[]
                {
                    "Id",
                    "Name",
                    "NormalizedName",
                    "ConcurrencyStamp"
                },
                values: new object[]
                {
                    AdminRoleId,
                    "Admin",
                    "ADMIN",
                    "44444444-4444-4444-4444-444444444444"
                });

            // =========================================================
            // 13. INSERT ADMIN APPLICATION USER
            // =========================================================

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[]
                {
                    "Id",
                    "FullName",
                    "IsActive",
                    "CreatedAt",
                    "UpdatedAt",
                    "UserName",
                    "NormalizedUserName",
                    "Email",
                    "NormalizedEmail",
                    "EmailConfirmed",
                    "PasswordHash",
                    "SecurityStamp",
                    "ConcurrencyStamp",
                    "PhoneNumber",
                    "PhoneNumberConfirmed",
                    "TwoFactorEnabled",
                    "LockoutEnd",
                    "LockoutEnabled",
                    "AccessFailedCount"
                },
                values: new object[]
                {
                    AdminUserId,
                    "Admin",
                    true,
                    new DateTime(2026, 9, 19),
                    null,
                    "admin",
                    "ADMIN",
                    "admin@gmail.com",
                    "ADMIN@GMAIL.COM",
                    true,

                    // Password = Admin@123
                    "AQAAAAEAAYagAAAAEFvu8wnVe7mA9Hyx0kmRCjcAAAAgHcbxENJDPG+oUV96Yk5yCHBKPerhB86TUGdsBQ7+VWI=",

                    "55555555-5555-5555-5555-555555555555",
                    "66666666-6666-6666-6666-666666666666",

                    null,
                    false,
                    false,
                    null,
                    true,
                    0
                });

            // =========================================================
            // 14. INSERT ADMIN BUSINESS ENTITY
            // =========================================================

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[]
                {
                    "Id",
                    "UserId"
                },
                values: new object[]
                {
                    1,
                    AdminUserId
                });

            // =========================================================
            // 15. CONNECT USER TO ADMIN ROLE
            // =========================================================

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[]
                {
                    "UserId",
                    "RoleId"
                },
                values: new object[]
                {
                    AdminUserId,
                    AdminRoleId
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove User from Role
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[]
                {
                    "UserId",
                    "RoleId"
                },
                keyValues: new object[]
                {
                    AdminUserId,
                    AdminRoleId
                });

            // Remove Admin entity
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            // Remove ApplicationUser
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: AdminUserId);

            // Remove Admin Role
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: AdminRoleId);

            // =========================================================
            // Remove Foreign Keys
            // =========================================================

            migrationBuilder.DropForeignKey(
                name: "FK_Couriers_AspNetUsers_UserId",
                table: "Couriers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_AspNetUsers_UserId",
                table: "Merchants");

            // =========================================================
            // Drop Tables
            // =========================================================

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            // =========================================================
            // Drop Indexes
            // =========================================================

            migrationBuilder.DropIndex(
                name: "IX_Merchants_UserId",
                table: "Merchants");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Couriers_UserId",
                table: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserId",
                table: "Admins");

            // =========================================================
            // Restore Merchant StoreName
            // =========================================================

            migrationBuilder.AlterColumn<string>(
                name: "StoreName",
                table: "Merchants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}