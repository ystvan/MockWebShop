using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManager.Data.Migrations
{
    public partial class secondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                "CreatedDate",
                "AspNetRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                "Description",
                "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "IPAddress",
                "AspNetRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "CreatedDate",
                "AspNetRoles");

            migrationBuilder.DropColumn(
                "Description",
                "AspNetRoles");

            migrationBuilder.DropColumn(
                "IPAddress",
                "AspNetRoles");
        }
    }
}