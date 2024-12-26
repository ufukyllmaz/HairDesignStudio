using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationadded3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customers_customersCustomerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Operations_operationsOperationId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Workers_workersWorkerId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_customersCustomerId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_operationsOperationId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_workersWorkerId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CustomerSurname",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "customersCustomerId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "operationsOperationId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "workersWorkerId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Reservation",
                newName: "WorkerNameSurname");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "Reservation",
                newName: "OperationName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkerNameSurname",
                table: "Reservation",
                newName: "WorkerId");

            migrationBuilder.RenameColumn(
                name: "OperationName",
                table: "Reservation",
                newName: "OperationId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Reservation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Reservation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Reservation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerSurname",
                table: "Reservation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "customersCustomerId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "operationsOperationId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "workersWorkerId",
                table: "Reservation",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_customersCustomerId",
                table: "Reservation",
                column: "customersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_operationsOperationId",
                table: "Reservation",
                column: "operationsOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_workersWorkerId",
                table: "Reservation",
                column: "workersWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customers_customersCustomerId",
                table: "Reservation",
                column: "customersCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Operations_operationsOperationId",
                table: "Reservation",
                column: "operationsOperationId",
                principalTable: "Operations",
                principalColumn: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Workers_workersWorkerId",
                table: "Reservation",
                column: "workersWorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId");
        }
    }
}
