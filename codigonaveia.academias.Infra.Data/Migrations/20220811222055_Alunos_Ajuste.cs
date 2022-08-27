using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codigonaveia.academias.Infra.Data.Migrations
{
    public partial class Alunos_Ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_AspNetUsers_UserId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_AspNetUsers_UserId",
                table: "Alunos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_AspNetUsers_UserId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_AspNetUsers_UserId",
                table: "Alunos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
