using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class UpdateNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "Posts",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Posts",
                newName: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Posts",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "postId");
        }
    }
}
