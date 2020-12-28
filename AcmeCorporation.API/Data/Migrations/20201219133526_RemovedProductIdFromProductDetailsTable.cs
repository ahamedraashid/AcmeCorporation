using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class RemovedProductIdFromProductDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDetailId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products",
                column: "ProductDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "ProductDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductDetailId1",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDetailId1",
                table: "Products",
                column: "ProductDetailId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId1",
                table: "Products",
                column: "ProductDetailId1",
                principalTable: "ProductDetails",
                principalColumn: "ProductDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
