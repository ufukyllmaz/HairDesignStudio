using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesginStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workerabilitiesadded3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationName",
                table: "WorkerOperations");

            migrationBuilder.DropColumn(
                name: "WorkerName",
                table: "WorkerOperations");

            migrationBuilder.DropColumn(
                name: "WorkerSurname",
                table: "WorkerOperations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OperationName",
                table: "WorkerOperations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkerName",
                table: "WorkerOperations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkerSurname",
                table: "WorkerOperations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
