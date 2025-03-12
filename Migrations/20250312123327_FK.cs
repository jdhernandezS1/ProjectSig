using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_1_DipartimentoModel_IdDipartimento",
                table: "UtenteModel_1");

            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_1_TipoUtenteModel_IdTipoUtente",
                table: "UtenteModel_1");

            migrationBuilder.DropIndex(
                name: "IX_UtenteModel_1_IdDipartimento",
                table: "UtenteModel_1");

            migrationBuilder.DropIndex(
                name: "IX_UtenteModel_1_IdTipoUtente",
                table: "UtenteModel_1");

            migrationBuilder.AddColumn<int>(
                name: "DipartimentoModelIdDipartimento",
                table: "UtenteModel_1",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoUtenteModelIdTipoUtente",
                table: "UtenteModel_1",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_1_DipartimentoModelIdDipartimento",
                table: "UtenteModel_1",
                column: "DipartimentoModelIdDipartimento");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_1_TipoUtenteModelIdTipoUtente",
                table: "UtenteModel_1",
                column: "TipoUtenteModelIdTipoUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_1_DipartimentoModel_DipartimentoModelIdDipartim~",
                table: "UtenteModel_1",
                column: "DipartimentoModelIdDipartimento",
                principalTable: "DipartimentoModel",
                principalColumn: "IdDipartimento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_1_TipoUtenteModel_TipoUtenteModelIdTipoUtente",
                table: "UtenteModel_1",
                column: "TipoUtenteModelIdTipoUtente",
                principalTable: "TipoUtenteModel",
                principalColumn: "IdTipoUtente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_1_DipartimentoModel_DipartimentoModelIdDipartim~",
                table: "UtenteModel_1");

            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_1_TipoUtenteModel_TipoUtenteModelIdTipoUtente",
                table: "UtenteModel_1");

            migrationBuilder.DropIndex(
                name: "IX_UtenteModel_1_DipartimentoModelIdDipartimento",
                table: "UtenteModel_1");

            migrationBuilder.DropIndex(
                name: "IX_UtenteModel_1_TipoUtenteModelIdTipoUtente",
                table: "UtenteModel_1");

            migrationBuilder.DropColumn(
                name: "DipartimentoModelIdDipartimento",
                table: "UtenteModel_1");

            migrationBuilder.DropColumn(
                name: "TipoUtenteModelIdTipoUtente",
                table: "UtenteModel_1");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_1_IdDipartimento",
                table: "UtenteModel_1",
                column: "IdDipartimento");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_1_IdTipoUtente",
                table: "UtenteModel_1",
                column: "IdTipoUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_1_DipartimentoModel_IdDipartimento",
                table: "UtenteModel_1",
                column: "IdDipartimento",
                principalTable: "DipartimentoModel",
                principalColumn: "IdDipartimento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_1_TipoUtenteModel_IdTipoUtente",
                table: "UtenteModel_1",
                column: "IdTipoUtente",
                principalTable: "TipoUtenteModel",
                principalColumn: "IdTipoUtente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
