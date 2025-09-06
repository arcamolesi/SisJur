using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisJur.Migrations
{
    /// <inheritdoc />
    public partial class statusProc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "processos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "processos");
        }
    }
}
