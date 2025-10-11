using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosterHub.HttpApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c5b8f4-7e2d-4e35-9b31-2d8b5a7d7a42",
                column: "ConcurrencyStamp",
                value: "ec511bd4-4853-426a-a2fc-751886560c9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9e2d6a1-3c7f-4f8a-90ef-12a1fbc9e815",
                column: "ConcurrencyStamp",
                value: "937e9988-9f49-4bab-a545-b422dde85016");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1c5b8f4-7e2d-4e35-9b31-2d8b5a7d7a42",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9e2d6a1-3c7f-4f8a-90ef-12a1fbc9e815",
                column: "ConcurrencyStamp",
                value: null);
        }
    }
}
