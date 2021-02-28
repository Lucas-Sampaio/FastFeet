using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFeet.Infra.Migrations
{
    public partial class CriarRecipientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "recipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Endereco_Numero = table.Column<string>(type: "varchar(100)", nullable: true),
                    Endereco_Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Endereco_Cep = table.Column<string>(type: "varchar(100)", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Endereco_Estado = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipients");
        }
    }
}
