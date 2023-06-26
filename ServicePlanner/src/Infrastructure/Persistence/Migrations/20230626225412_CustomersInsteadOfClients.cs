using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePlanner.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomersInsteadOfClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Customers_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder",
                column: "CustomerId",
                principalSchema: "ServicePlanner",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Customers_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "ServicePlanner");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrder");
        }
    }
}
