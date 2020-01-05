using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI_suppliers.Migrations
{
    public partial class SupplierMFGaktualizace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MfgId",
                table: "SupplierMFG",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MfgId",
                table: "SupplierMFG",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
