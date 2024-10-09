using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjPedidos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "DataCriacao", "EmailCliente", "NomeCliente", "Pago" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Cliente 1", true },
                    { 2, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Cliente 2", true },
                    { 3, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Cliente 3", true },
                    { 4, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Cliente 4", false },
                    { 5, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Cliente 5", false }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "NomeProduto", "Valor" },
                values: new object[,]
                {
                    { 1, "Produto 1", 19.99m },
                    { 2, "Produto 2", 29.99m },
                    { 3, "Produto 3", 39.99m },
                    { 4, "Produto 4", 49.99m },
                    { 5, "Produto 5", 59.99m }
                });

            migrationBuilder.InsertData(
                table: "ItensPedido",
                columns: new[] { "Id", "IdPedido", "IdProduto", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 2 },
                    { 3, 2, 3, 12 },
                    { 4, 2, 4, 1 },
                    { 5, 3, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_IdPedido",
                table: "ItensPedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_IdProduto",
                table: "ItensPedido",
                column: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
