using Microsoft.EntityFrameworkCore.Migrations;

namespace Closer.Migrations
{
    public partial class CloserSecondFinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Pseudo",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserDiscussions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Discussions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserCreatorId",
                table: "Discussions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatorId1",
                table: "Discussions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_UserCreatorId1",
                table: "Discussions",
                column: "UserCreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Users_UserCreatorId1",
                table: "Discussions",
                column: "UserCreatorId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_Users_UserCreatorId1",
                table: "Discussions");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_UserCreatorId1",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Pseudo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserDiscussions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "UserCreatorId",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "UserCreatorId1",
                table: "Discussions");
        }
    }
}
