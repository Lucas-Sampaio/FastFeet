using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFeet.Infra.Migrations
{
    public partial class addEntregador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_recipients",
                table: "recipients");

            migrationBuilder.RenameTable(
                name: "recipients",
                newName: "Destinatarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinatarios",
                table: "Destinatarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Entregadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    AvatarId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregadores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entregadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinatarios",
                table: "Destinatarios");

            migrationBuilder.RenameTable(
                name: "Destinatarios",
                newName: "recipients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipients",
                table: "recipients",
                column: "Id");
        }
    }
}
