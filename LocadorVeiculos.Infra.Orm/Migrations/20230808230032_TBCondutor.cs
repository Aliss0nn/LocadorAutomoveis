using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadorAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TBCondutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    Cnh = table.Column<int>(type: "int", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteEhCondutor = table.Column<bool>(type: "bit", nullable: false),
                    ClientesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBClientes",
                        column: x => x.ClientesId,
                        principalTable: "TBClientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClientesId",
                table: "TBCondutor",
                column: "ClientesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCondutor");
        }
    }
}
