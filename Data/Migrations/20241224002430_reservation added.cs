using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CustomerSurname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEMail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "WorkerShifts",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkerName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    WorkerSurname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    WorkStartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkEndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    workersWorkerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerShifts", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_WorkerShifts_Workers_workersWorkerId",
                        column: x => x.workersWorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerPhone = table.Column<string>(type: "TEXT", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    operationsOperationId = table.Column<int>(type: "INTEGER", nullable: true),
                    workersWorkerId = table.Column<int>(type: "INTEGER", nullable: true),
                    customersCustomerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Customers_customersCustomerId",
                        column: x => x.customersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Reservation_Operations_operationsOperationId",
                        column: x => x.operationsOperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId");
                    table.ForeignKey(
                        name: "FK_Reservation_Workers_workersWorkerId",
                        column: x => x.workersWorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkerShifts_workersWorkerId",
                table: "WorkerShifts",
                column: "workersWorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "WorkerShifts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
