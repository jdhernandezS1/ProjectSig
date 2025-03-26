using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class badnameofarmadiosid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArmadioModel_LocationModel_Location",
                table: "ArmadioModel");

            migrationBuilder.DropIndex(
                name: "IX_ArmadioModel_Location",
                table: "ArmadioModel");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ArmadioModel");

            migrationBuilder.CreateIndex(
                name: "IX_ArmadioModel_IdLocation",
                table: "ArmadioModel",
                column: "IdLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_ArmadioModel_LocationModel_IdLocation",
                table: "ArmadioModel",
                column: "IdLocation",
                principalTable: "LocationModel",
                principalColumn: "IdLocation",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArmadioModel_LocationModel_IdLocation",
                table: "ArmadioModel");

            migrationBuilder.DropIndex(
                name: "IX_ArmadioModel_IdLocation",
                table: "ArmadioModel");

            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "ArmadioModel",
                type: "integer",
                nullable: true);

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
    }
}
