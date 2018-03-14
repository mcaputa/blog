using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Migrations
{
    public partial class AddPostFriendlyTitleUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FormContacts",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "FriendlyUrlTitle",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendlyUrlTitle",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "FormContacts",
                newName: "Name");
        }
    }
}
