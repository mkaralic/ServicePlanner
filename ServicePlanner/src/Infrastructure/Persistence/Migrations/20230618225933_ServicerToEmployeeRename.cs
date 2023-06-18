using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePlanner.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServicerToEmployeeRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Servicer_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servicer",
                schema: "ServicePlanner",
                table: "Servicer");

            migrationBuilder.RenameTable(
                name: "Servicer",
                schema: "ServicePlanner",
                newName: "Employee",
                newSchema: "ServicePlanner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                schema: "ServicePlanner",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Employee_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "EmployeeId",
                principalSchema: "ServicePlanner",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Employee_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                schema: "ServicePlanner",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                schema: "ServicePlanner",
                newName: "Servicer",
                newSchema: "ServicePlanner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servicer",
                schema: "ServicePlanner",
                table: "Servicer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Servicer_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "EmployeeId",
                principalSchema: "ServicePlanner",
                principalTable: "Servicer",
                principalColumn: "Id");
        }
    }
}
