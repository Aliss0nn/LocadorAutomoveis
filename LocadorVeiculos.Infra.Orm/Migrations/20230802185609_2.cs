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
            migrationBuilder.RenameColumn(
                name: "planoDeCalculo",
                table: "TBTaxasEServico",
                newName: "PlanoDeCalculo");

            migrationBuilder.AlterColumn<string>(
                name: "PlanoDeCalculo",
                table: "TBTaxasEServico",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanoDeCalculo",
                table: "TBTaxasEServico",
                newName: "planoDeCalculo");

            migrationBuilder.AlterColumn<int>(
                name: "planoDeCalculo",
                table: "TBTaxasEServico",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }
    }
}
