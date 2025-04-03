using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicalHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MedicalHistoryId",
                table: "Prescriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalHistoryId",
                table: "Instructions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalHistoryId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosisCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentSummery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnSetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredFollowUp = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalHistoryId",
                table: "Prescriptions",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_MedicalHistoryId",
                table: "Instructions",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MedicalHistoryId",
                table: "Documents",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_DoctorId",
                table: "MedicalHistories",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistories",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_MedicalHistories_MedicalHistoryId",
                table: "Documents",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_MedicalHistories_MedicalHistoryId",
                table: "Instructions",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_MedicalHistories_MedicalHistoryId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_MedicalHistories_MedicalHistoryId",
                table: "Instructions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalHistories_MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_MedicalHistoryId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Documents_MedicalHistoryId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Documents");
        }
    }
}
