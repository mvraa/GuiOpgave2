using Microsoft.EntityFrameworkCore.Migrations;

namespace GuiEksamen.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EfManagerId",
                table: "Managers");

            migrationBuilder.AddColumn<long>(
                name: "EfUserId",
                table: "Managers",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "EfUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EfUserId",
                table: "Managers");

            migrationBuilder.AddColumn<long>(
                name: "EfManagerId",
                table: "Managers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "EfManagerId");
        }
    }
}
