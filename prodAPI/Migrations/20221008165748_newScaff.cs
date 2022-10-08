using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prodAPI.Migrations
{
    public partial class newScaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    kategoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    nrtel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                name: "Etapy",
                columns: table => new
                {
                    id_etapu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_produktu = table.Column<int>(type: "int", nullable: false),
                    nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    opis = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etapy", x => x.id_etapu);
                    table.ForeignKey(
                        name: "FK_Etapy_Produkty",
                        column: x => x.id_produktu,
                        principalTable: "Produkty",
                        principalColumn: "id_produktu");
                });

            migrationBuilder.CreateTable(
                name: "Zlecenia",
                columns: table => new
                {
                    id_zlecenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_produktu = table.Column<int>(type: "int", nullable: false),
                    data_rozpoczecia = table.Column<DateTime>(type: "date", nullable: false),
                    ilosc = table.Column<int>(type: "int", nullable: false),
                    stan = table.Column<bool>(type: "bit", nullable: false),
                    data_zakonczenia = table.Column<DateTime>(type: "date", nullable: false),
                    opis = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zlecenia", x => x.id_zlecenia);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Produkty",
                        column: x => x.id_produktu,
                        principalTable: "Produkty",
                        principalColumn: "id_produktu");
                });

            migrationBuilder.CreateTable(
                name: "Produkty_Dla_Etapu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stan = table.Column<bool>(type: "bit", nullable: false),
                    id_etapu = table.Column<int>(type: "int", nullable: false),
                    id_produktu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty_Dla_Etapu", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produkty_Dla_Etapu_8_1",
                        column: x => x.id_produktu,
                        principalTable: "Produkty",
                        principalColumn: "id_produktu");
                    table.ForeignKey(
                        name: "FK_Produkty_Dla_Etapu_9",
                        column: x => x.id_etapu,
                        principalTable: "Etapy",
                        principalColumn: "id_etapu");
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id_statusu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stan = table.Column<bool>(type: "bit", nullable: false),
                    id_zlecenia = table.Column<int>(type: "int", nullable: false),
                    id_produktu = table.Column<int>(type: "int", nullable: false),
                    id_pracownika = table.Column<int>(type: "int", nullable: false),
                    id_etapu = table.Column<int>(type: "int", nullable: false),
                    id_maszyny = table.Column<int>(type: "int", nullable: false),
                    data_rozpoczecia = table.Column<DateTime>(type: "date", nullable: false),
                    data_zakonczenia = table.Column<DateTime>(type: "date", nullable: false),
                    notatki = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_1", x => x.id_statusu);
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
                name: "IX_Etapy_id_produktu",
                table: "Etapy",
                column: "id_produktu");

            migrationBuilder.CreateIndex(
                name: "IX_Konties_id_pracownika",
                table: "Konties",
                column: "id_pracownika");

            migrationBuilder.CreateIndex(
                name: "FK_Produkty_Dla_Etapu_2",
                table: "Produkty_Dla_Etapu",
                column: "id_produktu");

            migrationBuilder.CreateIndex(
                name: "FK_Produkty_Dla_Etapu_3",
                table: "Produkty_Dla_Etapu",
                column: "id_etapu");

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
                name: "IX_Zlecenia_id_produktu",
                table: "Zlecenia",
                column: "id_produktu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konties");

            migrationBuilder.DropTable(
                name: "Produkty_Dla_Etapu");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Etapy");

            migrationBuilder.DropTable(
                name: "Maszyny");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Zlecenia");

            migrationBuilder.DropTable(
                name: "Produkty");
        }
    }
}
