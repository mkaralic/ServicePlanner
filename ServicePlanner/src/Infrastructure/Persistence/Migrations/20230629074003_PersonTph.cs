using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePlanner.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PersonTph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Employee_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "ServicePlanner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                schema: "ServicePlanner",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                schema: "ServicePlanner",
                newName: "People",
                newSchema: "ServicePlanner");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "ServicePlanner",
                table: "People",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                schema: "ServicePlanner",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                schema: "ServicePlanner",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_People_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                column: "CustomerId",
                principalSchema: "ServicePlanner",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_People_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrders",
                column: "EmployeeId",
                principalSchema: "ServicePlanner",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_People_CustomerId",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_People_EmployeeId",
                schema: "ServicePlanner",
                table: "WorkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                schema: "ServicePlanner",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonType",
                schema: "ServicePlanner",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                schema: "ServicePlanner",
                newName: "Employee",
                newSchema: "ServicePlanner");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "ServicePlanner",
                table: "Employee",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                schema: "ServicePlanner",
                table: "Employee",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customers",
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

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
        }
    }
}
