using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaDeBarbeariaBack.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbeiros",
                columns: table => new
                {
                    IdBarbeiro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeBarbeiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneBarbeiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbeiros", x => x.IdBarbeiro);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    BarbeiroId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Barbeiros_BarbeiroId",
                        column: x => x.BarbeiroId,
                        principalTable: "Barbeiros",
                        principalColumn: "IdBarbeiro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Barbeiros",
                columns: new[] { "IdBarbeiro", "Especialidade", "NomeBarbeiro", "TelefoneBarbeiro" },
                values: new object[,]
                {
                    { 1, "Corte", "Carlos", "123456789" },
                    { 2, "Barba", "João", "234567890" },
                    { 3, "Coloração", "Pedro", "345678901" },
                    { 4, "Alisamento", "Lucas", "456789012" },
                    { 5, "Corte e Barba", "Rafael", "567890123" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "IdCliente", "NomeCliente", "TelefoneCliente" },
                values: new object[,]
                {
                    { 1, "Ana", "987654321" },
                    { 2, "Bruno", "876543210" },
                    { 3, "Clara", "765432109" },
                    { 4, "Diego", "654321098" },
                    { 5, "Elisa", "543210987" }
                });

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "IdServico", "Descricao", "Preco" },
                values: new object[,]
                {
                    { 1, "Corte Simples", 20.00m },
                    { 2, "Barba", 15.00m },
                    { 3, "Corte e Barba", 30.00m },
                    { 4, "Coloração", 50.00m },
                    { 5, "Alisamento", 80.00m }
                });

            migrationBuilder.InsertData(
                table: "Agendamentos",
                columns: new[] { "AgendamentoId", "BarbeiroId", "ClienteId", "HorarioData", "ServicoId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 12, 11, 15, 50, 11, 762, DateTimeKind.Local).AddTicks(9208), 1 },
                    { 2, 2, 2, new DateTime(2024, 12, 12, 15, 50, 11, 764, DateTimeKind.Local).AddTicks(8173), 2 },
                    { 3, 3, 3, new DateTime(2024, 12, 13, 15, 50, 11, 764, DateTimeKind.Local).AddTicks(8192), 3 },
                    { 4, 4, 4, new DateTime(2024, 12, 14, 15, 50, 11, 764, DateTimeKind.Local).AddTicks(8194), 4 },
                    { 5, 5, 5, new DateTime(2024, 12, 15, 15, 50, 11, 764, DateTimeKind.Local).AddTicks(8195), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_BarbeiroId",
                table: "Agendamentos",
                column: "BarbeiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Barbeiros");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
