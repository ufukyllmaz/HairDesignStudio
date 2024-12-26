using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class workersadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkerName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    WorkerSurname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    WorkerPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    WorkerAddress = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    WorkerEMail = table.Column<string>(type: "TEXT", nullable: false),
                    WorkerStartDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
