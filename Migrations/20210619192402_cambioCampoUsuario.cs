using Microsoft.EntityFrameworkCore.Migrations;

namespace MundoDisneyChallenge.Migrations
{
    public partial class cambioCampoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Usuarios",
                newName: "Contrasenia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "Usuarios",
                newName: "Contraseña");
        }
    }
}
