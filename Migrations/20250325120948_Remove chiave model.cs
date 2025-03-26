using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class Removechiavemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoleggioModel_ChiaveModel_IdChiave",
                table: "NoleggioModel");

            migrationBuilder.DropTable(
                name: "ChiaveModel");

            migrationBuilder.DropTable(
                name: "StatoChiaveModel");

            migrationBuilder.DropIndex(
                name: "IX_NoleggioModel_IdChiave",
                table: "NoleggioModel");

            migrationBuilder.DropColumn(
                name: "IdChiave",
                table: "NoleggioModel");

            migrationBuilder.AddColumn<bool>(
                name: "StatoChiave",
                table: "ArmadioModel",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatoChiave",
                table: "ArmadioModel");

            migrationBuilder.AddColumn<int>(
                name: "IdChiave",
                table: "NoleggioModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatoChiaveModel",
                columns: table => new
                {
                    IdStatoChiave = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatoChiave = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatoChiaveModel", x => x.IdStatoChiave);
                });

            migrationBuilder.CreateTable(
                name: "ChiaveModel",
                columns: table => new
                {
                    IdChiave = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdArmadio = table.Column<int>(type: "integer", nullable: false),
                    IdStatoChiave = table.Column<int>(type: "integer", nullable: false),
                    DataModifica = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiaveModel", x => x.IdChiave);
                    table.ForeignKey(
                        name: "FK_ChiaveModel_ArmadioModel_IdArmadio",
                        column: x => x.IdArmadio,
                        principalTable: "ArmadioModel",
                        principalColumn: "IdArmadio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiaveModel_StatoChiaveModel_IdStatoChiave",
                        column: x => x.IdStatoChiave,
                        principalTable: "StatoChiaveModel",
                        principalColumn: "IdStatoChiave",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdChiave",
                table: "NoleggioModel",
                column: "IdChiave");

            migrationBuilder.CreateIndex(
                name: "IX_ChiaveModel_IdArmadio",
                table: "ChiaveModel",
                column: "IdArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_ChiaveModel_IdStatoChiave",
                table: "ChiaveModel",
                column: "IdStatoChiave");

            migrationBuilder.AddForeignKey(
                name: "FK_NoleggioModel_ChiaveModel_IdChiave",
                table: "NoleggioModel",
                column: "IdChiave",
                principalTable: "ChiaveModel",
                principalColumn: "IdChiave",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
