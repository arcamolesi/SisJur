using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisJur.Migrations
{
    /// <inheritdoc />
    public partial class advogado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advogados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    areaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advogados", x => x.id);
                    table.ForeignKey(
                        name: "FK_Advogados_Areas_areaid",
                        column: x => x.areaid,
                        principalTable: "Areas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advogados_areaid",
                table: "Advogados",
                column: "areaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advogados");
        }
    }
}
