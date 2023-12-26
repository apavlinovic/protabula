public class IkeaJSONResponse
{
    public ReviewStatisticsResponse reviewStatistics { get; set; }
    public List<Review> reviews { get; set; }
    public Response response { get; set; }
}

public class ReviewStatisticsResponse
{
    public PrimaryRating primaryRating { get; set; }
    public Dictionary<string, SecondaryRating> secondaryRatings { get; set; }
    public List<RatingDistribution> ratingDistribution { get; set; }
    public int totalRatingCount { get; set; }
    public int totalReviewCount { get; set; }
    public int totalNegativeFeedbackCount { get; set; }
    public int totalPositiveFeedbackCount { get; set; }
    public int totalRecommendedCount { get; set; }
    public int totalNotRecommendedCount { get; set; }
    public string firstReviewedOn { get; set; }
    public string lastReviewedOn { get; set; }
}

public class Response
{
    public Status status { get; set; }
    public int size { get; set; }
    public int page { get; set; }
    public int resultCount { get; set; }
}

public class Status
{
    public int code { get; set; }
    public string message { get; set; }
}