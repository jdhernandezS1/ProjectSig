using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace armadieti2.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class movimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chiave",
                columns: table => new
                {
                    numerochiave = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chiave_pkey", x => x.numerochiave);
                });

            migrationBuilder.CreateTable(
                name: "dipartimento",
                columns: table => new
                {
                    nomedipartimento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dipartimento_pkey", x => x.nomedipartimento);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    idlocation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stabile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    piano = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("location_pkey", x => x.idlocation);
                });

            migrationBuilder.CreateTable(
                name: "statomobilio",
                columns: table => new
                {
                    statomobilio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("statomobilio_pkey", x => x.statomobilio);
                });

            migrationBuilder.CreateTable(
                name: "tipomobilio",
                columns: table => new
                {
                    tipomobilio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipomobilio_pkey", x => x.tipomobilio);
                });

            migrationBuilder.CreateTable(
                name: "tipopagamento",
                columns: table => new
                {
                    pagamento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipopagamento_pkey", x => x.pagamento);
                });

            migrationBuilder.CreateTable(
                name: "tipopersona",
                columns: table => new
                {
                    tipopersona = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tipopersona_pkey", x => x.tipopersona);
                });

            migrationBuilder.CreateTable(
                name: "mobilio",
                columns: table => new
                {
                    idmobilio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero = table.Column<int>(type: "integer", nullable: false),
                    idlocation = table.Column<int>(type: "integer", nullable: false),
                    tipomobilio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numerochiave = table.Column<int>(type: "integer", nullable: false),
                    statomobilio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mobilio_pkey", x => x.idmobilio);
                    table.ForeignKey(
                        name: "mobilio_idlocation_fkey",
                        column: x => x.idlocation,
                        principalTable: "location",
                        principalColumn: "idlocation");
                    table.ForeignKey(
                        name: "mobilio_numerochiave_fkey",
                        column: x => x.numerochiave,
                        principalTable: "chiave",
                        principalColumn: "numerochiave");
                    table.ForeignKey(
                        name: "mobilio_statomobilio_fkey",
                        column: x => x.statomobilio,
                        principalTable: "statomobilio",
                        principalColumn: "statomobilio");
                    table.ForeignKey(
                        name: "mobilio_tipomobilio_fkey",
                        column: x => x.tipomobilio,
                        principalTable: "tipomobilio",
                        principalColumn: "tipomobilio");
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    idpersona = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cognome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    idmonitor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tipopersona = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nomedipartimento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("persona_pkey", x => x.idpersona);
                    table.ForeignKey(
                        name: "persona_nomedipartimento_fkey",
                        column: x => x.nomedipartimento,
                        principalTable: "dipartimento",
                        principalColumn: "nomedipartimento");
                    table.ForeignKey(
                        name: "persona_tipopersona_fkey",
                        column: x => x.tipopersona,
                        principalTable: "tipopersona",
                        principalColumn: "tipopersona");
                });

            migrationBuilder.CreateTable(
                name: "noleggio",
                columns: table => new
                {
                    idnoleggio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datainizio = table.Column<DateOnly>(type: "date", nullable: false),
                    datafine = table.Column<DateOnly>(type: "date", nullable: false),
                    idmobilio = table.Column<int>(type: "integer", nullable: false),
                    idpersona = table.Column<int>(type: "integer", nullable: false),
                    attivo = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("noleggio_pkey", x => x.idnoleggio);
                    table.ForeignKey(
                        name: "noleggio_idmobilio_fkey",
                        column: x => x.idmobilio,
                        principalTable: "mobilio",
                        principalColumn: "idmobilio");
                    table.ForeignKey(
                        name: "noleggio_idpersona_fkey",
                        column: x => x.idpersona,
                        principalTable: "persona",
                        principalColumn: "idpersona");
                });

            migrationBuilder.CreateTable(
                name: "movimento",
                columns: table => new
                {
                    idmovimento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idnoleggio = table.Column<int>(type: "integer", nullable: false),
                    cauzione = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    pagamento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("movimento_pkey", x => x.idmovimento);
                    table.ForeignKey(
                        name: "movimento_idnoleggio_fkey",
                        column: x => x.idnoleggio,
                        principalTable: "noleggio",
                        principalColumn: "idnoleggio");
                    table.ForeignKey(
                        name: "movimento_pagamento_fkey",
                        column: x => x.pagamento,
                        principalTable: "tipopagamento",
                        principalColumn: "pagamento");
                });

            migrationBuilder.CreateIndex(
                name: "location_stabile_piano_key",
                table: "location",
                columns: new[] { "stabile", "piano" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mobilio_numerochiave",
                table: "mobilio",
                column: "numerochiave");

            migrationBuilder.CreateIndex(
                name: "IX_mobilio_statomobilio",
                table: "mobilio",
                column: "statomobilio");

            migrationBuilder.CreateIndex(
                name: "IX_mobilio_tipomobilio",
                table: "mobilio",
                column: "tipomobilio");

            migrationBuilder.CreateIndex(
                name: "mobilio_idlocation_numero_key",
                table: "mobilio",
                columns: new[] { "idlocation", "numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimento_idnoleggio",
                table: "movimento",
                column: "idnoleggio");

            migrationBuilder.CreateIndex(
                name: "IX_movimento_pagamento",
                table: "movimento",
                column: "pagamento");

            migrationBuilder.CreateIndex(
                name: "IX_noleggio_idpersona",
                table: "noleggio",
                column: "idpersona");

            migrationBuilder.CreateIndex(
                name: "noleggio_idmobilio_datainizio_datafine_key",
                table: "noleggio",
                columns: new[] { "idmobilio", "datainizio", "datafine" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_nomedipartimento",
                table: "persona",
                column: "nomedipartimento");

            migrationBuilder.CreateIndex(
                name: "IX_persona_tipopersona",
                table: "persona",
                column: "tipopersona");

            migrationBuilder.CreateIndex(
                name: "persona_email_key",
                table: "persona",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "persona_idmonitor_key",
                table: "persona",
                column: "idmonitor",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimento");

            migrationBuilder.DropTable(
                name: "noleggio");

            migrationBuilder.DropTable(
                name: "tipopagamento");

            migrationBuilder.DropTable(
                name: "mobilio");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "chiave");

            migrationBuilder.DropTable(
                name: "statomobilio");

            migrationBuilder.DropTable(
                name: "tipomobilio");

            migrationBuilder.DropTable(
                name: "dipartimento");

            migrationBuilder.DropTable(
                name: "tipopersona");
        }
    }
}
