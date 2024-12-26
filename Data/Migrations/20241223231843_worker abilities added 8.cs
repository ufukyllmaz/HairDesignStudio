using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workerabilitiesadded8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerHasOperation",
                table: "WorkerOperations");

            migrationBuilder.AddColumn<string>(
                name: "WorkerHasOperations",
                table: "WorkerOperations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkerHasOperations",
                table: "WorkerOperations");

            migrationBuilder.AddColumn<string>(
                name: "WorkerHasOperation",
                table: "WorkerOperations",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
