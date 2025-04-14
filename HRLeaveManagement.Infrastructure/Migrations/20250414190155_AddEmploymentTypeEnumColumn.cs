using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRLeaveManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmploymentTypeEnumColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "EmploymentTypes",
                nullable: false,
                defaultValue: 1); // Default to FullTime (1)

            // Optional: Copy existing string values to enum
            migrationBuilder.Sql(@"
        UPDATE EmploymentTypes 
        SET Type = CASE 
            WHEN Name = 'Full-time' THEN 1 
            WHEN Name = 'Part-time' THEN 2 
            ELSE 1 
        END");

            // Optional: Remove old column
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EmploymentTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "EmploymentTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EmploymentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
