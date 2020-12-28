using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class RemovedProductDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDetails_ProductDetailId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDetailId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductDetailId",
                table: "Products",
                newName: "DurationValue");

            migrationBuilder.AddColumn<int>(
                name: "DurationUnit",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InitialPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "DurationValue",
                table: "Products",
                newName: "ProductDetailId");

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProductDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DurationUnit = table.Column<int>(nullable: false),
                    DurationValue = table.Column<int>(nullable: false),
                    InitialPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ProductDetailId);
                });

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
    }
}
