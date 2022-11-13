using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfMon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastSeen = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Inactive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Measure",
                columns: table => new
                {
                    AgentName = table.Column<string>(type: "TEXT", nullable: false),
                    UniqueName = table.Column<string>(type: "TEXT", nullable: false),
                    MeasureType = table.Column<int>(type: "INTEGER", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    FirstValueTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastValueTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => new { x.UniqueName, x.AgentName });
                    table.ForeignKey(
                        name: "FK_Measure_Agents_AgentName",
                        column: x => x.AgentName,
                        principalTable: "Agents",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    MeasureName = table.Column<string>(type: "TEXT", nullable: false),
                    AgentName = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => new { x.AgentName, x.MeasureName, x.Timestamp });
                    table.ForeignKey(
                        name: "FK_Samples_Measure_AgentName_MeasureName",
                        columns: x => new { x.AgentName, x.MeasureName },
                        principalTable: "Measure",
                        principalColumns: new[] { "UniqueName", "AgentName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measure_AgentName",
                table: "Measure",
                column: "AgentName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "Measure");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
