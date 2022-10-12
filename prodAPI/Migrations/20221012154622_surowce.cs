using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prodAPI.Migrations
{
    public partial class surowce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etapy",
                columns: table => new
                {
                    id_etapu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etapy", x => x.id_etapu);
                });

            migrationBuilder.CreateTable(
                name: "Maszyny",
                columns: table => new
                {
                    id_maszyny = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    opis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_przegladu = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maszyny", x => x.id_maszyny);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    id_pracownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nr_tel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.id_pracownika);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    id_produktu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.id_produktu);
                });

            migrationBuilder.CreateTable(
                name: "Surowce",
                columns: table => new
                {
                    id_surowca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surowce", x => x.id_surowca);
                });

            migrationBuilder.CreateTable(
                name: "Konties",
                columns: table => new
                {
                    id_konta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    haslo = table.Column<byte[]>(type: "binary(64)", fixedLength: true, maxLength: 64, nullable: false),
                    uprawnienia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_pracownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konties", x => x.id_konta);
                    table.ForeignKey(
                        name: "FK_Konta_Pracownicy",
                        column: x => x.id_pracownika,
                        principalTable: "Pracownicy",
                        principalColumn: "id_pracownika");
                });

            migrationBuilder.CreateTable(
                name: "Zlecenia",
                columns: table => new
                {
                    id_zlecenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_rozpoczecia = table.Column<DateTime>(type: "date", nullable: true),
                    data_zakonczenia = table.Column<DateTime>(type: "date", nullable: true),
                    id_produktu = table.Column<int>(type: "int", nullable: true),
                    ilosc = table.Column<int>(type: "int", nullable: true),
                    IdProduktuNavigationIdProduktu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zlecenia", x => x.id_zlecenia);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Produkty_IdProduktuNavigationIdProduktu",
                        column: x => x.IdProduktuNavigationIdProduktu,
                        principalTable: "Produkty",
                        principalColumn: "id_produktu");
                });

            migrationBuilder.CreateTable(
                name: "SurowceDlaEtapu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stan = table.Column<bool>(type: "bit", nullable: false),
                    potrzebna_ilosc = table.Column<int>(type: "int", nullable: false),
                    faktyczna_ilosc = table.Column<int>(type: "int", nullable: true),
                    id_etapu = table.Column<int>(type: "int", nullable: false),
                    id_surowca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurowceDlaEtapu", x => x.id);
                    table.ForeignKey(
                        name: "FK_SDE_Etapy",
                        column: x => x.id_etapu,
                        principalTable: "Etapy",
                        principalColumn: "id_etapu");
                    table.ForeignKey(
                        name: "FK_SDE_Surowce",
                        column: x => x.id_surowca,
                        principalTable: "Surowce",
                        principalColumn: "id_surowca");
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id_statusu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_produktu = table.Column<int>(type: "int", nullable: false),
                    id_zlecenia = table.Column<int>(type: "int", nullable: false),
                    id_maszyny = table.Column<int>(type: "int", nullable: true),
                    id_pracownika = table.Column<int>(type: "int", nullable: false),
                    id_etapu = table.Column<int>(type: "int", nullable: false),
                    stan = table.Column<bool>(type: "bit", nullable: false),
                    czas_trwania = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id_statusu);
                    table.ForeignKey(
                        name: "FK_Status_Etapy",
                        column: x => x.id_etapu,
                        principalTable: "Etapy",
                        principalColumn: "id_etapu");
                    table.ForeignKey(
                        name: "FK_Status_Maszyny",
                        column: x => x.id_maszyny,
                        principalTable: "Maszyny",
                        principalColumn: "id_maszyny");
                    table.ForeignKey(
                        name: "FK_Status_Pracownicy",
                        column: x => x.id_pracownika,
                        principalTable: "Pracownicy",
                        principalColumn: "id_pracownika");
                    table.ForeignKey(
                        name: "FK_Status_Produkty",
                        column: x => x.id_produktu,
                        principalTable: "Produkty",
                        principalColumn: "id_produktu");
                    table.ForeignKey(
                        name: "FK_Status_Zlecenia",
                        column: x => x.id_zlecenia,
                        principalTable: "Zlecenia",
                        principalColumn: "id_zlecenia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konties_id_pracownika",
                table: "Konties",
                column: "id_pracownika");

            migrationBuilder.CreateIndex(
                name: "IX_Status_id_etapu",
                table: "Status",
                column: "id_etapu");

            migrationBuilder.CreateIndex(
                name: "IX_Status_id_maszyny",
                table: "Status",
                column: "id_maszyny");

            migrationBuilder.CreateIndex(
                name: "IX_Status_id_pracownika",
                table: "Status",
                column: "id_pracownika");

            migrationBuilder.CreateIndex(
                name: "IX_Status_id_produktu",
                table: "Status",
                column: "id_produktu");

            migrationBuilder.CreateIndex(
                name: "IX_Status_id_zlecenia",
                table: "Status",
                column: "id_zlecenia");

            migrationBuilder.CreateIndex(
                name: "IX_SurowceDlaEtapu_id_etapu",
                table: "SurowceDlaEtapu",
                column: "id_etapu");

            migrationBuilder.CreateIndex(
                name: "IX_SurowceDlaEtapu_id_surowca",
                table: "SurowceDlaEtapu",
                column: "id_surowca");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_IdProduktuNavigationIdProduktu",
                table: "Zlecenia",
                column: "IdProduktuNavigationIdProduktu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konties");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "SurowceDlaEtapu");

            migrationBuilder.DropTable(
                name: "Maszyny");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Zlecenia");

            migrationBuilder.DropTable(
                name: "Etapy");

            migrationBuilder.DropTable(
                name: "Surowce");

            migrationBuilder.DropTable(
                name: "Produkty");
        }
    }
}
