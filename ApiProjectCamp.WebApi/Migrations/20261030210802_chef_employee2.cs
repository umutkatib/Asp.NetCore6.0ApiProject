using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjectCamp.WebApi.Migrations
{
    public partial class chef_employee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Chefs_ChefID",
                table: "EmployeeTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask");

            migrationBuilder.RenameTable(
                name: "EmployeeTask",
                newName: "EmployeeTasks");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTask_ChefID",
                table: "EmployeeTasks",
                newName: "IX_EmployeeTasks_ChefID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks",
                column: "EmployeeTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Chefs_ChefID",
                table: "EmployeeTasks",
                column: "ChefID",
                principalTable: "Chefs",
                principalColumn: "ChefID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Chefs_ChefID",
                table: "EmployeeTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTasks",
                table: "EmployeeTasks");

            migrationBuilder.RenameTable(
                name: "EmployeeTasks",
                newName: "EmployeeTask");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTasks_ChefID",
                table: "EmployeeTask",
                newName: "IX_EmployeeTask_ChefID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask",
                column: "EmployeeTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Chefs_ChefID",
                table: "EmployeeTask",
                column: "ChefID",
                principalTable: "Chefs",
                principalColumn: "ChefID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
