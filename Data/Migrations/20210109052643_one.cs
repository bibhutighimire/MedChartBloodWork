using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedChartBloodWork.Data.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BloodWork",
                columns: table => new
                {
                    BloodWorkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hemoglobin = table.Column<string>(type: "varchar(10)", nullable: false),
                    Hematocrit = table.Column<string>(type: "varchar(10)", nullable: false),
                    WhiteBloodCellCount = table.Column<string>(type: "varchar(10)", nullable: false),
                    RedBloodCellCount = table.Column<string>(type: "varchar(10)", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodWork", x => x.BloodWorkID);
                    table.ForeignKey(
                        name: "FK_BloodWork_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodWork_ApplicationUserID",
                table: "BloodWork",
                column: "ApplicationUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodWork");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
