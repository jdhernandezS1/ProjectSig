using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class addids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaArmadioModel",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoriaArmadio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaArmadioModel", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "DipartimentoModel",
                columns: table => new
                {
                    IdDipartimento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeDipartimento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DipartimentoModel", x => x.IdDipartimento);
                });

            migrationBuilder.CreateTable(
                name: "StatoArmadioModel",
                columns: table => new
                {
                    IdStatoArmadio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatoArmadio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatoArmadioModel", x => x.IdStatoArmadio);
                });

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
                name: "TipoPagamentoModel",
                columns: table => new
                {
                    IdTipoPagamento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pagamento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamentoModel", x => x.IdTipoPagamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUtenteModel",
                columns: table => new
                {
                    IdTipoUtente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoUtente = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUtenteModel", x => x.IdTipoUtente);
                });

            migrationBuilder.CreateTable(
                name: "ArmadioModel",
                columns: table => new
                {
                    IdArmadio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Piano = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    IdStatoArmadio = table.Column<int>(type: "integer", nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmadioModel", x => x.IdArmadio);
                    table.ForeignKey(
                        name: "FK_ArmadioModel_CategoriaArmadioModel_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriaArmadioModel",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmadioModel_StatoArmadioModel_IdStatoArmadio",
                        column: x => x.IdStatoArmadio,
                        principalTable: "StatoArmadioModel",
                        principalColumn: "IdStatoArmadio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtenteModel_1",
                columns: table => new
                {
                    IdUtente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IdMonitor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdTipoUtente = table.Column<int>(type: "integer", nullable: false),
                    IdDipartimento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtenteModel_1", x => x.IdUtente);
                    table.ForeignKey(
                        name: "FK_UtenteModel_1_DipartimentoModel_IdDipartimento",
                        column: x => x.IdDipartimento,
                        principalTable: "DipartimentoModel",
                        principalColumn: "IdDipartimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtenteModel_1_TipoUtenteModel_IdTipoUtente",
                        column: x => x.IdTipoUtente,
                        principalTable: "TipoUtenteModel",
                        principalColumn: "IdTipoUtente",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "NoleggioModel",
                columns: table => new
                {
                    IdNoleggio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataInizio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFine = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdTipoPagamento = table.Column<int>(type: "integer", maxLength: 30, nullable: false),
                    Cauzione = table.Column<decimal>(type: "numeric", nullable: false),
                    IdArmadio = table.Column<int>(type: "integer", nullable: false),
                    IdChiave = table.Column<int>(type: "integer", nullable: false),
                    IdUtente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoleggioModel", x => x.IdNoleggio);
                    table.ForeignKey(
                        name: "FK_NoleggioModel_ArmadioModel_IdArmadio",
                        column: x => x.IdArmadio,
                        principalTable: "ArmadioModel",
                        principalColumn: "IdArmadio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoleggioModel_ChiaveModel_IdChiave",
                        column: x => x.IdChiave,
                        principalTable: "ChiaveModel",
                        principalColumn: "IdChiave",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoleggioModel_TipoPagamentoModel_IdTipoPagamento",
                        column: x => x.IdTipoPagamento,
                        principalTable: "TipoPagamentoModel",
                        principalColumn: "IdTipoPagamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoleggioModel_UtenteModel_1_IdUtente",
                        column: x => x.IdUtente,
                        principalTable: "UtenteModel_1",
                        principalColumn: "IdUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmadioModel_IdCategoria",
                table: "ArmadioModel",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ArmadioModel_IdStatoArmadio",
                table: "ArmadioModel",
                column: "IdStatoArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_ChiaveModel_IdArmadio",
                table: "ChiaveModel",
                column: "IdArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_ChiaveModel_IdStatoChiave",
                table: "ChiaveModel",
                column: "IdStatoChiave");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdArmadio",
                table: "NoleggioModel",
                column: "IdArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdChiave",
                table: "NoleggioModel",
                column: "IdChiave");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdTipoPagamento",
                table: "NoleggioModel",
                column: "IdTipoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdUtente",
                table: "NoleggioModel",
                column: "IdUtente");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_1_IdDipartimento",
                table: "UtenteModel_1",
                column: "IdDipartimento");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_1_IdTipoUtente",
                table: "UtenteModel_1",
                column: "IdTipoUtente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoleggioModel");

            migrationBuilder.DropTable(
                name: "ChiaveModel");

            migrationBuilder.DropTable(
                name: "TipoPagamentoModel");

            migrationBuilder.DropTable(
                name: "UtenteModel_1");

            migrationBuilder.DropTable(
                name: "ArmadioModel");

            migrationBuilder.DropTable(
                name: "StatoChiaveModel");

            migrationBuilder.DropTable(
                name: "DipartimentoModel");

            migrationBuilder.DropTable(
                name: "TipoUtenteModel");

            migrationBuilder.DropTable(
                name: "CategoriaArmadioModel");

            migrationBuilder.DropTable(
                name: "StatoArmadioModel");
        }
    }
}
