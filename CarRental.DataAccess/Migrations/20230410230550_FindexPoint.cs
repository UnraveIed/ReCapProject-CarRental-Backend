using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DataAccess.Migrations
{
    public partial class FindexPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FindexPoint",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinFindexPoint",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2799), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2806), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2811), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2812) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2815), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2816) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2819), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2824), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2828), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2829) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2832), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2836), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2837) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2841), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2845), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(2845) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "MinFindexPoint", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9445), 1500, (short)2020, new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9447) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "MinFindexPoint", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9514), 1600, (short)2018, new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "MinFindexPoint", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9521), 1750, (short)2022, new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "MinFindexPoint", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9526), 1200, (short)2021, new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "MinFindexPoint", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9534), 1100, (short)2015, new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "MinFindexPoint", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9540), 1150, (short)2022, new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9541) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(4795), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(4796) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(4800), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(4801) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(4805), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "FindexPoint", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1021), 1750, new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1022) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "FindexPoint", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1027), 1000, new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1028) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(5233), new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(5234), new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(5240), new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(5241), new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(8247), new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(8248), new byte[] { 158, 60, 12, 126, 18, 12, 77, 134, 30, 61, 53, 70, 199, 97, 178, 255, 122, 240, 227, 118, 2, 227, 231, 206, 198, 174, 46, 77, 8, 72, 105, 11, 67, 226, 96, 223, 26, 245, 189, 188, 249, 32, 156, 100, 168, 68, 224, 76, 146, 137, 45, 210, 184, 87, 143, 169, 17, 213, 108, 44, 145, 101, 86, 190 }, new byte[] { 220, 195, 246, 239, 20, 173, 168, 126, 105, 127, 79, 200, 199, 34, 255, 242, 57, 158, 238, 3, 68, 15, 39, 101, 55, 129, 108, 173, 110, 198, 220, 2, 67, 75, 22, 174, 66, 152, 230, 140, 187, 40, 76, 95, 13, 12, 12, 108, 177, 239, 212, 170, 156, 86, 31, 184, 47, 155, 109, 129, 112, 193, 22, 96, 194, 205, 157, 80, 28, 52, 114, 76, 160, 78, 131, 134, 170, 145, 146, 40, 36, 51, 31, 122, 228, 146, 121, 115, 97, 28, 41, 227, 221, 136, 186, 180, 221, 55, 214, 23, 156, 229, 32, 131, 221, 184, 76, 44, 33, 230, 199, 208, 167, 193, 243, 248, 167, 18, 186, 154, 228, 225, 121, 85, 227, 5, 25, 6 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(8254), new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(8255), new byte[] { 158, 60, 12, 126, 18, 12, 77, 134, 30, 61, 53, 70, 199, 97, 178, 255, 122, 240, 227, 118, 2, 227, 231, 206, 198, 174, 46, 77, 8, 72, 105, 11, 67, 226, 96, 223, 26, 245, 189, 188, 249, 32, 156, 100, 168, 68, 224, 76, 146, 137, 45, 210, 184, 87, 143, 169, 17, 213, 108, 44, 145, 101, 86, 190 }, new byte[] { 220, 195, 246, 239, 20, 173, 168, 126, 105, 127, 79, 200, 199, 34, 255, 242, 57, 158, 238, 3, 68, 15, 39, 101, 55, 129, 108, 173, 110, 198, 220, 2, 67, 75, 22, 174, 66, 152, 230, 140, 187, 40, 76, 95, 13, 12, 12, 108, 177, 239, 212, 170, 156, 86, 31, 184, 47, 155, 109, 129, 112, 193, 22, 96, 194, 205, 157, 80, 28, 52, 114, 76, 160, 78, 131, 134, 170, 145, 146, 40, 36, 51, 31, 122, 228, 146, 121, 115, 97, 28, 41, 227, 221, 136, 186, 180, 221, 55, 214, 23, 156, 229, 32, 131, 221, 184, 76, 44, 33, 230, 199, 208, 167, 193, 243, 248, 167, 18, 186, 154, 228, 225, 121, 85, 227, 5, 25, 6 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(8259), new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(8260), new byte[] { 158, 60, 12, 126, 18, 12, 77, 134, 30, 61, 53, 70, 199, 97, 178, 255, 122, 240, 227, 118, 2, 227, 231, 206, 198, 174, 46, 77, 8, 72, 105, 11, 67, 226, 96, 223, 26, 245, 189, 188, 249, 32, 156, 100, 168, 68, 224, 76, 146, 137, 45, 210, 184, 87, 143, 169, 17, 213, 108, 44, 145, 101, 86, 190 }, new byte[] { 220, 195, 246, 239, 20, 173, 168, 126, 105, 127, 79, 200, 199, 34, 255, 242, 57, 158, 238, 3, 68, 15, 39, 101, 55, 129, 108, 173, 110, 198, 220, 2, 67, 75, 22, 174, 66, 152, 230, 140, 187, 40, 76, 95, 13, 12, 12, 108, 177, 239, 212, 170, 156, 86, 31, 184, 47, 155, 109, 129, 112, 193, 22, 96, 194, 205, 157, 80, 28, 52, 114, 76, 160, 78, 131, 134, 170, 145, 146, 40, 36, 51, 31, 122, 228, 146, 121, 115, 97, 28, 41, 227, 221, 136, 186, 180, 221, 55, 214, 23, 156, 229, 32, 131, 221, 184, 76, 44, 33, 230, 199, 208, 167, 193, 243, 248, 167, 18, 186, 154, 228, 225, 121, 85, 227, 5, 25, 6 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FindexPoint",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MinFindexPoint",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9340), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9341) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9343), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9344) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9345), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9348), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9353), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9353) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9355), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9358), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9358) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9360), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9361) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9363), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9365), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9365) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9367), new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9368) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3035), (short)2019, new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3036) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3039), (short)2017, new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3043), (short)2021, new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3044) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3048), (short)2020, new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3049) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3051), (short)2014, new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3052) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModelYear", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3055), (short)2021, new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3055) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(431), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(432) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(434), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(435) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(437), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4088), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4091), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6533), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6534), new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6538), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6539), new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8449), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8450), new byte[] { 219, 211, 86, 29, 23, 181, 237, 84, 2, 240, 114, 15, 56, 4, 192, 67, 8, 225, 79, 177, 92, 236, 207, 167, 125, 114, 227, 11, 163, 195, 56, 136, 188, 170, 100, 17, 63, 40, 116, 254, 47, 147, 93, 236, 149, 57, 97, 31, 252, 87, 124, 72, 48, 116, 186, 108, 245, 221, 93, 60, 52, 0, 71, 163 }, new byte[] { 206, 13, 105, 42, 25, 71, 145, 47, 222, 114, 219, 125, 83, 239, 190, 66, 162, 209, 7, 47, 171, 246, 41, 134, 8, 223, 70, 8, 233, 133, 157, 205, 238, 97, 114, 14, 188, 113, 55, 187, 96, 131, 241, 203, 190, 183, 254, 163, 200, 173, 244, 109, 200, 36, 179, 145, 171, 76, 147, 228, 94, 210, 133, 164, 175, 89, 214, 149, 10, 105, 4, 235, 229, 58, 184, 16, 26, 200, 89, 42, 161, 222, 14, 53, 61, 232, 213, 68, 59, 57, 132, 99, 9, 5, 68, 239, 110, 133, 186, 96, 99, 100, 48, 12, 45, 42, 255, 204, 78, 30, 63, 131, 63, 238, 124, 201, 215, 111, 158, 8, 66, 181, 162, 97, 22, 127, 238, 214 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8452), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8453), new byte[] { 219, 211, 86, 29, 23, 181, 237, 84, 2, 240, 114, 15, 56, 4, 192, 67, 8, 225, 79, 177, 92, 236, 207, 167, 125, 114, 227, 11, 163, 195, 56, 136, 188, 170, 100, 17, 63, 40, 116, 254, 47, 147, 93, 236, 149, 57, 97, 31, 252, 87, 124, 72, 48, 116, 186, 108, 245, 221, 93, 60, 52, 0, 71, 163 }, new byte[] { 206, 13, 105, 42, 25, 71, 145, 47, 222, 114, 219, 125, 83, 239, 190, 66, 162, 209, 7, 47, 171, 246, 41, 134, 8, 223, 70, 8, 233, 133, 157, 205, 238, 97, 114, 14, 188, 113, 55, 187, 96, 131, 241, 203, 190, 183, 254, 163, 200, 173, 244, 109, 200, 36, 179, 145, 171, 76, 147, 228, 94, 210, 133, 164, 175, 89, 214, 149, 10, 105, 4, 235, 229, 58, 184, 16, 26, 200, 89, 42, 161, 222, 14, 53, 61, 232, 213, 68, 59, 57, 132, 99, 9, 5, 68, 239, 110, 133, 186, 96, 99, 100, 48, 12, 45, 42, 255, 204, 78, 30, 63, 131, 63, 238, 124, 201, 215, 111, 158, 8, 66, 181, 162, 97, 22, 127, 238, 214 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8455), new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8456), new byte[] { 219, 211, 86, 29, 23, 181, 237, 84, 2, 240, 114, 15, 56, 4, 192, 67, 8, 225, 79, 177, 92, 236, 207, 167, 125, 114, 227, 11, 163, 195, 56, 136, 188, 170, 100, 17, 63, 40, 116, 254, 47, 147, 93, 236, 149, 57, 97, 31, 252, 87, 124, 72, 48, 116, 186, 108, 245, 221, 93, 60, 52, 0, 71, 163 }, new byte[] { 206, 13, 105, 42, 25, 71, 145, 47, 222, 114, 219, 125, 83, 239, 190, 66, 162, 209, 7, 47, 171, 246, 41, 134, 8, 223, 70, 8, 233, 133, 157, 205, 238, 97, 114, 14, 188, 113, 55, 187, 96, 131, 241, 203, 190, 183, 254, 163, 200, 173, 244, 109, 200, 36, 179, 145, 171, 76, 147, 228, 94, 210, 133, 164, 175, 89, 214, 149, 10, 105, 4, 235, 229, 58, 184, 16, 26, 200, 89, 42, 161, 222, 14, 53, 61, 232, 213, 68, 59, 57, 132, 99, 9, 5, 68, 239, 110, 133, 186, 96, 99, 100, 48, 12, 45, 42, 255, 204, 78, 30, 63, 131, 63, 238, 124, 201, 215, 111, 158, 8, 66, 181, 162, 97, 22, 127, 238, 214 } });
        }
    }
}
