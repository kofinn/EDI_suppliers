using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI_suppliers.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Plant",
                table: "Supplier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Plant",
                table: "Supplier",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
