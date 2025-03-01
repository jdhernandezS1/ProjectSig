using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class dbmodelsfoldering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoleggioModel_UtenteModel_IdUtente",
                table: "NoleggioModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_DipartimentoModel_NomeDipartimento",
                table: "UtenteModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_TipoUtenteModel_TipoUtente",
                table: "UtenteModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtenteModel",
                table: "UtenteModel");

            migrationBuilder.RenameTable(
                name: "UtenteModel",
                newName: "UtenteModel_1");

            migrationBuilder.RenameIndex(
                name: "IX_UtenteModel_TipoUtente",
                table: "UtenteModel_1",
                newName: "IX_UtenteModel_1_TipoUtente");

            migrationBuilder.RenameIndex(
                name: "IX_UtenteModel_NomeDipartimento",
                table: "UtenteModel_1",
                newName: "IX_UtenteModel_1_NomeDipartimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtenteModel_1",
                table: "UtenteModel_1",
                column: "IdUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_NoleggioModel_UtenteModel_1_IdUtente",
                table: "NoleggioModel",
                column: "IdUtente",
                principalTable: "UtenteModel_1",
                principalColumn: "IdUtente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_1_DipartimentoModel_NomeDipartimento",
                table: "UtenteModel_1",
                column: "NomeDipartimento",
                principalTable: "DipartimentoModel",
                principalColumn: "NomeDipartimento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_1_TipoUtenteModel_TipoUtente",
                table: "UtenteModel_1",
                column: "TipoUtente",
                principalTable: "TipoUtenteModel",
                principalColumn: "TipoUtente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoleggioModel_UtenteModel_1_IdUtente",
                table: "NoleggioModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_1_DipartimentoModel_NomeDipartimento",
                table: "UtenteModel_1");

            migrationBuilder.DropForeignKey(
                name: "FK_UtenteModel_1_TipoUtenteModel_TipoUtente",
                table: "UtenteModel_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtenteModel_1",
                table: "UtenteModel_1");

            migrationBuilder.RenameTable(
                name: "UtenteModel_1",
                newName: "UtenteModel");

            migrationBuilder.RenameIndex(
                name: "IX_UtenteModel_1_TipoUtente",
                table: "UtenteModel",
                newName: "IX_UtenteModel_TipoUtente");

            migrationBuilder.RenameIndex(
                name: "IX_UtenteModel_1_NomeDipartimento",
                table: "UtenteModel",
                newName: "IX_UtenteModel_NomeDipartimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtenteModel",
                table: "UtenteModel",
                column: "IdUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_NoleggioModel_UtenteModel_IdUtente",
                table: "NoleggioModel",
                column: "IdUtente",
                principalTable: "UtenteModel",
                principalColumn: "IdUtente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_DipartimentoModel_NomeDipartimento",
                table: "UtenteModel",
                column: "NomeDipartimento",
                principalTable: "DipartimentoModel",
                principalColumn: "NomeDipartimento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtenteModel_TipoUtenteModel_TipoUtente",
                table: "UtenteModel",
                column: "TipoUtente",
                principalTable: "TipoUtenteModel",
                principalColumn: "TipoUtente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
