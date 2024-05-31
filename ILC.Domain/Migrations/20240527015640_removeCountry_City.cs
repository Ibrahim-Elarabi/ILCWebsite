using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class removeCountry_City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inquiry_City_CityId",
                table: "Inquiry");

            migrationBuilder.DropForeignKey(
                name: "FK_Inquiry_Country_CountryId",
                table: "Inquiry");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Inquiry_CityId",
                table: "Inquiry");

            migrationBuilder.DropIndex(
                name: "IX_Inquiry_CountryId",
                table: "Inquiry");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Inquiry");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Inquiry");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Inquiry",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Inquiry",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Inquiry");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Inquiry");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Inquiry",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Inquiry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_CityId",
                table: "Inquiry",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiry_CountryId",
                table: "Inquiry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiry_City_CityId",
                table: "Inquiry",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inquiry_Country_CountryId",
                table: "Inquiry",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }
    }
}
