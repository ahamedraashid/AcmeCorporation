﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "ContactNumber", "EmailAddress", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 102, null, null, "johnwick@gmail.com", new byte[] { 71, 161, 160, 10, 49, 188, 255, 143, 201, 92, 207, 70, 231, 236, 57, 186, 177, 18, 206, 209, 208, 94, 225, 153, 3, 98, 102, 235, 165, 86, 94, 178, 138, 208, 36, 148, 61, 205, 167, 253, 208, 86, 213, 74, 224, 40, 226, 230, 121, 132, 132, 137, 99, 247, 220, 165, 183, 175, 62, 93, 78, 194, 122, 181 }, new byte[] { 191, 63, 116, 252, 2, 200, 22, 208, 144, 255, 175, 244, 46, 96, 156, 110, 152, 245, 167, 176, 90, 19, 17, 144, 94, 123, 132, 28, 197, 238, 135, 233, 20, 255, 86, 106, 181, 214, 117, 11, 250, 64, 81, 7, 211, 113, 243, 46, 18, 1, 173, 196, 52, 117, 213, 126, 102, 174, 181, 134, 210, 13, 44, 14, 82, 214, 50, 157, 100, 92, 141, 67, 37, 24, 238, 98, 140, 229, 10, 78, 214, 175, 84, 248, 115, 132, 163, 42, 94, 136, 200, 66, 216, 208, 253, 3, 141, 130, 249, 22, 236, 254, 203, 20, 115, 189, 56, 157, 151, 137, 84, 165, 248, 157, 247, 95, 22, 18, 81, 47, 253, 237, 162, 11, 192, 89, 192, 109 }, 1, "John Wick" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "ContactNumber", "EmailAddress", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 100, null, null, "paterpark@gmail.com", new byte[] { 71, 161, 160, 10, 49, 188, 255, 143, 201, 92, 207, 70, 231, 236, 57, 186, 177, 18, 206, 209, 208, 94, 225, 153, 3, 98, 102, 235, 165, 86, 94, 178, 138, 208, 36, 148, 61, 205, 167, 253, 208, 86, 213, 74, 224, 40, 226, 230, 121, 132, 132, 137, 99, 247, 220, 165, 183, 175, 62, 93, 78, 194, 122, 181 }, new byte[] { 191, 63, 116, 252, 2, 200, 22, 208, 144, 255, 175, 244, 46, 96, 156, 110, 152, 245, 167, 176, 90, 19, 17, 144, 94, 123, 132, 28, 197, 238, 135, 233, 20, 255, 86, 106, 181, 214, 117, 11, 250, 64, 81, 7, 211, 113, 243, 46, 18, 1, 173, 196, 52, 117, 213, 126, 102, 174, 181, 134, 210, 13, 44, 14, 82, 214, 50, 157, 100, 92, 141, 67, 37, 24, 238, 98, 140, 229, 10, 78, 214, 175, 84, 248, 115, 132, 163, 42, 94, 136, 200, 66, 216, 208, 253, 3, 141, 130, 249, 22, 236, 254, 203, 20, 115, 189, 56, 157, 151, 137, 84, 165, 248, 157, 247, 95, 22, 18, 81, 47, 253, 237, 162, 11, 192, 89, 192, 109 }, 2, "Peter Park" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "ContactNumber", "EmailAddress", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 101, null, null, "jason@gmail.com", new byte[] { 71, 161, 160, 10, 49, 188, 255, 143, 201, 92, 207, 70, 231, 236, 57, 186, 177, 18, 206, 209, 208, 94, 225, 153, 3, 98, 102, 235, 165, 86, 94, 178, 138, 208, 36, 148, 61, 205, 167, 253, 208, 86, 213, 74, 224, 40, 226, 230, 121, 132, 132, 137, 99, 247, 220, 165, 183, 175, 62, 93, 78, 194, 122, 181 }, new byte[] { 191, 63, 116, 252, 2, 200, 22, 208, 144, 255, 175, 244, 46, 96, 156, 110, 152, 245, 167, 176, 90, 19, 17, 144, 94, 123, 132, 28, 197, 238, 135, 233, 20, 255, 86, 106, 181, 214, 117, 11, 250, 64, 81, 7, 211, 113, 243, 46, 18, 1, 173, 196, 52, 117, 213, 126, 102, 174, 181, 134, 210, 13, 44, 14, 82, 214, 50, 157, 100, 92, 141, 67, 37, 24, 238, 98, 140, 229, 10, 78, 214, 175, 84, 248, 115, 132, 163, 42, 94, 136, 200, 66, 216, 208, 253, 3, 141, 130, 249, 22, 236, 254, 203, 20, 115, 189, 56, 157, 151, 137, 84, 165, 248, 157, 247, 95, 22, 18, 81, 47, 253, 237, 162, 11, 192, 89, 192, 109 }, 2, "Jason Statham" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 102);
        }
    }
}
