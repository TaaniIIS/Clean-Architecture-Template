using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRLeaveManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedmyDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CompanyLocations_LocationID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LocationID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CompanyLocationId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyLocationId",
                table: "Employees",
                column: "CompanyLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CompanyLocations_CompanyLocationId",
                table: "Employees",
                column: "CompanyLocationId",
                principalTable: "CompanyLocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CompanyLocations_CompanyLocationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyLocationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyLocationId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationID",
                table: "Employees",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CompanyLocations_LocationID",
                table: "Employees",
                column: "LocationID",
                principalTable: "CompanyLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
