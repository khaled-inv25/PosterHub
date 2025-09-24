using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosterHub.HttpApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BadegStyle", "BadgeText", "Description", "FullName", "MediaFiledId", "MetaDescription", "MetaTitle", "Name", "ParentCategoryId", "Published", "ShowOnHomePage", "ShowOnMenu", "SubjectToAcl", "TreePath" },
                values: new object[] { 1, (byte)0, null, "Description", "Electronic", null, null, null, "Electronic", null, true, true, true, false, "/1/" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
