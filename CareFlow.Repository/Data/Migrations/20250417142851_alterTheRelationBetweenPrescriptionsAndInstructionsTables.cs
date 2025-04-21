using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class alterTheRelationBetweenPrescriptionsAndInstructionsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_MedicalHistories_MedicalHistoryId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Instructions");

            migrationBuilder.RenameColumn(
                name: "MedicalHistoryId",
                table: "Instructions",
                newName: "PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_MedicalHistoryId",
                table: "Instructions",
                newName: "IX_Instructions_PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Prescriptions_PrescriptionId",
                table: "Instructions",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Prescriptions_PrescriptionId",
                table: "Instructions");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "Instructions",
                newName: "MedicalHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_PrescriptionId",
                table: "Instructions",
                newName: "IX_Instructions_MedicalHistoryId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Instructions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Instructions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_MedicalHistories_MedicalHistoryId",
                table: "Instructions",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");
        }
    }
}
