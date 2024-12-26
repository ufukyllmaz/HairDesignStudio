using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairDesignStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationadded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerSurname",
                table: "Reservation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerSurname",
                table: "Reservation");
        }
    }
}
