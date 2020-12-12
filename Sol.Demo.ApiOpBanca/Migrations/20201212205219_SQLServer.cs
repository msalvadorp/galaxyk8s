using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sol.Demo.ApiOpBanca.Migrations
{
    public partial class SQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    ApellidoPaterno = table.Column<string>(nullable: true),
                    ApellidoMaterno = table.Column<string>(nullable: true),
                    NroDocumento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    IdTransaccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCuentaOrigen = table.Column<int>(nullable: false),
                    IdCuentaDestino = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    FechaOperacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.IdTransaccion);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    IdCuenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.IdCuenta);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "ApellidoMaterno", "ApellidoPaterno", "Nombres", "NroDocumento" },
                values: new object[] { 1, "Lopez", "Guerra", "Juan", "12312312" });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "ApellidoMaterno", "ApellidoPaterno", "Nombres", "NroDocumento" },
                values: new object[] { 2, "Nieto", "Salguero", "Pedro", "67676767" });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "ApellidoMaterno", "ApellidoPaterno", "Nombres", "NroDocumento" },
                values: new object[] { 3, "Gomez", "Perez", "Maria", "44344344" });

            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "IdCuenta", "IdCliente", "Saldo" },
                values: new object[] { 1, 1, 120000m });

            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "IdCuenta", "IdCliente", "Saldo" },
                values: new object[] { 3, 2, 660000m });

            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "IdCuenta", "IdCliente", "Saldo" },
                values: new object[] { 2, 3, 80000m });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdCliente",
                table: "Cuenta",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
