using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Closer.Migrations
{
    public partial class CloserFinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "InRespondToMessageID",
                table: "UserDiscussions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "UserDiscussions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserDiscussions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Discussions",
                nullable: true);

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

            migrationBuilder.DropColumn(
                name: "InRespondToMessageID",
                table: "UserDiscussions");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "UserDiscussions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserDiscussions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Discussions");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DiscussionId = table.Column<string>(nullable: true),
                    InRespondToMessageID = table.Column<string>(nullable: true),
                    Moniker = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });
        }
    }
}
