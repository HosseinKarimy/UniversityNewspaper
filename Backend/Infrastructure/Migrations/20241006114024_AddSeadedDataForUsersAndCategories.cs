using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeadedDataForUsersAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("3bb92864-b902-4e89-8b97-d049b0b6178a"), "Category 4" },
                    { new Guid("8c0c0bf0-7dea-4aad-9628-d768a1744355"), "Category 2" },
                    { new Guid("b710d26f-369b-46c3-b133-2e4e522d5530"), "Category 1" },
                    { new Guid("fc2e27bd-5551-4b41-9699-e7a4dc367532"), "Category 3" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FullName" },
                values: new object[,]
                {
                    { new Guid("0371098e-898d-45ca-84b2-42790a7ab1c3"), "Name 1" },
                    { new Guid("243991d2-65dd-4636-868c-1f8f48ab8475"), "Name 3" },
                    { new Guid("4ce8ca07-8f81-4312-93d6-828d336af05b"), "Name 4" },
                    { new Guid("fb7b0b35-baf2-4718-9bbf-a9ab6206224b"), "Name 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("3bb92864-b902-4e89-8b97-d049b0b6178a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("8c0c0bf0-7dea-4aad-9628-d768a1744355"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("b710d26f-369b-46c3-b133-2e4e522d5530"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("fc2e27bd-5551-4b41-9699-e7a4dc367532"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("0371098e-898d-45ca-84b2-42790a7ab1c3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("243991d2-65dd-4636-868c-1f8f48ab8475"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("4ce8ca07-8f81-4312-93d6-828d336af05b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("fb7b0b35-baf2-4718-9bbf-a9ab6206224b"));
        }
    }
}
