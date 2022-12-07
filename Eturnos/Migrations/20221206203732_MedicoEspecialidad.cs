using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eturnos.Migrations
{
    public partial class MedicoEspecialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicosEspecialidades",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdEspeciliadad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicosEspecialidades", x => new { x.IdMedico, x.IdEspeciliadad });
                    table.ForeignKey(
                        name: "FK_MedicosEspecialidades_Especialidades_IdEspeciliadad",
                        column: x => x.IdEspeciliadad,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicosEspecialidades_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicosEspecialidades_IdEspeciliadad",
                table: "MedicosEspecialidades",
                column: "IdEspeciliadad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicosEspecialidades");
        }
    }
}
