using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Team2_LMS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeDBs",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveBalance = table.Column<int>(type: "int", nullable: false),
                    Possword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeDBs", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeDBs");
        }
    }
}
