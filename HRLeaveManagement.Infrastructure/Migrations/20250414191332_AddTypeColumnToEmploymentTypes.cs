using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRLeaveManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeColumnToEmploymentTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "EmploymentTypes",
                nullable: false,
                defaultValue: 1); // Default to FullTime

            // Convert existing Name values to Type enum values
            migrationBuilder.Sql(@"
        UPDATE EmploymentTypes 
        SET Type = CASE 
            WHEN Name = 'Full-time' THEN 1 
            WHEN Name = 'Part-time' THEN 2 
            ELSE 1 
        END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EmploymentTypes");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "EmploymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
