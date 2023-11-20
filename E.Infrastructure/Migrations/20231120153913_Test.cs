using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artistes",
                columns: table => new
                {
                    ArtisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DareNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationalite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artistes", x => x.ArtisteId);
                });

            migrationBuilder.CreateTable(
                name: "festivals",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "chansons",
                columns: table => new
                {
                    ChansonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    StyleMusical = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VuesYoutube = table.Column<int>(type: "int", nullable: false),
                    ArtisteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chansons", x => x.ChansonId);
                    table.ForeignKey(
                        name: "FK_chansons_artistes_ArtisteFk",
                        column: x => x.ArtisteFk,
                        principalTable: "artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concertes",
                columns: table => new
                {
                    DateConcert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtisteFk = table.Column<int>(type: "int", nullable: false),
                    FestivalFk = table.Column<int>(type: "int", nullable: false),
                    Cachet = table.Column<double>(type: "float", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concertes", x => new { x.ArtisteFk, x.FestivalFk, x.DateConcert });
                    table.ForeignKey(
                        name: "FK_concertes_artistes_ArtisteFk",
                        column: x => x.ArtisteFk,
                        principalTable: "artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_concertes_festivals_FestivalFk",
                        column: x => x.FestivalFk,
                        principalTable: "festivals",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chansons_ArtisteFk",
                table: "chansons",
                column: "ArtisteFk");

            migrationBuilder.CreateIndex(
                name: "IX_concertes_FestivalFk",
                table: "concertes",
                column: "FestivalFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chansons");

            migrationBuilder.DropTable(
                name: "concertes");

            migrationBuilder.DropTable(
                name: "artistes");

            migrationBuilder.DropTable(
                name: "festivals");
        }
    }
}
