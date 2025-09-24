using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PosterHub.HttpApi.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    TreePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BadgeText = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BadegStyle = table.Column<byte>(type: "tinyint", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MediaFiledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShowOnMenu = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnHomePage = table.Column<bool>(type: "bit", nullable: false),
                    SubjectToAcl = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_MediaFile_MediaFiledId",
                        column: x => x.MediaFiledId,
                        principalTable: "MediaFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MediaFiledId",
                table: "Categories",
                column: "MediaFiledId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MediaFile");
        }
    }
}
