using Microsoft.EntityFrameworkCore.Migrations;

namespace GuiEksamen.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Managers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Freq",
                table: "Managers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "Managers");
        }
    }
}
