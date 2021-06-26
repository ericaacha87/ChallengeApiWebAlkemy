using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MundoDisneyChallenge.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Personajes",
                columns: table => new
                {
                    PersonajeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personajes", x => x.PersonajeID);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSeries",
                columns: table => new
                {
                    PeliculaSerieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSeries", x => x.PeliculaSerieID);
                    table.ForeignKey(
                        name: "FK_PeliculaSeries_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Generos",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSeriePersonaje",
                columns: table => new
                {
                    PeliculaSerieID = table.Column<int>(type: "int", nullable: false),
                    PersonajesPersonajeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSeriePersonaje", x => new { x.PeliculaSerieID, x.PersonajesPersonajeID });
                    table.ForeignKey(
                        name: "FK_PeliculaSeriePersonaje_PeliculaSeries_PeliculaSerieID",
                        column: x => x.PeliculaSerieID,
                        principalTable: "PeliculaSeries",
                        principalColumn: "PeliculaSerieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaSeriePersonaje_Personajes_PersonajesPersonajeID",
                        column: x => x.PersonajesPersonajeID,
                        principalTable: "Personajes",
                        principalColumn: "PersonajeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSeriePersonaje_PersonajesPersonajeID",
                table: "PeliculaSeriePersonaje",
                column: "PersonajesPersonajeID");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSeries_GeneroID",
                table: "PeliculaSeries",
                column: "GeneroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaSeriePersonaje");

            migrationBuilder.DropTable(
                name: "PeliculaSeries");

            migrationBuilder.DropTable(
                name: "Personajes");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
