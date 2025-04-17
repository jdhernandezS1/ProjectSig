using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class changecheckwithenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attivo",
                table: "Noleggios");

            migrationBuilder.AddColumn<int>(
                name: "StatoAttivo",
                table: "Noleggios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatoAttivo",
                table: "Noleggios");

            migrationBuilder.AddColumn<bool>(
                name: "Attivo",
                table: "Noleggios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
