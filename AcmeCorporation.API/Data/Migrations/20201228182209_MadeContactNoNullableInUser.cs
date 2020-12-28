using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class MadeContactNoNullableInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContactNumber",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContactNumber",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
