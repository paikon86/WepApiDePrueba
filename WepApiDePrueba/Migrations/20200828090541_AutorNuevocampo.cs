using Microsoft.EntityFrameworkCore.Migrations;

namespace WepApiDePrueba.Migrations
{
    public partial class AutorNuevocampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCard",
                table: "Autores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Autores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCard",
                table: "Autores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
