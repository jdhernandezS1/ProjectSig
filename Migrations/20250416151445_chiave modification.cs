using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace armadieti2.Migrations
{
    /// <inheritdoc />
    public partial class chiavemodification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobilios_Chiaves_Numerochiave",
                table: "Mobilios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chiaves",
                table: "Chiaves");

            migrationBuilder.AlterColumn<int>(
                name: "Numerochiave",
                table: "Chiaves",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Chiaves",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chiaves",
                table: "Chiaves",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobilios_Chiaves_Numerochiave",
                table: "Mobilios",
                column: "Numerochiave",
                principalTable: "Chiaves",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobilios_Chiaves_Numerochiave",
                table: "Mobilios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chiaves",
                table: "Chiaves");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Chiaves");

            migrationBuilder.AlterColumn<int>(
                name: "Numerochiave",
                table: "Chiaves",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chiaves",
                table: "Chiaves",
                column: "Numerochiave");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobilios_Chiaves_Numerochiave",
                table: "Mobilios",
                column: "Numerochiave",
                principalTable: "Chiaves",
                principalColumn: "Numerochiave",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
