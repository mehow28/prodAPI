using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prodAPI.Migrations
{
    public partial class noIdOnZlecenie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenia_Produkty",
                table: "Zlecenia");

            migrationBuilder.DropIndex(
                name: "IX_Zlecenia_id_produktu",
                table: "Zlecenia");

            migrationBuilder.DropColumn(
                name: "id_produktu",
                table: "Zlecenia");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_zakonczenia",
                table: "Zlecenia",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_rozpoczecia",
                table: "Zlecenia",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "ProduktyDtoIdProduktu",
                table: "Zlecenia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_ProduktyDtoIdProduktu",
                table: "Zlecenia",
                column: "ProduktyDtoIdProduktu");

            migrationBuilder.AddForeignKey(
                name: "FK_Zlecenia_Produkty_ProduktyDtoIdProduktu",
                table: "Zlecenia",
                column: "ProduktyDtoIdProduktu",
                principalTable: "Produkty",
                principalColumn: "id_produktu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zlecenia_Produkty_ProduktyDtoIdProduktu",
                table: "Zlecenia");

            migrationBuilder.DropIndex(
                name: "IX_Zlecenia_ProduktyDtoIdProduktu",
                table: "Zlecenia");

            migrationBuilder.DropColumn(
                name: "ProduktyDtoIdProduktu",
                table: "Zlecenia");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_zakonczenia",
                table: "Zlecenia",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_rozpoczecia",
                table: "Zlecenia",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_produktu",
                table: "Zlecenia",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
