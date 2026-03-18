using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetBarangay = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CityMunicipality = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Audit_Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audit_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Module = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DefaultPassword = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsPasswordChanged = table.Column<bool>(type: "bit", nullable: false),
                    LastPasswordChange = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCredentials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Permissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8387), null, null, "View user list and details", "Users", "ViewUsers", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8388), null },
                    { 2, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8390), null, null, "Create new users", "Users", "CreateUsers", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8390), null },
                    { 3, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8392), null, null, "Update existing users", "Users", "UpdateUsers", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8392), null },
                    { 4, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8394), null, null, "Delete users", "Users", "DeleteUsers", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8394), null },
                    { 5, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8396), null, null, "View role list and details", "Roles", "ViewRoles", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8396), null },
                    { 6, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8399), null, null, "Create new roles", "Roles", "CreateRoles", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8400), null },
                    { 7, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8401), null, null, "Update existing roles", "Roles", "UpdateRoles", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8401), null },
                    { 8, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8403), null, null, "Delete roles", "Roles", "DeleteRoles", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8403), null },
                    { 9, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8405), null, null, "View permission list and details", "Permissions", "ViewPermissions", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8405), null },
                    { 10, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8407), null, null, "Create new permissions", "Permissions", "CreatePermissions", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8408), null },
                    { 11, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8409), null, null, "Update existing permissions", "Permissions", "UpdatePermissions", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8409), null },
                    { 12, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8411), null, null, "Delete permissions", "Permissions", "DeletePermissions", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8411), null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8275), null, null, "Administrator with full access", "Admin", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8275), null },
                    { 2, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8277), null, null, "Standard user with basic access", "User", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8278), null },
                    { 3, new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8279), null, null, "Manager with elevated privileges", "Manager", new DateTime(2026, 2, 6, 3, 12, 2, 190, DateTimeKind.Utc).AddTicks(8280), null }
                });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 11, 11, 1 },
                    { 12, 12, 1 },
                    { 13, 1, 2 },
                    { 14, 5, 2 },
                    { 15, 9, 2 },
                    { 16, 1, 3 },
                    { 17, 3, 3 },
                    { 18, 5, 3 },
                    { 19, 7, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audit_Logs_UserId",
                table: "Audit_Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CreatedBy",
                table: "Permissions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name_Module",
                table: "Permissions",
                columns: new[] { "Name", "Module" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UpdatedBy",
                table: "Permissions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_PermissionId",
                table: "Role_Permissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_RoleId_PermissionId",
                table: "Role_Permissions",
                columns: new[] { "RoleId", "PermissionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedBy",
                table: "Roles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedBy",
                table: "Roles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_RoleId",
                table: "User_Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_UserId_RoleId",
                table: "User_Roles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_UserId",
                table: "UserCredentials",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedBy",
                table: "Users",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit_Logs");

            migrationBuilder.DropTable(
                name: "Role_Permissions");

            migrationBuilder.DropTable(
                name: "User_Roles");

            migrationBuilder.DropTable(
                name: "UserCredentials");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
