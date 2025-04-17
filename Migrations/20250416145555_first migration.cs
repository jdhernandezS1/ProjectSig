using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chiaves",
                columns: table => new
                {
                    Numerochiave = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chiaves", x => x.Numerochiave);
                });

            migrationBuilder.CreateTable(
                name: "Dipartimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nomedipartimento = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipartimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Idlocation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Stabile = table.Column<string>(type: "text", nullable: false),
                    Piano = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Idlocation);
                });

            migrationBuilder.CreateTable(
                name: "Statomobilios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Statomobilio1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statomobilios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tipomobilios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipomobilio1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipomobilios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tipopagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pagamento = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipopagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipopersonas",
                columns: table => new
                {
                    IdTiPersona = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipopersona1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipopersonas", x => x.IdTiPersona);
                });

            migrationBuilder.CreateTable(
                name: "Mobilios",
                columns: table => new
                {
                    Idmobilio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Idlocation = table.Column<int>(type: "integer", nullable: false),
                    Tipomobilio = table.Column<int>(type: "integer", nullable: false),
                    Numerochiave = table.Column<int>(type: "integer", nullable: false),
                    Statomobilio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobilios", x => x.Idmobilio);
                    table.ForeignKey(
                        name: "FK_Mobilios_Chiaves_Numerochiave",
                        column: x => x.Numerochiave,
                        principalTable: "Chiaves",
                        principalColumn: "Numerochiave",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobilios_Locations_Idlocation",
                        column: x => x.Idlocation,
                        principalTable: "Locations",
                        principalColumn: "Idlocation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobilios_Statomobilios_Statomobilio",
                        column: x => x.Statomobilio,
                        principalTable: "Statomobilios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobilios_Tipomobilios_Tipomobilio",
                        column: x => x.Tipomobilio,
                        principalTable: "Tipomobilios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Idpersona = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cognome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Idmonitor = table.Column<string>(type: "text", nullable: false),
                    Tipopersona = table.Column<int>(type: "integer", nullable: false),
                    Dipartimento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Idpersona);
                    table.ForeignKey(
                        name: "FK_Personas_Dipartimentos_Dipartimento",
                        column: x => x.Dipartimento,
                        principalTable: "Dipartimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Tipopersonas_Tipopersona",
                        column: x => x.Tipopersona,
                        principalTable: "Tipopersonas",
                        principalColumn: "IdTiPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Noleggios",
                columns: table => new
                {
                    Idnoleggio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Datainizio = table.Column<DateOnly>(type: "date", nullable: false),
                    Datafine = table.Column<DateOnly>(type: "date", nullable: false),
                    Idmobilio = table.Column<int>(type: "integer", nullable: false),
                    Idpersona = table.Column<int>(type: "integer", nullable: false),
                    Attivo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noleggios", x => x.Idnoleggio);
                    table.ForeignKey(
                        name: "FK_Noleggios_Mobilios_Idmobilio",
                        column: x => x.Idmobilio,
                        principalTable: "Mobilios",
                        principalColumn: "Idmobilio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Noleggios_Personas_Idpersona",
                        column: x => x.Idpersona,
                        principalTable: "Personas",
                        principalColumn: "Idpersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentos",
                columns: table => new
                {
                    Idmovimento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Idnoleggio = table.Column<int>(type: "integer", nullable: false),
                    Cauzione = table.Column<decimal>(type: "numeric", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Pagamento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentos", x => x.Idmovimento);
                    table.ForeignKey(
                        name: "FK_Movimentos_Noleggios_Idnoleggio",
                        column: x => x.Idnoleggio,
                        principalTable: "Noleggios",
                        principalColumn: "Idnoleggio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentos_Tipopagamentos_Pagamento",
                        column: x => x.Pagamento,
                        principalTable: "Tipopagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mobilios_Idlocation",
                table: "Mobilios",
                column: "Idlocation");

            migrationBuilder.CreateIndex(
                name: "IX_Mobilios_Numerochiave",
                table: "Mobilios",
                column: "Numerochiave");

            migrationBuilder.CreateIndex(
                name: "IX_Mobilios_Statomobilio",
                table: "Mobilios",
                column: "Statomobilio");

            migrationBuilder.CreateIndex(
                name: "IX_Mobilios_Tipomobilio",
                table: "Mobilios",
                column: "Tipomobilio");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_Idnoleggio",
                table: "Movimentos",
                column: "Idnoleggio");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_Pagamento",
                table: "Movimentos",
                column: "Pagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Noleggios_Idmobilio",
                table: "Noleggios",
                column: "Idmobilio");

            migrationBuilder.CreateIndex(
                name: "IX_Noleggios_Idpersona",
                table: "Noleggios",
                column: "Idpersona");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Dipartimento",
                table: "Personas",
                column: "Dipartimento");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Tipopersona",
                table: "Personas",
                column: "Tipopersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentos");

            migrationBuilder.DropTable(
                name: "Noleggios");

            migrationBuilder.DropTable(
                name: "Tipopagamentos");

            migrationBuilder.DropTable(
                name: "Mobilios");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Chiaves");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Statomobilios");

            migrationBuilder.DropTable(
                name: "Tipomobilios");

            migrationBuilder.DropTable(
                name: "Dipartimentos");

            migrationBuilder.DropTable(
                name: "Tipopersonas");
        }
    }
}
