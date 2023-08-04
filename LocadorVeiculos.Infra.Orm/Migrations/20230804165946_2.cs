using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadorAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBClientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    NomeCliente = table.Column<string>(type: "varchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(200)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(max)", nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBClientes");
        }
    }
}
