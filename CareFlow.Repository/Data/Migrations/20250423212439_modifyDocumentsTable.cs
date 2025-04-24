using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareFlow.Repository.Migrations
{
    /// <inheritdoc />
    public partial class modifyDocumentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Documents",
                newName: "UploadedAt");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Documents",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "Documents",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "Documents",
                newName: "FilePath");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Documents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UploadedByUserId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "UploadedByUserId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Documents",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "Documents",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Documents",
                newName: "FileUrl");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Documents",
                newName: "DocumentType");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
