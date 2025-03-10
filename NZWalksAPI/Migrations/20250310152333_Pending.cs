using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class Pending : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("9b3d7cf8-1364-42ab-b126-95ed17f6d210"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("b9803d00-0198-4889-835e-8408c071c280"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("06bab480-571b-4b16-a244-12deafe66858"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("5945eb86-0fa1-4453-a7b8-4b06d0183dd6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("e754b362-08a0-4641-b504-79a6143f78c2"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("9b3d7cf8-1364-42ab-b126-95ed17f6d210"), "Mediun" },
                    { new Guid("b9803d00-0198-4889-835e-8408c071c280"), "Difficult" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "ID", "Code", "Name", "RegionaImageUrl" },
                values: new object[,]
                {
                    { new Guid("06bab480-571b-4b16-a244-12deafe66858"), "BLR", "Banglore", "Banglore-image" },
                    { new Guid("5945eb86-0fa1-4453-a7b8-4b06d0183dd6"), "DLH", "Delhi", null },
                    { new Guid("e754b362-08a0-4641-b504-79a6143f78c2"), "PNQ", "Pune", "Pune-image" }
                });
        }
    }
}
