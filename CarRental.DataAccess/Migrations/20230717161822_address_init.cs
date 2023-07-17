using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DataAccess.Migrations
{
    public partial class address_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressDesc = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressDesc", "AddressTitle", "City", "Country", "CreatedByName", "CreatedDate", "CustomerId", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note" },
                values: new object[,]
                {
                    { 1, "Cumhuriyet Mahallesi Olgun Sokak Selcuklu", "Ev", "Konya", "Turkey", "InitialCreate", new DateTime(2023, 7, 17, 19, 18, 22, 195, DateTimeKind.Local).AddTicks(1378), 1, true, false, "InitialCreate", new DateTime(2023, 7, 17, 19, 18, 22, 195, DateTimeKind.Local).AddTicks(1379), "Adres Bilgisi" },
                    { 2, "Yeniyol Meram", "İş", "Konya", "Turkey", "InitialCreate", new DateTime(2023, 7, 17, 19, 18, 22, 195, DateTimeKind.Local).AddTicks(1381), 1, true, false, "InitialCreate", new DateTime(2023, 7, 17, 19, 18, 22, 195, DateTimeKind.Local).AddTicks(1382), "Adres Bilgisi" }
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(782), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(787), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(791), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(792) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(799), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(803), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(804) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(807), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(808) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(811), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(812) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(815), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(816) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(818), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(819) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(821), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(824), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(824) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9421), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9427), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9428) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9432), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9436), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9436) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9459), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9464), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(2088), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(2089) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(2092), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(2095), new DateTime(2023, 7, 17, 19, 18, 22, 193, DateTimeKind.Local).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(1445), new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(1446) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(1449), new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(1449) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(4913), new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(4914), new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "RentDate", "ReturnDate" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(4918), new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(4919), new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(7065), new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(7066), new byte[] { 235, 29, 25, 226, 155, 159, 65, 176, 250, 92, 250, 58, 47, 173, 72, 45, 168, 255, 250, 88, 195, 64, 63, 50, 102, 59, 92, 165, 165, 170, 139, 185, 196, 20, 112, 185, 55, 38, 11, 65, 69, 165, 173, 245, 122, 190, 118, 113, 49, 35, 10, 36, 227, 4, 18, 229, 87, 192, 120, 118, 78, 215, 148, 91 }, new byte[] { 142, 222, 72, 6, 47, 113, 210, 18, 10, 178, 188, 213, 195, 241, 157, 95, 45, 251, 98, 116, 214, 180, 221, 87, 77, 217, 68, 142, 96, 157, 110, 111, 208, 233, 222, 95, 107, 189, 167, 7, 182, 147, 209, 12, 114, 113, 161, 129, 16, 242, 77, 131, 122, 89, 234, 156, 78, 239, 228, 149, 169, 76, 69, 237, 98, 48, 199, 27, 125, 11, 234, 1, 214, 188, 79, 196, 130, 147, 203, 26, 142, 248, 45, 29, 218, 212, 211, 120, 8, 154, 194, 105, 238, 52, 85, 138, 55, 99, 123, 137, 10, 204, 116, 92, 57, 99, 37, 174, 81, 254, 25, 209, 112, 63, 140, 119, 123, 213, 146, 231, 70, 39, 105, 100, 121, 201, 221, 218 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(7069), new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(7070), new byte[] { 235, 29, 25, 226, 155, 159, 65, 176, 250, 92, 250, 58, 47, 173, 72, 45, 168, 255, 250, 88, 195, 64, 63, 50, 102, 59, 92, 165, 165, 170, 139, 185, 196, 20, 112, 185, 55, 38, 11, 65, 69, 165, 173, 245, 122, 190, 118, 113, 49, 35, 10, 36, 227, 4, 18, 229, 87, 192, 120, 118, 78, 215, 148, 91 }, new byte[] { 142, 222, 72, 6, 47, 113, 210, 18, 10, 178, 188, 213, 195, 241, 157, 95, 45, 251, 98, 116, 214, 180, 221, 87, 77, 217, 68, 142, 96, 157, 110, 111, 208, 233, 222, 95, 107, 189, 167, 7, 182, 147, 209, 12, 114, 113, 161, 129, 16, 242, 77, 131, 122, 89, 234, 156, 78, 239, 228, 149, 169, 76, 69, 237, 98, 48, 199, 27, 125, 11, 234, 1, 214, 188, 79, 196, 130, 147, 203, 26, 142, 248, 45, 29, 218, 212, 211, 120, 8, 154, 194, 105, 238, 52, 85, 138, 55, 99, 123, 137, 10, 204, 116, 92, 57, 99, 37, 174, 81, 254, 25, 209, 112, 63, 140, 119, 123, 213, 146, 231, 70, 39, 105, 100, 121, 201, 221, 218 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(7072), new DateTime(2023, 7, 17, 19, 18, 22, 194, DateTimeKind.Local).AddTicks(7073), new byte[] { 235, 29, 25, 226, 155, 159, 65, 176, 250, 92, 250, 58, 47, 173, 72, 45, 168, 255, 250, 88, 195, 64, 63, 50, 102, 59, 92, 165, 165, 170, 139, 185, 196, 20, 112, 185, 55, 38, 11, 65, 69, 165, 173, 245, 122, 190, 118, 113, 49, 35, 10, 36, 227, 4, 18, 229, 87, 192, 120, 118, 78, 215, 148, 91 }, new byte[] { 142, 222, 72, 6, 47, 113, 210, 18, 10, 178, 188, 213, 195, 241, 157, 95, 45, 251, 98, 116, 214, 180, 221, 87, 77, 217, 68, 142, 96, 157, 110, 111, 208, 233, 222, 95, 107, 189, 167, 7, 182, 147, 209, 12, 114, 113, 161, 129, 16, 242, 77, 131, 122, 89, 234, 156, 78, 239, 228, 149, 169, 76, 69, 237, 98, 48, 199, 27, 125, 11, 234, 1, 214, 188, 79, 196, 130, 147, 203, 26, 142, 248, 45, 29, 218, 212, 211, 120, 8, 154, 194, 105, 238, 52, 85, 138, 55, 99, 123, 137, 10, 204, 116, 92, 57, 99, 37, 174, 81, 254, 25, 209, 112, 63, 140, 119, 123, 213, 146, 231, 70, 39, 105, 100, 121, 201, 221, 218 } });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

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
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9445), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9447) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9514), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9521), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9526), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9534), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9540), new DateTime(2023, 4, 11, 2, 5, 49, 844, DateTimeKind.Local).AddTicks(9541) });

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
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1021), new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1022) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1027), new DateTime(2023, 4, 11, 2, 5, 49, 845, DateTimeKind.Local).AddTicks(1028) });

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
    }
}
