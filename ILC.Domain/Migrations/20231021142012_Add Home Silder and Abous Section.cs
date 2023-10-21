using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class AddHomeSilderandAbousSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUsHome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsHome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SilderHome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstHeadTextEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstHeadTextAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondtHeadTextEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondHeadTextAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParagraphEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParagraphAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SilderHome", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUsHome");

            migrationBuilder.DropTable(
                name: "SilderHome");
        }
    }
}
