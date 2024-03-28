using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMO_Corona.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoronaDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstVaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstmanufacturerVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondVaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondmanufacturerVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdVaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThirdmanufacturerVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FourthVaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FourthmanufacturerVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositiveResultDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecoveryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberHouse = table.Column<int>(type: "int", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoronaDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalDetails_CoronaDetails_CoronaDetailsId",
                        column: x => x.CoronaDetailsId,
                        principalTable: "CoronaDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_CoronaDetailsId",
                table: "PersonalDetails",
                column: "CoronaDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "CoronaDetails");
        }
    }
}
