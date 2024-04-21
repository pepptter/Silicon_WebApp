using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedsomeuppercases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postalcode",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Addressline_2",
                table: "Addresses",
                newName: "AddressLine_2");

            migrationBuilder.RenameColumn(
                name: "Addressline_1",
                table: "Addresses",
                newName: "AddressLine_1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "Postalcode");

            migrationBuilder.RenameColumn(
                name: "AddressLine_2",
                table: "Addresses",
                newName: "Addressline_2");

            migrationBuilder.RenameColumn(
                name: "AddressLine_1",
                table: "Addresses",
                newName: "Addressline_1");
        }
    }
}
