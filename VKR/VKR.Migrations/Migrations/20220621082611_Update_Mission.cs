using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.Migrations.Migrations
{
    public partial class Update_Mission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Template",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tests",
                table: "Mission",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Template",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "Tests",
                table: "Mission");
        }
    }
}
