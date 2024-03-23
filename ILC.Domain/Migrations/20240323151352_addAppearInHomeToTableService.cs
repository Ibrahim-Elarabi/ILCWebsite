using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class addAppearInHomeToTableService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AppearInHome",
                table: "ServiceHome",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppearInHome",
                table: "ServiceHome");
        }
    }
}
