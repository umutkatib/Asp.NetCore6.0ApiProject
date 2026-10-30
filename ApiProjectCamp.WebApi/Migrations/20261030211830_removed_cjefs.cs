using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjectCamp.WebApi.Migrations
{
    public partial class removed_cjefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTaskChefs");

            migrationBuilder.DropTable(
                name: "EmployeeTasks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    EmployeeTaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTaskAssignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeTaskDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeTaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeTaskPriority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeTaskStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeTaskValue = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => x.EmployeeTaskID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTaskChefs",
                columns: table => new
                {
                    EmployeeTaskChefID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChefID = table.Column<int>(type: "int", nullable: false),
                    EmployeeTask = table.Column<int>(type: "int", nullable: false),
                    EmployeeTaskID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaskChefs", x => x.EmployeeTaskChefID);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskChefs_Chefs_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chefs",
                        principalColumn: "ChefID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskChefs_EmployeeTasks_EmployeeTaskID",
                        column: x => x.EmployeeTaskID,
                        principalTable: "EmployeeTasks",
                        principalColumn: "EmployeeTaskID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskChefs_ChefID",
                table: "EmployeeTaskChefs",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskChefs_EmployeeTaskID",
                table: "EmployeeTaskChefs",
                column: "EmployeeTaskID");
        }
    }
}
