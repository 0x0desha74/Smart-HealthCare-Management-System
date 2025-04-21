using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addCascadeOnDeleteConstraintToInstructionAndPrescriptionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Prescriptions_PrescriptionId",
                table: "Instructions");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Prescriptions_PrescriptionId",
                table: "Instructions",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Prescriptions_PrescriptionId",
                table: "Instructions");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Prescriptions_PrescriptionId",
                table: "Instructions",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id");
        }
    }
}
