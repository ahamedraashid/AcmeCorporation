using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class ProductDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "EndingTime", "InitialBid", "IsDeleted", "Name", "StartingTime", "Status" },
                values: new object[,]
                {
                    { 100, "OnePlus 8 Pro Original, Sealed pack, Global Version, 1 Year Software Warranty Easy payment scheme available for upto 36 months for Credit card holders* • 6.78 inches 3168 x 1440 pixels 513 ppi AMOLED Display • OxygenOS based on Android™ 10", new DateTime(2021, 1, 1, 1, 50, 29, 592, DateTimeKind.Local).AddTicks(1235), 100000m, false, "ONEPLUS 8 PRO BRANDNEW 12GB RAM 256GB", new DateTime(2020, 12, 29, 1, 50, 29, 592, DateTimeKind.Local).AddTicks(894), 1 },
                    { 101, "Brand New Condition Samsung Galaxy Note 20 Ultra 256/12GB/ Mystic Bronze/ Softlogic Company Warranty Real Pictures of The Device Attached", new DateTime(2020, 12, 30, 1, 50, 29, 592, DateTimeKind.Local).AddTicks(2653), 80000m, false, "Samsung Galaxy Note 20 Ultra 256GB (Used) 12GB", new DateTime(2020, 12, 29, 1, 50, 29, 592, DateTimeKind.Local).AddTicks(2639), 1 },
                    { 102, "100% condition Usa phone Complete set box available 90% battery health No errors at all 3u tool report", new DateTime(2021, 1, 2, 1, 50, 29, 592, DateTimeKind.Local).AddTicks(2689), 120000m, false, "Iphone XS Max 128GB (Brandew condition)", new DateTime(2020, 12, 30, 1, 50, 29, 592, DateTimeKind.Local).AddTicks(2687), 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 100,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 34, 148, 242, 17, 180, 20, 28, 163, 28, 193, 179, 155, 122, 92, 224, 236, 131, 255, 59, 22, 96, 228, 253, 156, 129, 115, 234, 210, 250, 127, 29, 124, 171, 206, 159, 7, 187, 72, 75, 134, 174, 83, 146, 42, 180, 55, 98, 200, 228, 30, 56, 76, 114, 3, 209, 30, 218, 238, 75, 78, 54, 143, 105, 221 }, new byte[] { 221, 128, 78, 251, 154, 250, 224, 219, 92, 158, 248, 98, 197, 43, 87, 46, 246, 156, 200, 138, 59, 164, 138, 17, 101, 42, 245, 216, 18, 178, 130, 56, 222, 29, 168, 195, 144, 86, 10, 49, 103, 237, 228, 106, 8, 240, 68, 157, 200, 131, 99, 72, 255, 85, 54, 95, 176, 151, 164, 242, 72, 41, 234, 81, 126, 251, 145, 101, 130, 102, 23, 220, 49, 25, 180, 230, 215, 121, 237, 7, 249, 123, 101, 226, 126, 15, 18, 16, 27, 8, 157, 20, 30, 217, 185, 201, 49, 167, 45, 168, 224, 51, 48, 200, 4, 183, 242, 171, 29, 96, 151, 204, 122, 90, 28, 145, 98, 1, 37, 91, 5, 45, 173, 77, 236, 7, 51, 162 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 34, 148, 242, 17, 180, 20, 28, 163, 28, 193, 179, 155, 122, 92, 224, 236, 131, 255, 59, 22, 96, 228, 253, 156, 129, 115, 234, 210, 250, 127, 29, 124, 171, 206, 159, 7, 187, 72, 75, 134, 174, 83, 146, 42, 180, 55, 98, 200, 228, 30, 56, 76, 114, 3, 209, 30, 218, 238, 75, 78, 54, 143, 105, 221 }, new byte[] { 221, 128, 78, 251, 154, 250, 224, 219, 92, 158, 248, 98, 197, 43, 87, 46, 246, 156, 200, 138, 59, 164, 138, 17, 101, 42, 245, 216, 18, 178, 130, 56, 222, 29, 168, 195, 144, 86, 10, 49, 103, 237, 228, 106, 8, 240, 68, 157, 200, 131, 99, 72, 255, 85, 54, 95, 176, 151, 164, 242, 72, 41, 234, 81, 126, 251, 145, 101, 130, 102, 23, 220, 49, 25, 180, 230, 215, 121, 237, 7, 249, 123, 101, 226, 126, 15, 18, 16, 27, 8, 157, 20, 30, 217, 185, 201, 49, 167, 45, 168, 224, 51, 48, 200, 4, 183, 242, 171, 29, 96, 151, 204, 122, 90, 28, 145, 98, 1, 37, 91, 5, 45, 173, 77, 236, 7, 51, 162 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 34, 148, 242, 17, 180, 20, 28, 163, 28, 193, 179, 155, 122, 92, 224, 236, 131, 255, 59, 22, 96, 228, 253, 156, 129, 115, 234, 210, 250, 127, 29, 124, 171, 206, 159, 7, 187, 72, 75, 134, 174, 83, 146, 42, 180, 55, 98, 200, 228, 30, 56, 76, 114, 3, 209, 30, 218, 238, 75, 78, 54, 143, 105, 221 }, new byte[] { 221, 128, 78, 251, 154, 250, 224, 219, 92, 158, 248, 98, 197, 43, 87, 46, 246, 156, 200, 138, 59, 164, 138, 17, 101, 42, 245, 216, 18, 178, 130, 56, 222, 29, 168, 195, 144, 86, 10, 49, 103, 237, 228, 106, 8, 240, 68, 157, 200, 131, 99, 72, 255, 85, 54, 95, 176, 151, 164, 242, 72, 41, 234, 81, 126, 251, 145, 101, 130, 102, 23, 220, 49, 25, 180, 230, 215, 121, 237, 7, 249, 123, 101, 226, 126, 15, 18, 16, 27, 8, 157, 20, 30, 217, 185, 201, 49, 167, 45, 168, 224, 51, 48, 200, 4, 183, 242, 171, 29, 96, 151, 204, 122, 90, 28, 145, 98, 1, 37, 91, 5, 45, 173, 77, 236, 7, 51, 162 } });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Filename", "ProductId" },
                values: new object[,]
                {
                    { 100, "Images/3e80db70-f5cc-45b9-b3d8-524d562e1709.jpg", 100 },
                    { 101, "Images/494d2306-f579-46ad-82d2-44f69347db03.jpg", 100 },
                    { 102, "Images/0576cdc7-5aed-4aa4-9bd2-6fdf63cacd23.jpg", 100 },
                    { 103, "Images/4bd66dfa-8e71-4e80-973a-1410261d73b7.jpg", 101 },
                    { 104, "Images/5dab2566-0fce-4529-877a-06be0282e5e0.jpg", 101 },
                    { 105, "Images/57fd5160-7dea-4c2f-b92c-5b76d73ef8c7.jpg", 101 },
                    { 110, "Images/c6eba157-1f8e-4217-a469-a19c4976bb4c.jpg", 102 },
                    { 111, "Images/cc0ab8d6-b9b9-44b2-90e1-f04cb339d1aa.jpg", 102 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 100,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 165, 80, 236, 182, 230, 111, 122, 177, 15, 237, 143, 255, 251, 118, 157, 85, 150, 46, 198, 192, 200, 137, 122, 118, 37, 9, 210, 52, 38, 110, 227, 18, 253, 169, 221, 159, 118, 41, 57, 30, 127, 72, 202, 239, 189, 8, 172, 52, 26, 248, 78, 121, 238, 134, 52, 99, 173, 122, 144, 160, 121, 177, 56, 203 }, new byte[] { 221, 189, 117, 219, 227, 221, 166, 197, 128, 136, 147, 165, 124, 245, 243, 42, 233, 253, 150, 60, 42, 61, 154, 253, 255, 30, 228, 20, 156, 152, 22, 12, 63, 248, 138, 26, 109, 30, 34, 223, 68, 141, 239, 71, 254, 225, 224, 146, 112, 133, 2, 106, 14, 94, 211, 209, 188, 90, 121, 146, 63, 146, 26, 224, 252, 14, 232, 184, 140, 87, 115, 53, 246, 226, 31, 158, 239, 69, 242, 225, 240, 250, 118, 178, 84, 222, 226, 179, 213, 196, 98, 97, 217, 188, 27, 10, 57, 238, 250, 252, 6, 201, 99, 68, 176, 254, 39, 162, 27, 152, 94, 152, 49, 208, 235, 232, 28, 114, 187, 186, 185, 84, 16, 72, 99, 233, 241, 198 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 101,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 165, 80, 236, 182, 230, 111, 122, 177, 15, 237, 143, 255, 251, 118, 157, 85, 150, 46, 198, 192, 200, 137, 122, 118, 37, 9, 210, 52, 38, 110, 227, 18, 253, 169, 221, 159, 118, 41, 57, 30, 127, 72, 202, 239, 189, 8, 172, 52, 26, 248, 78, 121, 238, 134, 52, 99, 173, 122, 144, 160, 121, 177, 56, 203 }, new byte[] { 221, 189, 117, 219, 227, 221, 166, 197, 128, 136, 147, 165, 124, 245, 243, 42, 233, 253, 150, 60, 42, 61, 154, 253, 255, 30, 228, 20, 156, 152, 22, 12, 63, 248, 138, 26, 109, 30, 34, 223, 68, 141, 239, 71, 254, 225, 224, 146, 112, 133, 2, 106, 14, 94, 211, 209, 188, 90, 121, 146, 63, 146, 26, 224, 252, 14, 232, 184, 140, 87, 115, 53, 246, 226, 31, 158, 239, 69, 242, 225, 240, 250, 118, 178, 84, 222, 226, 179, 213, 196, 98, 97, 217, 188, 27, 10, 57, 238, 250, 252, 6, 201, 99, 68, 176, 254, 39, 162, 27, 152, 94, 152, 49, 208, 235, 232, 28, 114, 187, 186, 185, 84, 16, 72, 99, 233, 241, 198 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 102,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 165, 80, 236, 182, 230, 111, 122, 177, 15, 237, 143, 255, 251, 118, 157, 85, 150, 46, 198, 192, 200, 137, 122, 118, 37, 9, 210, 52, 38, 110, 227, 18, 253, 169, 221, 159, 118, 41, 57, 30, 127, 72, 202, 239, 189, 8, 172, 52, 26, 248, 78, 121, 238, 134, 52, 99, 173, 122, 144, 160, 121, 177, 56, 203 }, new byte[] { 221, 189, 117, 219, 227, 221, 166, 197, 128, 136, 147, 165, 124, 245, 243, 42, 233, 253, 150, 60, 42, 61, 154, 253, 255, 30, 228, 20, 156, 152, 22, 12, 63, 248, 138, 26, 109, 30, 34, 223, 68, 141, 239, 71, 254, 225, 224, 146, 112, 133, 2, 106, 14, 94, 211, 209, 188, 90, 121, 146, 63, 146, 26, 224, 252, 14, 232, 184, 140, 87, 115, 53, 246, 226, 31, 158, 239, 69, 242, 225, 240, 250, 118, 178, 84, 222, 226, 179, 213, 196, 98, 97, 217, 188, 27, 10, 57, 238, 250, 252, 6, 201, 99, 68, 176, 254, 39, 162, 27, 152, 94, 152, 49, 208, 235, 232, 28, 114, 187, 186, 185, 84, 16, 72, 99, 233, 241, 198 } });
        }
    }
}
