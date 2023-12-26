public class IkeaJSONResponse
{
    public ReviewStatisticsResponse ReviewStatistics { get; set; }
    public List<ReviewResponse> Reviews { get; set; }
    public ResponseMeta Response { get; set; }

    public class ReviewResponse
    {
        public string Id { get; set; }
        public string CountryCode { get; set; }
        public string LangCode { get; set; }
        public string SourceCountryCode { get; set; }
        public string ContentLocale { get; set; }
        public string ItemNo { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsVerifiedBuyer { get; set; }
        public int PositiveFeedbacksCount { get; set; }
        public int NegativeFeedbacksCount { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsForeign { get; set; }
        public DateTime SubmissionOn { get; set; }
        public DateTime LatestModificationOn { get; set; }

        public RatingResponse PrimaryRating { get; set; }
        public Dictionary<string, RatingResponse> SecondaryRatings { get; set; }
    }

    public class RatingResponse
    {
        public string Id { get; set; }
        public float RatingValue { get; set; } = 0;
        public float RatingRange { get; set; } = 0;
    }

    public class ReviewStatisticsResponse
    {
        public RatingResponse PrimaryRating { get; set; }
        public Dictionary<string, RatingResponse> SecondaryRatings { get; set; }
        public int TotalRatingCount { get; set; }
        public int TotalReviewCount { get; set; }
        public int TotalNegativeFeedbackCount { get; set; }
        public int TotalPositiveFeedbackCount { get; set; }
        public int TotalRecommendedCount { get; set; }
        public int TotalNotRecommendedCount { get; set; }
        public string FirstReviewedOn { get; set; }
        public string LastReviewedOn { get; set; }
    }

    public class ResponseMeta
    {
        public Status Status { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public int ResultCount { get; set; }
    }

    public class Status
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

}