using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class RemovedDurationTimeAndValueFromProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DurationValue",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationUnit",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationValue",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
