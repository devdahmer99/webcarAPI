using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webcarsAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCamposTelefoneECidadeTabelaVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Veiculos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Veiculos",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Veiculos");
        }
    }
}
