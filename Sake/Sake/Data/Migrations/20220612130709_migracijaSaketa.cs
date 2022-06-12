using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sake.Data.Migrations
{
    public partial class migracijaSaketa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GledanjeUtakmice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtakmice = table.Column<int>(type: "int", nullable: false),
                    DostupanLivestream = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GledanjeUtakmice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Igrač",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRođenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrač", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IgranjeZaTim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTima = table.Column<int>(type: "int", nullable: false),
                    IdIgrača = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgranjeZaTim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lutrija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKorisnika = table.Column<int>(type: "int", nullable: false),
                    IdUtakmice = table.Column<int>(type: "int", nullable: false),
                    IdPobjednika = table.Column<int>(type: "int", nullable: false),
                    NagradniBodovi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lutrija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportskiTim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportskiTim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulaznica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtakmice = table.Column<int>(type: "int", nullable: false),
                    IdGledanja = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Dostupna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulaznica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utakmica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDomaćina = table.Column<int>(type: "int", nullable: false),
                    IdGosta = table.Column<int>(type: "int", nullable: false),
                    VrijemeOdržavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MjestoOdržavanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmica", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GledanjeUtakmice");

            migrationBuilder.DropTable(
                name: "Igrač");

            migrationBuilder.DropTable(
                name: "IgranjeZaTim");

            migrationBuilder.DropTable(
                name: "Lutrija");

            migrationBuilder.DropTable(
                name: "SportskiTim");

            migrationBuilder.DropTable(
                name: "Ulaznica");

            migrationBuilder.DropTable(
                name: "Utakmica");
        }
    }
}
