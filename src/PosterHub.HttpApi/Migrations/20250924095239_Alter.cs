using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosterHub.HttpApi.Migrations
{
    /// <inheritdoc />
    public partial class Alter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Categories",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Categories",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BadegStyle", "BadgeText", "Description", "FullName", "MediaFiledId", "MetaDescription", "MetaTitle", "Name", "ParentCategoryId", "Published", "ShowOnHomePage", "ShowOnMenu", "SubjectToAcl", "TreePath" },
                values: new object[] { 1, (byte)0, null, "Description", "Electronic", null, null, null, "Electronic", null, true, true, true, false, "/1/" });
        }
    }
}
