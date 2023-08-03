using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadorAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class addautomovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marca = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(200)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(200)", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAutomoveis_TBGrupoAutomoveis",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_GrupoId",
                table: "TBAutomovel",
                column: "GrupoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAutomovel");
        }
    }
}
