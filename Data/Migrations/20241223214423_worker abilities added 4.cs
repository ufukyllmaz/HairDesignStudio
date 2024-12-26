using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workerabilitiesadded4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerOperations_Operations_operationsOperationId",
                table: "WorkerOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerOperations",
                table: "WorkerOperations");

            migrationBuilder.DropIndex(
                name: "IX_WorkerOperations_operationsOperationId",
                table: "WorkerOperations");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "WorkerOperations");

            migrationBuilder.RenameColumn(
                name: "operationsOperationId",
                table: "WorkerOperations",
                newName: "WorkerHasOperation");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerOperations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerOperations",
                table: "WorkerOperations",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerOperations",
                table: "WorkerOperations");

            migrationBuilder.RenameColumn(
                name: "WorkerHasOperation",
                table: "WorkerOperations",
                newName: "operationsOperationId");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerOperations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "WorkerOperations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerOperations",
                table: "WorkerOperations",
                columns: new[] { "WorkerId", "OperationId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerOperations_operationsOperationId",
                table: "WorkerOperations",
                column: "operationsOperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerOperations_Operations_operationsOperationId",
                table: "WorkerOperations",
                column: "operationsOperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
