using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndAprovacao.Migrations
{
    public partial class AdicionadoReclamanteAoProcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Escritorios_EscritorioId",
                table: "Processos");

            migrationBuilder.AlterColumn<int>(
                name: "EscritorioId",
                table: "Processos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReclamanteId",
                table: "Processos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Processos_ReclamanteId",
                table: "Processos",
                column: "ReclamanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Escritorios_EscritorioId",
                table: "Processos",
                column: "EscritorioId",
                principalTable: "Escritorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Reclamantes_ReclamanteId",
                table: "Processos",
                column: "ReclamanteId",
                principalTable: "Reclamantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Escritorios_EscritorioId",
                table: "Processos");

            migrationBuilder.DropForeignKey(
                name: "FK_Processos_Reclamantes_ReclamanteId",
                table: "Processos");

            migrationBuilder.DropIndex(
                name: "IX_Processos_ReclamanteId",
                table: "Processos");

            migrationBuilder.DropColumn(
                name: "ReclamanteId",
                table: "Processos");

            migrationBuilder.AlterColumn<int>(
                name: "EscritorioId",
                table: "Processos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Processos_Escritorios_EscritorioId",
                table: "Processos",
                column: "EscritorioId",
                principalTable: "Escritorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}