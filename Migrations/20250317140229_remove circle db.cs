using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class removecircledb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Piano",
                table: "ArmadioModel");

            migrationBuilder.AddColumn<int>(
                name: "IdLocation",
                table: "ArmadioModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "ArmadioModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationModel",
                columns: table => new
                {
                    IdLocation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Stabile = table.Column<string>(type: "text", nullable: false),
                    Piano = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationModel", x => x.IdLocation);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmadioModel_Location",
                table: "ArmadioModel",
                column: "Location");

            migrationBuilder.AddForeignKey(
                name: "FK_ArmadioModel_LocationModel_Location",
                table: "ArmadioModel",
                column: "Location",
                principalTable: "LocationModel",
                principalColumn: "IdLocation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArmadioModel_LocationModel_Location",
                table: "ArmadioModel");

            migrationBuilder.DropTable(
                name: "LocationModel");

            migrationBuilder.DropIndex(
                name: "IX_ArmadioModel_Location",
                table: "ArmadioModel");

            migrationBuilder.DropColumn(
                name: "IdLocation",
                table: "ArmadioModel");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ArmadioModel");

            migrationBuilder.AddColumn<string>(
                name: "Piano",
                table: "ArmadioModel",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
