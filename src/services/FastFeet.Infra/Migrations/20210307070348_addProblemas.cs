using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFeet.Infra.Migrations
{
    public partial class addProblemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EncomendaProblemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncomendaId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncomendaProblemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncomendaProblemas_Encomendas_EncomendaId",
                        column: x => x.EncomendaId,
                        principalTable: "Encomendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncomendaProblemas_EncomendaId",
                table: "EncomendaProblemas",
                column: "EncomendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncomendaProblemas");
        }
    }
}
