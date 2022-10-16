using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerMonServer.DataStore.SQL.Migrations
{
    public partial class FK_Measure_To_Agent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentUUID",
                table: "Measures",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_AgentUUID",
                table: "Measures",
                column: "AgentUUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measures_Agents_AgentUUID",
                table: "Measures",
                column: "AgentUUID",
                principalTable: "Agents",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measures_Agents_AgentUUID",
                table: "Measures");

            migrationBuilder.DropIndex(
                name: "IX_Measures_AgentUUID",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "AgentUUID",
                table: "Measures");
        }
    }
}
