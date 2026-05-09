using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegislativeInfoSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Legislation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    LegislationText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legislation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legislators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Hometown = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legislators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegislationLegislator",
                columns: table => new
                {
                    LegislationId = table.Column<int>(type: "INTEGER", nullable: false),
                    SponsorsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegislationLegislator", x => new { x.LegislationId, x.SponsorsId });
                    table.ForeignKey(
                        name: "FK_LegislationLegislator_Legislation_LegislationId",
                        column: x => x.LegislationId,
                        principalTable: "Legislation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegislationLegislator_Legislators_SponsorsId",
                        column: x => x.SponsorsId,
                        principalTable: "Legislators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegislationLegislator_SponsorsId",
                table: "LegislationLegislator",
                column: "SponsorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegislationLegislator");

            migrationBuilder.DropTable(
                name: "Legislation");

            migrationBuilder.DropTable(
                name: "Legislators");
        }
    }
}
