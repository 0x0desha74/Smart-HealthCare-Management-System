using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addOriginalFileNameAndRenameFileNameToStoredFileNameInDocumentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Documents",
                newName: "StoredFileName");

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "StoredFileName",
                table: "Documents",
                newName: "FileName");
        }
    }
}
