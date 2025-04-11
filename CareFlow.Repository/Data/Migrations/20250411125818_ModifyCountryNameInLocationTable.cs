using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCountryNameInLocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Conuntry",
                table: "Locations",
                newName: "Counrty");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Clinics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "Counrty",
                table: "Locations",
                newName: "Conuntry");
        }
    }
}
