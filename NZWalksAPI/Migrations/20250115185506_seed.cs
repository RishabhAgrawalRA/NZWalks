using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("8379fff8-05f2-4708-a04a-663d27edb442"), "Difficult" },
                    { new Guid("a1e89c74-726c-4ba8-b3d5-b96824f3c0fa"), "Easy" },
                    { new Guid("c99ed6f0-6ead-4524-ae45-8b64c2684e5e"), "Mediun" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "ID", "Code", "Name", "RegionaImageUrl" },
                values: new object[,]
                {
                    { new Guid("768e09e9-e559-4089-9a39-c4c8af226b3e"), "BLR", "Banglore", "Banglore-image" },
                    { new Guid("8e317022-8c07-4584-b0e7-b57355f14c28"), "PNQ", "Pune", "Pune-image" },
                    { new Guid("9771fff1-0a80-4ee9-9fdd-97c951c3d893"), "DLH", "Delhi", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("8379fff8-05f2-4708-a04a-663d27edb442"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("a1e89c74-726c-4ba8-b3d5-b96824f3c0fa"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("c99ed6f0-6ead-4524-ae45-8b64c2684e5e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("768e09e9-e559-4089-9a39-c4c8af226b3e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("8e317022-8c07-4584-b0e7-b57355f14c28"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "ID",
                keyValue: new Guid("9771fff1-0a80-4ee9-9fdd-97c951c3d893"));
        }
    }
}
