using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class RemovedProductStatusId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
