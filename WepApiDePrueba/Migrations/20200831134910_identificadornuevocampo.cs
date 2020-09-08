using Microsoft.EntityFrameworkCore.Migrations;

namespace WepApiDePrueba.Migrations
{
    public partial class identificadornuevocampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identificador",
                table: "Autores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
