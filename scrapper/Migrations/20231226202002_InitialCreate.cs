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
                name: "Reviewers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalRatingCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalReviewCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalNegativeFeedbackCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPositiveFeedbackCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalRecommendedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalNotRecommendedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstReviewedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastReviewedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingValue = table.Column<float>(type: "REAL", nullable: false),
                    RatingRange = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    ReviewStatisticsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryRatings_ReviewStatistics_ReviewStatisticsId",
                        column: x => x.ReviewStatisticsId,
                        principalTable: "ReviewStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingDistributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingValue = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ReviewStatisticsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingDistributions_ReviewStatistics_ReviewStatisticsId",
                        column: x => x.ReviewStatisticsId,
                        principalTable: "ReviewStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    LatestModificationOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PrimaryRatingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReviewerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReviewStatisticsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_PrimaryRatings_PrimaryRatingId",
                        column: x => x.PrimaryRatingId,
                        principalTable: "PrimaryRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_ReviewStatistics_ReviewStatisticsId",
                        column: x => x.ReviewStatisticsId,
                        principalTable: "ReviewStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Reviewers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Reviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingId = table.Column<string>(type: "TEXT", nullable: false),
                    RatingValue = table.Column<float>(type: "REAL", nullable: false),
                    RatingRange = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingPercentage = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewStatisticsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReviewId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryRatings_ReviewStatistics_ReviewStatisticsId",
                        column: x => x.ReviewStatisticsId,
                        principalTable: "ReviewStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecondaryRatings_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryRatings_ReviewStatisticsId",
                table: "PrimaryRatings",
                column: "ReviewStatisticsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RatingDistributions_ReviewStatisticsId",
                table: "RatingDistributions",
                column: "ReviewStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PrimaryRatingId",
                table: "Reviews",
                column: "PrimaryRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewStatisticsId",
                table: "Reviews",
                column: "ReviewStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryRatings_ReviewId",
                table: "SecondaryRatings",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryRatings_ReviewStatisticsId",
                table: "SecondaryRatings",
                column: "ReviewStatisticsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingDistributions");

            migrationBuilder.DropTable(
                name: "SecondaryRatings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "PrimaryRatings");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "ReviewStatistics");
        }
    }
}
