using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prodAPI.Migrations
{
    public partial class struktury : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "czas",
                table: "Etapy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StrukturyWyrobu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduktu = table.Column<int>(type: "int", nullable: false),
                    IdEtapu = table.Column<int>(type: "int", nullable: false),
                    Kolejnosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrukturyWyrobu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrukturyWyrobu_Etapy_IdEtapu",
                        column: x => x.IdEtapu,
                        principalTable: "Etapy",
                        principalColumn: "id_etapu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrukturyWyrobu_Produkty_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkty",
                        principalColumn: "id_produktu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrukturyWyrobu_IdEtapuNavigationIdEtapu",
                table: "StrukturyWyrobu",
                column: "IdEtapu");

            migrationBuilder.CreateIndex(
                name: "IX_StrukturyWyrobu_IdProduktuNavigationIdProduktu",
                table: "StrukturyWyrobu",
                column: "IdProduktu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrukturyWyrobu");

            migrationBuilder.DropColumn(
                name: "czas",
                table: "Etapy");
        }
    }
}
