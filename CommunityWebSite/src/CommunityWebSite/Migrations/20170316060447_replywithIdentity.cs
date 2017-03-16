using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommunityWebSite.Migrations
{
    public partial class replywithIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.AddColumn<int>(
                name: "ReplyCreatorUserID",
                table: "Reply",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Reply",
                maxLength: 50,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reply_ReplyCreatorUserID",
                table: "Reply",
                column: "ReplyCreatorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_User_ReplyCreatorUserID",
                table: "Reply",
                column: "ReplyCreatorUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_User_ReplyCreatorUserID",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Reply_ReplyCreatorUserID",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "ReplyCreatorUserID",
                table: "Reply");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Reply",
                nullable: true);
        }
    }
}
