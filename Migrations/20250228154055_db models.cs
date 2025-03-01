using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class dbmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impiegato");

            migrationBuilder.CreateTable(
                name: "CategoriaArmadioModel",
                columns: table => new
                {
                    CategoriaArmadio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaArmadioModel", x => x.CategoriaArmadio);
                });

            migrationBuilder.CreateTable(
                name: "DipartimentoModel",
                columns: table => new
                {
                    NomeDipartimento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DipartimentoModel", x => x.NomeDipartimento);
                });

            migrationBuilder.CreateTable(
                name: "StatoArmadioModel",
                columns: table => new
                {
                    StatoArmadio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatoArmadioModel", x => x.StatoArmadio);
                });

            migrationBuilder.CreateTable(
                name: "StatoChiaveModel",
                columns: table => new
                {
                    StatoChiave = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatoChiaveModel", x => x.StatoChiave);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamentoModel",
                columns: table => new
                {
                    Pagamento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamentoModel", x => x.Pagamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUtenteModel",
                columns: table => new
                {
                    TipoUtente = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUtenteModel", x => x.TipoUtente);
                });

            migrationBuilder.CreateTable(
                name: "ArmadioModel",
                columns: table => new
                {
                    IdArmadio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Piano = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    StatoArmadio = table.Column<string>(type: "text", nullable: false),
                    CategoriaArmadio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmadioModel", x => x.IdArmadio);
                    table.ForeignKey(
                        name: "FK_ArmadioModel_CategoriaArmadioModel_CategoriaArmadio",
                        column: x => x.CategoriaArmadio,
                        principalTable: "CategoriaArmadioModel",
                        principalColumn: "CategoriaArmadio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmadioModel_StatoArmadioModel_StatoArmadio",
                        column: x => x.StatoArmadio,
                        principalTable: "StatoArmadioModel",
                        principalColumn: "StatoArmadio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtenteModel",
                columns: table => new
                {
                    IdUtente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IdMonitor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TipoUtente = table.Column<string>(type: "text", nullable: false),
                    NomeDipartimento = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtenteModel", x => x.IdUtente);
                    table.ForeignKey(
                        name: "FK_UtenteModel_DipartimentoModel_NomeDipartimento",
                        column: x => x.NomeDipartimento,
                        principalTable: "DipartimentoModel",
                        principalColumn: "NomeDipartimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtenteModel_TipoUtenteModel_TipoUtente",
                        column: x => x.TipoUtente,
                        principalTable: "TipoUtenteModel",
                        principalColumn: "TipoUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiaveModel",
                columns: table => new
                {
                    IdChiave = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdArmadio = table.Column<int>(type: "integer", nullable: false),
                    StatoChiave = table.Column<string>(type: "text", nullable: false),
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
                        name: "FK_ChiaveModel_StatoChiaveModel_StatoChiave",
                        column: x => x.StatoChiave,
                        principalTable: "StatoChiaveModel",
                        principalColumn: "StatoChiave",
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
                    Pagamento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
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
                        name: "FK_NoleggioModel_TipoPagamentoModel_Pagamento",
                        column: x => x.Pagamento,
                        principalTable: "TipoPagamentoModel",
                        principalColumn: "Pagamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoleggioModel_UtenteModel_IdUtente",
                        column: x => x.IdUtente,
                        principalTable: "UtenteModel",
                        principalColumn: "IdUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmadioModel_CategoriaArmadio",
                table: "ArmadioModel",
                column: "CategoriaArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_ArmadioModel_StatoArmadio",
                table: "ArmadioModel",
                column: "StatoArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_ChiaveModel_IdArmadio",
                table: "ChiaveModel",
                column: "IdArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_ChiaveModel_StatoChiave",
                table: "ChiaveModel",
                column: "StatoChiave");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdArmadio",
                table: "NoleggioModel",
                column: "IdArmadio");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdChiave",
                table: "NoleggioModel",
                column: "IdChiave");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_IdUtente",
                table: "NoleggioModel",
                column: "IdUtente");

            migrationBuilder.CreateIndex(
                name: "IX_NoleggioModel_Pagamento",
                table: "NoleggioModel",
                column: "Pagamento");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_NomeDipartimento",
                table: "UtenteModel",
                column: "NomeDipartimento");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteModel_TipoUtente",
                table: "UtenteModel",
                column: "TipoUtente");
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
                name: "UtenteModel");

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

            migrationBuilder.CreateTable(
                name: "Impiegato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ManagerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impiegato", x => x.Id);
                });
        }
    }
}
