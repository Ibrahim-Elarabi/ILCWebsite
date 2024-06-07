using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class addAppearInhome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AppearInHome",
                table: "StaffHome",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "StaffHome",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppearInHome",
                table: "StaffHome");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "StaffHome");
        }
    }
}
