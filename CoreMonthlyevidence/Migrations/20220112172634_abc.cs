using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMonthlyevidence.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    departmentid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    departmentname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departmentlocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.departmentid);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    studentname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departmentid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentid);
                    table.ForeignKey(
                        name: "FK_Students_Departments_departmentid",
                        column: x => x.departmentid,
                        principalTable: "Departments",
                        principalColumn: "departmentid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_departmentid",
                table: "Students",
                column: "departmentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
