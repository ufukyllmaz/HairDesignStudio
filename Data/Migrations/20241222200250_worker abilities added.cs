using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workerabilitiesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_WorkerOperations_WorkerOperationWorkerId_WorkerOperationOperationId",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "WorkerOperationWorkers");

            migrationBuilder.DropIndex(
                name: "IX_Operations_WorkerOperationWorkerId_WorkerOperationOperationId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "WorkerOperationOperationId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "WorkerOperationWorkerId",
                table: "Operations");

            migrationBuilder.AddColumn<string>(
                name: "WorkerSurname",
                table: "WorkerOperations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOperations_OperationId",
                table: "WorkerOperations",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerOperations_Operations_OperationId",
                table: "WorkerOperations",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerOperations_Workers_WorkerId",
                table: "WorkerOperations",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerOperations_Operations_OperationId",
                table: "WorkerOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerOperations_Workers_WorkerId",
                table: "WorkerOperations");

            migrationBuilder.DropIndex(
                name: "IX_WorkerOperations_OperationId",
                table: "WorkerOperations");

            migrationBuilder.DropColumn(
                name: "WorkerSurname",
                table: "WorkerOperations");

            migrationBuilder.AddColumn<int>(
                name: "WorkerOperationOperationId",
                table: "Operations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkerOperationWorkerId",
                table: "Operations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkerOperationWorkers",
                columns: table => new
                {
                    workersWorkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    workerOperationsWorkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    workerOperationsOperationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerOperationWorkers", x => new { x.workersWorkerId, x.workerOperationsWorkerId, x.workerOperationsOperationId });
                    table.ForeignKey(
                        name: "FK_WorkerOperationWorkers_WorkerOperations_workerOperationsWorkerId_workerOperationsOperationId",
                        columns: x => new { x.workerOperationsWorkerId, x.workerOperationsOperationId },
                        principalTable: "WorkerOperations",
                        principalColumns: new[] { "WorkerId", "OperationId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerOperationWorkers_Workers_workersWorkerId",
                        column: x => x.workersWorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_WorkerOperationWorkerId_WorkerOperationOperationId",
                table: "Operations",
                columns: new[] { "WorkerOperationWorkerId", "WorkerOperationOperationId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOperationWorkers_workerOperationsWorkerId_workerOperationsOperationId",
                table: "WorkerOperationWorkers",
                columns: new[] { "workerOperationsWorkerId", "workerOperationsOperationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_WorkerOperations_WorkerOperationWorkerId_WorkerOperationOperationId",
                table: "Operations",
                columns: new[] { "WorkerOperationWorkerId", "WorkerOperationOperationId" },
                principalTable: "WorkerOperations",
                principalColumns: new[] { "WorkerId", "OperationId" });
        }
    }
}
