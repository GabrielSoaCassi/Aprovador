using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAprovacao.Migrations
{
    public partial class AlteradodeEstadoProcessoparaEstadoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstadoAtual",
                table: "Processos",
                newName: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Processos",
                newName: "EstadoAtual");
        }
    }
}