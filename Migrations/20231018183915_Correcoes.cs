using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionariosFinal.Migrations
{
    /// <inheritdoc />
    public partial class Correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DecricaoCargo",
                table: "Cargo",
                newName: "DescricaoCargo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescricaoCargo",
                table: "Cargo",
                newName: "DecricaoCargo");
        }
    }
}
