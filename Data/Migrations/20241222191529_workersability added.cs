using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workersabilityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkerOperations",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationName = table.Column<string>(type: "TEXT", nullable: false),
                    workersWorkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    operationsOperationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerOperations", x => new { x.WorkerId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_WorkerOperations_Operations_operationsOperationId",
                        column: x => x.operationsOperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerOperations_Workers_workersWorkerId",
                        column: x => x.workersWorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOperations_operationsOperationId",
                table: "WorkerOperations",
                column: "operationsOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOperations_workersWorkerId",
                table: "WorkerOperations",
                column: "workersWorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerOperations");
        }
    }
}
