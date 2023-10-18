using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionariosFinal.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoEscala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescricaoEscala",
                table: "Escala",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoEscala",
                table: "Escala");
        }
    }
}
