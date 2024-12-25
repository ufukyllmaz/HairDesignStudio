using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesginStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workerabilitiesadded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "operationsOperationId",
                table: "WorkerOperations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "workersWorkerId",
                table: "WorkerOperations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOperations_operationsOperationId",
                table: "WorkerOperations",
                column: "operationsOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOperations_workersWorkerId",
                table: "WorkerOperations",
                column: "workersWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerOperations_Operations_operationsOperationId",
                table: "WorkerOperations",
                column: "operationsOperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerOperations_Workers_workersWorkerId",
                table: "WorkerOperations",
                column: "workersWorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerOperations_Operations_operationsOperationId",
                table: "WorkerOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerOperations_Workers_workersWorkerId",
                table: "WorkerOperations");

            migrationBuilder.DropIndex(
                name: "IX_WorkerOperations_operationsOperationId",
                table: "WorkerOperations");

            migrationBuilder.DropIndex(
                name: "IX_WorkerOperations_workersWorkerId",
                table: "WorkerOperations");

            migrationBuilder.DropColumn(
                name: "operationsOperationId",
                table: "WorkerOperations");

            migrationBuilder.DropColumn(
                name: "workersWorkerId",
                table: "WorkerOperations");

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
    }
}
