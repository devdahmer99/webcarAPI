using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webcarsAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlteraCampoImagemParaLongblobTablaVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Veiculos",
                type: "LONGBLOB",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Veiculos",
                type: "varbinary(max)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "LONGBLOB",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
