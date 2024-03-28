using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO_Corona.Data.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "PersonalDetails",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "PersonalDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileData",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "PersonalDetails");
        }
    }
}
