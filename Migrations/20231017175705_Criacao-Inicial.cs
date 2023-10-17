using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionariosFinal.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escala",
                columns: table => new
                {
                    EscalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioEntrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntervaloSaida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntervaloRetorno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioSaida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escala", x => x.EscalaId);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecricaoCargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalarioCargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscalaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                    table.ForeignKey(
                        name: "FK_Cargo_Escala_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escala",
                        principalColumn: "EscalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ponto",
                columns: table => new
                {
                    PontoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaidaAlmoco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoltaAlmoco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<double>(type: "float", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponto", x => x.PontoId);
                    table.ForeignKey(
                        name: "FK_Ponto_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_EscalaId",
                table: "Cargo",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_CargoId",
                table: "Funcionario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ponto_FuncionarioId",
                table: "Ponto",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ponto");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Escala");
        }
    }
}
