using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codigonaveia.academias.Infra.Data.Migrations
{
    public partial class Alunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAlunos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoAvatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    Celular = table.Column<string>(type: "varchar(11)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(20)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAlunos);
                    table.ForeignKey(
                        name: "FK_Alunos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UserId",
                table: "Alunos",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
