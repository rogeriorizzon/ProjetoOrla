using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoOrla.Migrations
{
    public partial class CriarBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inicio",
                columns: table => new
                {
                    InicioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo_1 = table.Column<string>(maxLength: 50, nullable: false),
                    Titulo_2 = table.Column<string>(maxLength: 20, nullable: false),
                    BotaoInicio = table.Column<string>(maxLength: 20, nullable: false),
                    FotoInicio = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inicio", x => x.InicioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inicio");
        }
    }
}
