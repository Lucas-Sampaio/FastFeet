using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFeet.Infra.Migrations
{
    public partial class attEncomenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomendas_Destinatarios_DestinatarioId",
                table: "Encomendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomendas_Entregadores_EntregadorId",
                table: "Encomendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Destinatarios_DestinatarioId",
                table: "Encomendas",
                column: "DestinatarioId",
                principalTable: "Destinatarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Entregadores_EntregadorId",
                table: "Encomendas",
                column: "EntregadorId",
                principalTable: "Entregadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomendas_Destinatarios_DestinatarioId",
                table: "Encomendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomendas_Entregadores_EntregadorId",
                table: "Encomendas");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Destinatarios_DestinatarioId",
                table: "Encomendas",
                column: "DestinatarioId",
                principalTable: "Destinatarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Entregadores_EntregadorId",
                table: "Encomendas",
                column: "EntregadorId",
                principalTable: "Entregadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
