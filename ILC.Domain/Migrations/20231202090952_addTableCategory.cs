using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class addTableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");
        }
    }
}
