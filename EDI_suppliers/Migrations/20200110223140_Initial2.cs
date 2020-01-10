using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI_suppliers.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierMFG",
                table: "SupplierMFG");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "SupplierMFG");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SupplierMFG",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierMFG",
                table: "SupplierMFG",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierMFG",
                table: "SupplierMFG");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SupplierMFG");

            migrationBuilder.AddColumn<string>(
                name: "SupplierId",
                table: "SupplierMFG",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierMFG",
                table: "SupplierMFG",
                column: "SupplierId");
        }
    }
}
