using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prodAPI.Migrations
{
    public partial class awariadto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_zakonczenia",
                table: "Zlecenia",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_rozpoczecia",
                table: "Zlecenia",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_przegladu",
                table: "Maszyny",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_awarii",
                table: "Maszyny",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Awaria",
                columns: table => new
                {
                    id_awarii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stan = table.Column<bool>(type: "bit", nullable: false),
                    data_rozpoczecia = table.Column<DateTime>(type: "datetime", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awaria", x => x.id_awarii);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maszyny_id_awarii",
                table: "Maszyny",
                column: "id_awarii");

            migrationBuilder.AddForeignKey(
                name: "FK_Maszyny_Awaria",
                table: "Maszyny",
                column: "id_awarii",
                principalTable: "Awaria",
                principalColumn: "id_awarii");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maszyny_Awaria",
                table: "Maszyny");

            migrationBuilder.DropTable(
                name: "Awaria");

            migrationBuilder.DropIndex(
                name: "IX_Maszyny_id_awarii",
                table: "Maszyny");

            migrationBuilder.DropColumn(
                name: "id_awarii",
                table: "Maszyny");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_zakonczenia",
                table: "Zlecenia",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_rozpoczecia",
                table: "Zlecenia",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_przegladu",
                table: "Maszyny",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
