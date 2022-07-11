using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prodAPI.Migrations
{
    public partial class sneed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Konta",
                table: "Konta");

            migrationBuilder.RenameTable(
                name: "Konta",
                newName: "Konties");

            migrationBuilder.RenameIndex(
                name: "IX_Konta_id_pracownika",
                table: "Konties",
                newName: "IX_Konties_id_pracownika");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Konties",
                table: "Konties",
                column: "id_konta");

            migrationBuilder.InsertData(
                table: "Produkty",
                columns: new[] { "id_produktu", "nazwa" },
                values: new object[] { 1, "Prod1" });

            migrationBuilder.InsertData(
                table: "Produkty",
                columns: new[] { "id_produktu", "nazwa" },
                values: new object[] { 2, "Prod2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Konties",
                table: "Konties");

            migrationBuilder.DeleteData(
                table: "Produkty",
                keyColumn: "id_produktu",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produkty",
                keyColumn: "id_produktu",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Konties",
                newName: "Konta");

            migrationBuilder.RenameIndex(
                name: "IX_Konties_id_pracownika",
                table: "Konta",
                newName: "IX_Konta_id_pracownika");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Konta",
                table: "Konta",
                column: "id_konta");
        }
    }
}
