using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codigonaveia.academias.Infra.Data.Migrations
{
    public partial class EntidadesEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "varchar(100)", nullable: false),
                    To = table.Column<string>(type: "varchar(100)", nullable: false),
                    Subject = table.Column<string>(type: "varchar(500)", nullable: false),
                    Body = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Smtp = table.Column<string>(type: "varchar(100)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    EmailUser = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfiguracoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailPasswordAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "varchar(Max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailPasswordAccount", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "EmailConfiguracoes");

            migrationBuilder.DropTable(
                name: "EmailPasswordAccount");
        }
    }
}
