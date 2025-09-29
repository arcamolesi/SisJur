using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisJur.Migrations
{
    /// <inheritdoc />
    public partial class inical : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipoprocessos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoprocessos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "advogados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    areaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advogados", x => x.id);
                    table.ForeignKey(
                        name: "FK_advogados_areas_areaid",
                        column: x => x.areaid,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "processos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipoprocessoid = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processos", x => x.id);
                    table.ForeignKey(
                        name: "FK_processos_tipoprocessos_tipoprocessoid",
                        column: x => x.tipoprocessoid,
                        principalTable: "tipoprocessos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_advogados_areaid",
                table: "advogados",
                column: "areaid");

            migrationBuilder.CreateIndex(
                name: "IX_processos_tipoprocessoid",
                table: "processos",
                column: "tipoprocessoid");

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

            migrationBuilder.DropTable(
                name: "advogados");

            migrationBuilder.DropTable(
                name: "processos");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "tipoprocessos");
        }
    }
}
