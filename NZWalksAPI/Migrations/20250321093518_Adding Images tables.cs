using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagestables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("00ab4c6f-3d83-46d8-8286-b2134c761d0f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("35252a59-bc03-4d50-9a95-90de85213a28"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("e6dc1a49-2bd9-467f-b4f2-b3da6bcef793"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("e7f25890-39c7-4426-8d65-61bea8c806d7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("eb21bf9a-daea-4edb-a3e6-d44f1060bd4c"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("2a1e5844-0222-46c7-8b7e-0d13b984c8c3"), "Difficult" },
                    { new Guid("5431346f-8adc-423f-84ba-fbd52c880ec1"), "Mediun" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "ID", "Code", "Name", "RegionaImageUrl" },
                values: new object[,]
                {
                    { new Guid("7e22ca63-0a89-45ce-a155-292729460cfb"), "DLH", "Delhi", null },
                    { new Guid("7f5c8d37-e1af-4243-82ea-9655402d5dcc"), "BLR", "Banglore", "Banglore-image" },
                    { new Guid("d80cd7f1-845a-4c56-bea6-d475acd3649e"), "PNQ", "Pune", "Pune-image" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("2a1e5844-0222-46c7-8b7e-0d13b984c8c3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("5431346f-8adc-423f-84ba-fbd52c880ec1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("7e22ca63-0a89-45ce-a155-292729460cfb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("7f5c8d37-e1af-4243-82ea-9655402d5dcc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("d80cd7f1-845a-4c56-bea6-d475acd3649e"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("00ab4c6f-3d83-46d8-8286-b2134c761d0f"), "Difficult" },
                    { new Guid("35252a59-bc03-4d50-9a95-90de85213a28"), "Mediun" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "ID", "Code", "Name", "RegionaImageUrl" },
                values: new object[,]
                {
                    { new Guid("e6dc1a49-2bd9-467f-b4f2-b3da6bcef793"), "PNQ", "Pune", "Pune-image" },
                    { new Guid("e7f25890-39c7-4426-8d65-61bea8c806d7"), "BLR", "Banglore", "Banglore-image" },
                    { new Guid("eb21bf9a-daea-4edb-a3e6-d44f1060bd4c"), "DLH", "Delhi", null }
                });
        }
    }
}
