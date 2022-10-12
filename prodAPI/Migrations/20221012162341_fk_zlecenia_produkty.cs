using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prodAPI.Migrations
{
    public partial class fk_zlecenia_produkty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Produkty",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenia_Produkty_IdProduktuNavigationIdProduktu",
                table: "Zlecenia");

            migrationBuilder.DropIndex(
                name: "IX_Zlecenia_IdProduktuNavigationIdProduktu",
                table: "Zlecenia");

            migrationBuilder.DropIndex(
                name: "IX_Status_id_produktu",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "IdProduktuNavigationIdProduktu",
                table: "Zlecenia");

            migrationBuilder.DropColumn(
                name: "id_produktu",
                table: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "ilosc",
                table: "Zlecenia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_produktu",
                table: "Zlecenia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Zlecenia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_id_produktu",
                table: "Zlecenia",
                column: "id_produktu");

            migrationBuilder.AddForeignKey(
                name: "FK_Zlecenia_Produkty",
                table: "Zlecenia",
                column: "id_produktu",
                principalTable: "Produkty",
                principalColumn: "id_produktu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenia_Produkty",
                table: "Zlecenia");

            migrationBuilder.DropIndex(
                name: "IX_Zlecenia_id_produktu",
                table: "Zlecenia");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Zlecenia");

            migrationBuilder.AlterColumn<int>(
                name: "ilosc",
                table: "Zlecenia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_produktu",
                table: "Zlecenia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdProduktuNavigationIdProduktu",
                table: "Zlecenia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_produktu",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_IdProduktuNavigationIdProduktu",
                table: "Zlecenia",
                column: "IdProduktuNavigationIdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_Status_id_produktu",
                table: "Status",
                column: "id_produktu");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Produkty",
                table: "Status",
                column: "id_produktu",
                principalTable: "Produkty",
                principalColumn: "id_produktu");

            migrationBuilder.AddForeignKey(
                name: "FK_Zlecenia_Produkty_IdProduktuNavigationIdProduktu",
                table: "Zlecenia",
                column: "IdProduktuNavigationIdProduktu",
                principalTable: "Produkty",
                principalColumn: "id_produktu");
        }
    }
}
