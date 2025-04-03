using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "Name" },
                values: new object[,]
                {
                    { 1, "Organization A" },
                    { 2, "Organization B" },
                    { 3, "Organization C" },
                    { 4, "Organization D" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Date", "Description", "OrganizationId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event 1", 1, "Event" },
                    { 2, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event 2", 1, "Event" },
                    { 3, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event 3", 1, "Event" },
                    { 4, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event 4", 1, "Event" },
                    { 5, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event 5", 1, "Event" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizationId",
                table: "Events",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
