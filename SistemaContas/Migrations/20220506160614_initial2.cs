using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaContas.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Earning");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Debts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bills",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Earning",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
