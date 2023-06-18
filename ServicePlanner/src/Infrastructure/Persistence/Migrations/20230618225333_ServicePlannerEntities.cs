using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePlanner.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServicePlannerEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ServicePlanner");

            migrationBuilder.AlterColumn<string>(
                name: "Colour_Code",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "ServicePlanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "Text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicer",
                schema: "ServicePlanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "Text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderStatus",
                schema: "ServicePlanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                schema: "ServicePlanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "Text", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "ServicePlanner",
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrder_Servicer_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "ServicePlanner",
                        principalTable: "Servicer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrder_WorkOrderStatus_WorkOrderStatusId",
                        column: x => x.WorkOrderStatusId,
                        principalSchema: "ServicePlanner",
                        principalTable: "WorkOrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderStatusHistory",
                schema: "ServicePlanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderStatusHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderStatusHistory_WorkOrder_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalSchema: "ServicePlanner",
                        principalTable: "WorkOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ClientId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_WorkOrderStatusId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "WorkOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderStatusHistory_WorkOrderId",
                schema: "ServicePlanner",
                table: "WorkOrderStatusHistory",
                column: "WorkOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrderStatusHistory",
                schema: "ServicePlanner");

            migrationBuilder.DropTable(
                name: "WorkOrder",
                schema: "ServicePlanner");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "ServicePlanner");

            migrationBuilder.DropTable(
                name: "Servicer",
                schema: "ServicePlanner");

            migrationBuilder.DropTable(
                name: "WorkOrderStatus",
                schema: "ServicePlanner");

            migrationBuilder.AlterColumn<string>(
                name: "Colour_Code",
                table: "TodoLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
