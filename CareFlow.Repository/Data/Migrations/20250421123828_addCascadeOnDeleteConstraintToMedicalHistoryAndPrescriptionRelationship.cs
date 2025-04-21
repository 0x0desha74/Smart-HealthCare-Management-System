using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addCascadeOnDeleteConstraintToMedicalHistoryAndPrescriptionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");
        }
    }
}
