using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_project_api.Migrations
{
    public partial class ConfigureForeingkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Trade_Id",
                table: "Allocation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Allocation",
                newName: "Trade");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_Id",
                table: "Allocation",
                newName: "IX_Allocation_Trade");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Trade_Trade",
                table: "Allocation",
                column: "Trade",
                principalTable: "Trade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Trade_Trade",
                table: "Allocation");

            migrationBuilder.RenameColumn(
                name: "Trade",
                table: "Allocation",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_Trade",
                table: "Allocation",
                newName: "IX_Allocation_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Trade_Id",
                table: "Allocation",
                column: "Id",
                principalTable: "Trade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
