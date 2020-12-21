using Microsoft.EntityFrameworkCore.Migrations;

namespace GuiEksamen.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 254, nullable: false),
                    PwHash = table.Column<string>(maxLength: 60, nullable: true),
                    IsManager = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    EfManagerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EfAccountId = table.Column<long>(nullable: false),
                    AccountEmail = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 64, nullable: true),
                    LastName = table.Column<string>(maxLength: 32, nullable: true),
                    Email = table.Column<string>(maxLength: 254, nullable: true),
                    Freq = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.EfManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_Accounts_AccountEmail",
                        column: x => x.AccountEmail,
                        principalTable: "Accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_AccountEmail",
                table: "Managers",
                column: "AccountEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Email",
                table: "Managers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
