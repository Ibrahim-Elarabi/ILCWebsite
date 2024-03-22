using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class addRealtioninSimilarProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSimilar",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SimilarProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSimilar", x => new { x.ProductId, x.SimilarProductId });
                    table.ForeignKey(
                        name: "FK_ProductSimilar_ProductHome_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductHome",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductSimilar_ProductHome_SimilarProductId",
                        column: x => x.SimilarProductId,
                        principalTable: "ProductHome",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSimilar_SimilarProductId",
                table: "ProductSimilar",
                column: "SimilarProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSimilar");
        }
    }
}
