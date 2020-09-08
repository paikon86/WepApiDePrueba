using Microsoft.EntityFrameworkCore.Migrations;

namespace WepApiDePrueba.Migrations
{
    public partial class AutorNuevocampos78 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Autores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Autores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
