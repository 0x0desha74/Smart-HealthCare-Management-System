using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveClinicIdFromLocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clinics_ClinicId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ClinicId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_LocationId",
                table: "Clinics",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Locations_LocationId",
                table: "Clinics",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Locations_LocationId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_LocationId",
                table: "Clinics");

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ClinicId",
                table: "Locations",
                column: "ClinicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clinics_ClinicId",
                table: "Locations",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
