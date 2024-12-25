using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesginStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class operationsadded4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperationName = table.Column<string>(type: "TEXT", nullable: false),
                    OperationPrice = table.Column<double>(type: "REAL", nullable: false),
                    OperationDuration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");
        }
    }
}
