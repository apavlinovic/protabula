using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace protabula.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    LangCode = table.Column<string>(type: "TEXT", nullable: false),
                    SourceCountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    ContentLocale = table.Column<string>(type: "TEXT", nullable: false),
                    ItemNo = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    IsRecommended = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsVerifiedBuyer = table.Column<bool>(type: "INTEGER", nullable: false),
                    PositiveFeedbacksCount = table.Column<int>(type: "INTEGER", nullable: false),
                    NegativeFeedbacksCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsForeign = table.Column<bool>(type: "INTEGER", nullable: false),
                    SubmissionOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LatestModificationOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RatingValue = table.Column<float>(type: "REAL", nullable: false),
                    RatingRange = table.Column<float>(type: "REAL", nullable: false),
                    ReviewId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryRatings_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RatingValue = table.Column<float>(type: "REAL", nullable: false),
                    RatingRange = table.Column<float>(type: "REAL", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryRatings_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryRatings_ReviewId",
                table: "PrimaryRatings",
                column: "ReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryRatings_ReviewId",
                table: "SecondaryRatings",
                column: "ReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimaryRatings");

            migrationBuilder.DropTable(
                name: "SecondaryRatings");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
