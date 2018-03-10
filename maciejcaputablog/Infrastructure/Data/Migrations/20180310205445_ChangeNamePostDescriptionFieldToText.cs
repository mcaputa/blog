using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Migrations
{
    public partial class ChangeNamePostDescriptionFieldToText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posts",
                newName: "Text");

            migrationBuilder.AddColumn<string>(
                name: "Lead",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lead",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Posts",
                newName: "Description");
        }
    }
}
