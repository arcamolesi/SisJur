using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisJur.Migrations
{
    /// <inheritdoc />
    public partial class Varas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "varas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    processoid = table.Column<int>(type: "int", nullable: false),
                    advogadoid = table.Column<int>(type: "int", nullable: false),
                    juiz = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    valorcausa = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_varas", x => x.id);
                    table.ForeignKey(
                        name: "FK_varas_advogados_advogadoid",
                        column: x => x.advogadoid,
                        principalTable: "advogados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_varas_processos_processoid",
                        column: x => x.processoid,
                        principalTable: "processos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_varas_advogadoid",
                table: "varas",
                column: "advogadoid");

            migrationBuilder.CreateIndex(
                name: "IX_varas_processoid",
                table: "varas",
                column: "processoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "varas");
        }
    }
}
