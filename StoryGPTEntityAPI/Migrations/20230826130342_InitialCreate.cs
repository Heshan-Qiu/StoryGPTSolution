using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryGPTEntityAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneratedId = table.Column<int>(type: "INTEGER", nullable: false),
                    StoryTitle = table.Column<string>(type: "TEXT", nullable: false),
                    StoryText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneratedId = table.Column<int>(type: "INTEGER", nullable: false),
                    StoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Prompt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaData_Story_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Story",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneratedId = table.Column<int>(type: "INTEGER", nullable: false),
                    MetaDataId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_MetaData_MetaDataId",
                        column: x => x.MetaDataId,
                        principalTable: "MetaData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_StoryId",
                table: "MetaData",
                column: "StoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_MetaDataId",
                table: "Tag",
                column: "MetaDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "MetaData");

            migrationBuilder.DropTable(
                name: "Story");
        }
    }
}
