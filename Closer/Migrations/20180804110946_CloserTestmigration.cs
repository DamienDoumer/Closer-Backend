using Microsoft.EntityFrameworkCore.Migrations;

namespace Closer.Migrations
{
    public partial class CloserTestmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserDiscussions_DiscussionId",
                table: "UserDiscussions",
                column: "DiscussionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscussions_UserId",
                table: "UserDiscussions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiscussions_Discussions_DiscussionId",
                table: "UserDiscussions",
                column: "DiscussionId",
                principalTable: "Discussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDiscussions_Users_UserId",
                table: "UserDiscussions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDiscussions_Discussions_DiscussionId",
                table: "UserDiscussions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDiscussions_Users_UserId",
                table: "UserDiscussions");

            migrationBuilder.DropIndex(
                name: "IX_UserDiscussions_DiscussionId",
                table: "UserDiscussions");

            migrationBuilder.DropIndex(
                name: "IX_UserDiscussions_UserId",
                table: "UserDiscussions");
        }
    }
}
