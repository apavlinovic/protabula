using System.ComponentModel.DataAnnotations;

public class ReviewStatistics
{
    [Key]
    public Guid Id { get; set; }
    public int TotalRatingCount { get; set; }
    public int TotalReviewCount { get; set; }
    public int TotalNegativeFeedbackCount { get; set; }
    public int TotalPositiveFeedbackCount { get; set; }
    public int TotalRecommendedCount { get; set; }
    public int TotalNotRecommendedCount { get; set; }
    public DateTime FirstReviewedOn { get; set; }
    public DateTime LastReviewedOn { get; set; }

    public PrimaryRating PrimaryRating { get; set; }
    public List<SecondaryRating> SecondaryRatings { get; set; }
    public List<RatingDistribution> RatingDistributions { get; set; }
    public List<Review> Reviews { get; set; }
}
