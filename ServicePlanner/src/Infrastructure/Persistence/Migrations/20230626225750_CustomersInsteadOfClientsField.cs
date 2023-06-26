using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePlanner.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomersInsteadOfClientsField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Client_ClientId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Customers_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Employee_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_WorkOrderStatus_WorkOrderStatusId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderStatusHistory_WorkOrder_WorkOrderId",
                schema: "ServicePlanner",
                table: "WorkOrderStatusHistory");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "ServicePlanner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOrder",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_ClientId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.RenameTable(
                name: "WorkOrder",
                schema: "ServicePlanner",
                newName: "WorkOrders",
                newSchema: "ServicePlanner");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_WorkOrderStatusId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                newName: "IX_WorkOrders_WorkOrderStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                newName: "IX_WorkOrders_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                newName: "IX_WorkOrders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOrders",
                schema: "ServicePlanner",
                table: "WorkOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                column: "CustomerId",
                principalSchema: "ServicePlanner",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Employee_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                column: "EmployeeId",
                principalSchema: "ServicePlanner",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                column: "WorkOrderStatusId",
                principalSchema: "ServicePlanner",
                principalTable: "WorkOrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderStatusHistory_WorkOrders_WorkOrderId",
                schema: "ServicePlanner",
                table: "WorkOrderStatusHistory",
                column: "WorkOrderId",
                principalSchema: "ServicePlanner",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Employee_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderStatusHistory_WorkOrders_WorkOrderId",
                schema: "ServicePlanner",
                table: "WorkOrderStatusHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOrders",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.RenameTable(
                name: "WorkOrders",
                schema: "ServicePlanner",
                newName: "WorkOrder",
                newSchema: "ServicePlanner");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_WorkOrderStatusId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                newName: "IX_WorkOrder_WorkOrderStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                newName: "IX_WorkOrder_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                newName: "IX_WorkOrder_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOrder",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "ServicePlanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "Text", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ClientId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Client_ClientId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "ClientId",
                principalSchema: "ServicePlanner",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Customers_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "CustomerId",
                principalSchema: "ServicePlanner",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Employee_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "EmployeeId",
                principalSchema: "ServicePlanner",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_WorkOrderStatus_WorkOrderStatusId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "WorkOrderStatusId",
                principalSchema: "ServicePlanner",
                principalTable: "WorkOrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderStatusHistory_WorkOrder_WorkOrderId",
                schema: "ServicePlanner",
                table: "WorkOrderStatusHistory",
                column: "WorkOrderId",
                principalSchema: "ServicePlanner",
                principalTable: "WorkOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
