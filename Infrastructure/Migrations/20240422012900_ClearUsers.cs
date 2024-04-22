using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClearUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // If there are foreign key constraints, you might need to temporarily drop them or set them to cascade delete
            migrationBuilder.Sql("TRUNCATE TABLE [Addresses]");
            migrationBuilder.Sql("TRUNCATE TABLE [AspNetUsers]");

            // Optional: Reset the identity counter for both tables
            migrationBuilder.Sql("DBCC CHECKIDENT ('Addresses', RESEED, 0)");
            migrationBuilder.Sql("DBCC CHECKIDENT ('AspNetUsers', RESEED, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Optional: Code to reverse the truncation if needed
        }
    }
}
