using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class AddedStartingTimeToProductTAble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InitialPrice",
                table: "Products",
                newName: "InitialBid");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingTime",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "InitialBid",
                table: "Products",
                newName: "InitialPrice");
        }
    }
}
