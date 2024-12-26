using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workerabilitiesadded7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerOperations_Workers_workersWorkerId",
                table: "WorkerOperations");

            migrationBuilder.AlterColumn<int>(
                name: "workersWorkerId",
                table: "WorkerOperations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "WorkerHasOperation",
                table: "WorkerOperations",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerOperations_Workers_workersWorkerId",
                table: "WorkerOperations",
                column: "workersWorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerOperations_Workers_workersWorkerId",
                table: "WorkerOperations");

            migrationBuilder.AlterColumn<int>(
                name: "workersWorkerId",
                table: "WorkerOperations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerHasOperation",
                table: "WorkerOperations",
                type: "INTEGER",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerOperations_Workers_workersWorkerId",
                table: "WorkerOperations",
                column: "workersWorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
