using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class addnewTableSimilarProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimilarProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SimilarProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimilarProduct_ProductHome_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductHome",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimilarProduct_ProductId",
                table: "SimilarProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarProduct");
        }
    }
}
