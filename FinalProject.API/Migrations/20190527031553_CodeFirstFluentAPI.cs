using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.API.Migrations
{
    public partial class CodeFirstFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DevPlans_EmployeeId",
                table: "DevPlans",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevPlans_Employees_EmployeeId",
                table: "DevPlans",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevPlans_Employees_EmployeeId",
                table: "DevPlans");

            migrationBuilder.DropIndex(
                name: "IX_DevPlans_EmployeeId",
                table: "DevPlans");
        }
    }
}
