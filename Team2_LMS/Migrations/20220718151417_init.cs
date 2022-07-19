using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Team2_LMS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ceoDBs",
                columns: table => new
                {
                    CeoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ceoDBs", x => x.CeoId);
                });

            migrationBuilder.CreateTable(
                name: "leavemanagementDbs",
                columns: table => new
                {
                    LeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeLeaveBalance = table.Column<int>(type: "int", nullable: false),
                    Numberofdays = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leavemanagementDbs", x => x.LeaveId);
                });

            migrationBuilder.CreateTable(
                name: "ManagerDb",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveBalance = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerDb", x => x.ManagerId);
                });

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
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    LeaveBalance = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeDBs", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_employeeDBs_ManagerDb_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "ManagerDb",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeeDBs_ManagerId",
                table: "employeeDBs",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ceoDBs");

            migrationBuilder.DropTable(
                name: "employeeDBs");

            migrationBuilder.DropTable(
                name: "leavemanagementDbs");

            migrationBuilder.DropTable(
                name: "ManagerDb");
        }
    }
}
