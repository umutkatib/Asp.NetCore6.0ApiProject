using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjectCamp.WebApi.Migrations
{
    public partial class chef_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTask",
                columns: table => new
                {
                    EmployeeTaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeTaskValue = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeeTaskAssignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeTaskDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeTaskPriority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeTaskStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTask", x => x.EmployeeTaskID);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Chefs_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chefs",
                        principalColumn: "ChefID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_ChefID",
                table: "EmployeeTask",
                column: "ChefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTask");
        }
    }
}
