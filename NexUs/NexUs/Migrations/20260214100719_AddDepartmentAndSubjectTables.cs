using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentAndSubjectTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7177), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7186), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7187) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7188), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7189) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7191) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7192), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7195), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7197), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7197) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7199), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7203), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7203) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7205), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7206), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7208), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7212), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7215), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7216) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7239), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7241), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7242) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7243), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7245), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7247), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7249), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7251), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7253), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7255), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7256), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7258), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7261), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7261) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7263), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7264), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7266), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7268), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7268) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7270), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7272), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "Description", "Module", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 38, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7278), null, null, "View department list and details", "Departments", "ViewDepartments", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7278), null },
                    { 39, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7279), null, null, "Create new departments", "Departments", "CreateDepartments", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7280), null },
                    { 40, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7281), null, null, "Update existing departments", "Departments", "UpdateDepartments", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7281), null },
                    { 41, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7283), null, null, "Delete departments", "Departments", "DeleteDepartments", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7283), null },
                    { 42, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7285), null, null, "Archive (soft delete) departments", "Departments", "ArchiveDepartments", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7285), null },
                    { 43, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7286), null, null, "Restore archived departments", "Departments", "RestoreDepartments", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7287), null },
                    { 44, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7288), null, null, "Permanently delete departments", "Departments", "PermanentDeleteDepartments", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7289), null },
                    { 45, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7290), null, null, "View subject list and details", "Subjects", "ViewSubjects", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7290), null },
                    { 46, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7292), null, null, "Create new subjects", "Subjects", "CreateSubjects", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7292), null },
                    { 47, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7294), null, null, "Update existing subjects", "Subjects", "UpdateSubjects", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7294), null },
                    { 48, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7295), null, null, "Delete subjects", "Subjects", "DeleteSubjects", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7296), null },
                    { 49, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7297), null, null, "Archive (soft delete) subjects", "Subjects", "ArchiveSubjects", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7297), null },
                    { 50, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7299), null, null, "Restore archived subjects", "Subjects", "RestoreSubjects", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7299), null },
                    { 51, new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7301), null, null, "Permanently delete subjects", "Subjects", "PermanentDeleteSubjects", new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7301), null }
                });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 38, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 39, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 40, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 41, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 42, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 43, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 44, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 45, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 46, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 47, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 48, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 49, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 50, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 51, 1 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "PermissionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "PermissionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "PermissionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "PermissionId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "PermissionId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "PermissionId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "PermissionId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "PermissionId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "PermissionId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "PermissionId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "PermissionId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "PermissionId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "PermissionId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "PermissionId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 68,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 69,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 70,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 71,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 72,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 73,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 74,
                column: "PermissionId",
                value: 23);

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 75, 24, 2 },
                    { 76, 25, 2 },
                    { 77, 26, 2 },
                    { 78, 27, 2 },
                    { 79, 28, 2 },
                    { 80, 29, 2 },
                    { 81, 30, 2 },
                    { 82, 31, 2 },
                    { 83, 32, 2 },
                    { 84, 33, 2 },
                    { 85, 34, 2 },
                    { 86, 35, 2 },
                    { 87, 36, 2 },
                    { 88, 37, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7041), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7041) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7044), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7044) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7046), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7046) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7048), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7052), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7058), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$b2gnxSH6qGyjmQke4Vst7eXBOrotSz6yyryl/325U7T61CkOnanBm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7537), new DateTime(2026, 2, 14, 10, 7, 19, 49, DateTimeKind.Utc).AddTicks(7538) });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 89, 38, 2 },
                    { 90, 39, 2 },
                    { 91, 40, 2 },
                    { 92, 41, 2 },
                    { 93, 42, 2 },
                    { 94, 43, 2 },
                    { 95, 44, 2 },
                    { 96, 45, 2 },
                    { 97, 46, 2 },
                    { 98, 47, 2 },
                    { 99, 48, 2 },
                    { 100, 49, 2 },
                    { 101, 50, 2 },
                    { 102, 51, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedBy",
                table: "Departments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatedBy",
                table: "Departments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CreatedBy",
                table: "Subjects",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DepartmentId",
                table: "Subjects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UpdatedBy",
                table: "Subjects",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7773), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7777), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7779), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7779) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7781), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7783), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7786), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7788), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7792), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7795), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7795) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7797), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7799), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7799) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7801), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7801) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7802), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7803) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7804), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7806), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7808), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7808) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7811), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7811) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7812), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7813) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7814), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7816), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7818), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7822), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7823), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7825), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7827), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7832), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7833), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7835), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7837), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7837) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7839), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7839) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7841), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7842) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7843), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7844) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7845), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7845) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7847), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7847) });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 7, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 8, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 9, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 10, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 11, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 12, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 13, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 14, 2 });

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 52,
                column: "PermissionId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 53,
                column: "PermissionId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 54,
                column: "PermissionId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 55,
                column: "PermissionId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 56,
                column: "PermissionId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "PermissionId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 58,
                column: "PermissionId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 59,
                column: "PermissionId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 60,
                column: "PermissionId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 61,
                column: "PermissionId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 62,
                column: "PermissionId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 63,
                column: "PermissionId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 64,
                column: "PermissionId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 65,
                column: "PermissionId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 66,
                column: "PermissionId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 67,
                column: "PermissionId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 68,
                column: "PermissionId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 69,
                column: "PermissionId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 70,
                column: "PermissionId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 71,
                column: "PermissionId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 72,
                column: "PermissionId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 73,
                column: "PermissionId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Role_Permissions",
                keyColumn: "Id",
                keyValue: 74,
                column: "PermissionId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7607), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7610), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7611) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7612), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7613) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7614), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7615) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7616), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7618), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7618) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7626), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7628), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$69H2CbUh0/qNrS.4sheTRePxbeL1qmFiR9DLZydRbuo6Fm5Q6gy0O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(8064), new DateTime(2026, 2, 14, 5, 29, 6, 732, DateTimeKind.Utc).AddTicks(8064) });
        }
    }
}
