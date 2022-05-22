using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAprovacao.Migrations
{
    public partial class AlterTable_Processo_ColunaAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Processos",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Processos");
        }
    }
}