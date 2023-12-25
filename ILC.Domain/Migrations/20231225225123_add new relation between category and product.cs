using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class addnewrelationbetweencategoryandproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductHome",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAppearInHome",
                table: "ProductHome",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductHome_CategoryId",
                table: "ProductHome",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHome_Category_CategoryId",
                table: "ProductHome",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHome_Category_CategoryId",
                table: "ProductHome");

            migrationBuilder.DropIndex(
                name: "IX_ProductHome_CategoryId",
                table: "ProductHome");

           
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductHome");

            migrationBuilder.DropColumn(
                name: "IsAppearInHome",
                table: "ProductHome");
        }
    }
}
