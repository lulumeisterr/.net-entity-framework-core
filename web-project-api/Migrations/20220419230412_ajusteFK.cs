using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_project_api.Migrations
{
    public partial class ajusteFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Trade_Trade",
                table: "Allocation");

            migrationBuilder.DropColumn(
                name: "CurrentTradeId",
                table: "Allocation");

            migrationBuilder.RenameColumn(
                name: "Trade",
                table: "Allocation",
                newName: "tradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_Trade",
                table: "Allocation",
                newName: "IX_Allocation_tradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Trade_tradeId",
                table: "Allocation",
                column: "tradeId",
                principalTable: "Trade",
                principalColumn: "tradeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Trade_tradeId",
                table: "Allocation");

            migrationBuilder.RenameColumn(
                name: "tradeId",
                table: "Allocation",
                newName: "Trade");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_tradeId",
                table: "Allocation",
                newName: "IX_Allocation_Trade");

            migrationBuilder.AddColumn<int>(
                name: "CurrentTradeId",
                table: "Allocation",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Trade_Trade",
                table: "Allocation",
                column: "Trade",
                principalTable: "Trade",
                principalColumn: "tradeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
