using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addGenderColumnToDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctors");
        }
    }
}
