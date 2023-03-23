using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DataAccess.Migrations
{
    public partial class AuthMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
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
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9340), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9341), "Mercedes", "Mercedes Markası" },
                    { 2, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9343), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9344), "BMV", "BMV Markası" },
                    { 3, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9345), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9346), "Lamborghini", "Lamborghini Markası" },
                    { 4, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9348), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9351), "Ferrari", "Ferrari Markası" },
                    { 5, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9353), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9353), "Opel", "Opel Markası" },
                    { 6, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9355), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9356), "Peugeot", "Peugeot Markası" },
                    { 7, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9358), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9358), "Koenigsegg", "Koenigsegg Markası" },
                    { 8, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9360), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9361), "Aston Martin", "Aston Martin Markası" },
                    { 9, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9363), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9363), "Porsche", "Porsche Markası" },
                    { 10, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9365), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9365), "McLaren", "McLaren Markası" },
                    { 11, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9367), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 623, DateTimeKind.Local).AddTicks(9368), "Ford", "Ford Markası" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(431), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(432), "Sarı", "Sarı Rengi" },
                    { 2, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(434), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(435), "Kırmızı", "Kırmızı Rengi" },
                    { 3, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(437), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(437), "Mavi", "Mavi Rengi" }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8449), "batu@inal.com", "Batuhan", true, false, "İnal", "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8450), "User data seed", new byte[] { 219, 211, 86, 29, 23, 181, 237, 84, 2, 240, 114, 15, 56, 4, 192, 67, 8, 225, 79, 177, 92, 236, 207, 167, 125, 114, 227, 11, 163, 195, 56, 136, 188, 170, 100, 17, 63, 40, 116, 254, 47, 147, 93, 236, 149, 57, 97, 31, 252, 87, 124, 72, 48, 116, 186, 108, 245, 221, 93, 60, 52, 0, 71, 163 }, new byte[] { 206, 13, 105, 42, 25, 71, 145, 47, 222, 114, 219, 125, 83, 239, 190, 66, 162, 209, 7, 47, 171, 246, 41, 134, 8, 223, 70, 8, 233, 133, 157, 205, 238, 97, 114, 14, 188, 113, 55, 187, 96, 131, 241, 203, 190, 183, 254, 163, 200, 173, 244, 109, 200, 36, 179, 145, 171, 76, 147, 228, 94, 210, 133, 164, 175, 89, 214, 149, 10, 105, 4, 235, 229, 58, 184, 16, 26, 200, 89, 42, 161, 222, 14, 53, 61, 232, 213, 68, 59, 57, 132, 99, 9, 5, 68, 239, 110, 133, 186, 96, 99, 100, 48, 12, 45, 42, 255, 204, 78, 30, 63, 131, 63, 238, 124, 201, 215, 111, 158, 8, 66, 181, 162, 97, 22, 127, 238, 214 } },
                    { 2, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8452), "samet@inal.com", "Samet", true, false, "İnal", "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8453), "User data seed", new byte[] { 219, 211, 86, 29, 23, 181, 237, 84, 2, 240, 114, 15, 56, 4, 192, 67, 8, 225, 79, 177, 92, 236, 207, 167, 125, 114, 227, 11, 163, 195, 56, 136, 188, 170, 100, 17, 63, 40, 116, 254, 47, 147, 93, 236, 149, 57, 97, 31, 252, 87, 124, 72, 48, 116, 186, 108, 245, 221, 93, 60, 52, 0, 71, 163 }, new byte[] { 206, 13, 105, 42, 25, 71, 145, 47, 222, 114, 219, 125, 83, 239, 190, 66, 162, 209, 7, 47, 171, 246, 41, 134, 8, 223, 70, 8, 233, 133, 157, 205, 238, 97, 114, 14, 188, 113, 55, 187, 96, 131, 241, 203, 190, 183, 254, 163, 200, 173, 244, 109, 200, 36, 179, 145, 171, 76, 147, 228, 94, 210, 133, 164, 175, 89, 214, 149, 10, 105, 4, 235, 229, 58, 184, 16, 26, 200, 89, 42, 161, 222, 14, 53, 61, 232, 213, 68, 59, 57, 132, 99, 9, 5, 68, 239, 110, 133, 186, 96, 99, 100, 48, 12, 45, 42, 255, 204, 78, 30, 63, 131, 63, 238, 124, 201, 215, 111, 158, 8, 66, 181, 162, 97, 22, 127, 238, 214 } },
                    { 3, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8455), "ilknur@inal.com", "Ilknur", true, false, "İnal", "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(8456), "User data seed", new byte[] { 219, 211, 86, 29, 23, 181, 237, 84, 2, 240, 114, 15, 56, 4, 192, 67, 8, 225, 79, 177, 92, 236, 207, 167, 125, 114, 227, 11, 163, 195, 56, 136, 188, 170, 100, 17, 63, 40, 116, 254, 47, 147, 93, 236, 149, 57, 97, 31, 252, 87, 124, 72, 48, 116, 186, 108, 245, 221, 93, 60, 52, 0, 71, 163 }, new byte[] { 206, 13, 105, 42, 25, 71, 145, 47, 222, 114, 219, 125, 83, 239, 190, 66, 162, 209, 7, 47, 171, 246, 41, 134, 8, 223, 70, 8, 233, 133, 157, 205, 238, 97, 114, 14, 188, 113, 55, 187, 96, 131, 241, 203, 190, 183, 254, 163, 200, 173, 244, 109, 200, 36, 179, 145, 171, 76, 147, 228, 94, 210, 133, 164, 175, 89, 214, 149, 10, 105, 4, 235, 229, 58, 184, 16, 26, 200, 89, 42, 161, 222, 14, 53, 61, 232, 213, 68, 59, 57, 132, 99, 9, 5, 68, 239, 110, 133, 186, 96, 99, 100, 48, 12, 45, 42, 255, 204, 78, 30, 63, 131, 63, 238, 124, 201, 215, 111, 158, 8, 66, 181, 162, 97, 22, 127, 238, 214 } }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "ColorId", "CreatedByName", "CreatedDate", "DailyPrice", "Description", "IsActive", "IsDeleted", "ModelYear", "ModifiedByName", "ModifiedDate", "Note" },
                values: new object[,]
                {
                    { 1, 1, 1, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3035), 950000.00m, "Iyi bir model 1", true, false, (short)2019, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3036), "1. Araba" },
                    { 2, 2, 2, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3039), 850000.00m, "Iyi bir model 2", true, false, (short)2017, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3040), "2. Araba" },
                    { 3, 3, 3, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3043), 1000000.00m, "Iyi bir model 3", true, false, (short)2021, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3044), "3. Araba" },
                    { 4, 4, 1, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3048), 980000.00m, "Iyi bir model 4", true, false, (short)2020, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3049), "4. Araba" },
                    { 5, 5, 2, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3051), 150000.00m, "Iyi bir model 5", true, false, (short)2014, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3052), "5. Araba" },
                    { 6, 6, 3, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3055), 250000.00m, "Iyi bir model 6", true, false, (short)2021, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(3055), "6. Araba" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CompanyName", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "UserId" },
                values: new object[,]
                {
                    { 1, "AE Yazılım", "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4088), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4089), "1. Musteri", 1 },
                    { 2, "Selçuk Üniversitesi", "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4091), true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(4092), "2. Musteri", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CreatedByName", "CreatedDate", "CustomerId", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "RentDate", "ReturnDate" },
                values: new object[] { 1, 5, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6533), 1, true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6534), "Ilk kira", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CreatedByName", "CreatedDate", "CustomerId", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "RentDate", "ReturnDate" },
                values: new object[] { 2, 6, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6538), 2, true, false, "InitialCreate", new DateTime(2022, 12, 24, 15, 48, 19, 624, DateTimeKind.Local).AddTicks(6539), "2. kira", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
