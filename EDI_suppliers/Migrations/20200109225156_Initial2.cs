using Microsoft.EntityFrameworkCore.Migrations;

namespace EDI_suppliers.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEdi",
                table: "ConnectionEdi");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ConnectionEdi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ConnectionEdi");

            migrationBuilder.AddColumn<string>(
                name: "NameEdi",
                table: "ConnectionEdi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
