using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class addAppearInHomeToTableBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AppearInHome",
                table: "BlogHome",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppearInHome",
                table: "BlogHome");
        }
    }
}
