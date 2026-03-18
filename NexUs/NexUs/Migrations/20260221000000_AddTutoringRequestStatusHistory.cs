using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexUs.Migrations
{
    /// <inheritdoc />
    public partial class AddTutoringRequestStatusHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutoringRequestStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutoringRequestId = table.Column<int>(type: "int", nullable: false),
                    FromStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ToStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChangedByRole = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutoringRequestStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutoringRequestStatusHistories_TutoringRequests_TutoringRequestId",
                        column: x => x.TutoringRequestId,
                        principalTable: "TutoringRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutoringRequestStatusHistories_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TutoringRequestStatusHistories_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequestStatusHistories_CreatedBy",
                table: "TutoringRequestStatusHistories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequestStatusHistories_TutoringRequestId",
                table: "TutoringRequestStatusHistories",
                column: "TutoringRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringRequestStatusHistories_UpdatedBy",
                table: "TutoringRequestStatusHistories",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutoringRequestStatusHistories");
        }
    }
}
