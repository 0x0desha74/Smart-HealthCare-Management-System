using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Data.Identity.Migrations
{
    /// <inheritdoc />
    public partial class correctLastNameColumnNameInAppUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LasrName",
                table: "AspNetUsers",
                newName: "LastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "LasrName");
        }
    }
}
