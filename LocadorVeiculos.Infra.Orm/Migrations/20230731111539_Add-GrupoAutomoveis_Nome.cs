using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadorAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddGrupoAutomoveis_Nome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "TBGrupoAutomoveis",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TBGrupoAutomoveis",
                newName: "Tipo");
        }
    }
}
