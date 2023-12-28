public class IkeaJSONResponse
{
    public IkeaJSONResponse()
    {
        ReviewStatistics = new ReviewStatisticsResponse();
        Reviews = new List<ReviewResponse>();
        Response = new ResponseMeta();
        ProductId = 0;
    }
    public ReviewStatisticsResponse ReviewStatistics { get; set; }
    public List<ReviewResponse> Reviews { get; set; }
    public ResponseMeta Response { get; set; }
    public int ProductId { get; set; }
}

public class ReviewResponse
{
    public ReviewResponse()
    {
        Id = "";
        CountryCode = "";
        LangCode = "";
        SourceCountryCode = "";
        ContentLocale = "";
        ItemNo = "";
        Title = "";
        Text = "";
        IsRecommended = false;
        IsVerifiedBuyer = false;
        PositiveFeedbacksCount = 0;
        NegativeFeedbacksCount = 0;
        IsFeatured = false;
        IsForeign = false;
        SubmissionOn = new DateTime();
        LatestModificationOn = new DateTime();
        PrimaryRating = new RatingResponse();
        SecondaryRatings = new Dictionary<string, RatingResponse>();
    }
    public string Id { get; set; }
    public string CountryCode { get; set; }
    public string LangCode { get; set; }
    public string SourceCountryCode { get; set; }
    public string ContentLocale { get; set; }
    public string ItemNo { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public bool? IsRecommended { get; set; }
    public bool? IsVerifiedBuyer { get; set; }
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
    public RatingResponse()
    {
        Id = "";
    }
    public string Id { get; set; } = "";
    public float RatingValue { get; set; } = 0;
    public float RatingRange { get; set; } = 0;
}

public class ReviewStatisticsResponse
{
    public ReviewStatisticsResponse()
    {
        PrimaryRating = new RatingResponse();
        SecondaryRatings = new Dictionary<string, RatingResponse>();
        TotalRatingCount = 0;
        TotalReviewCount = 0;
        TotalNegativeFeedbackCount = 0;
        TotalPositiveFeedbackCount = 0;
        TotalRecommendedCount = 0;
        TotalNotRecommendedCount = 0;
        FirstReviewedOn = "";
        LastReviewedOn = "";
    }
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
    public ResponseMeta()
    {
        Status = new Status();
        Size = 0;
        Page = 0;
        ResultCount = 0;
    }
    public Status Status { get; set; }
    public int Size { get; set; }
    public int Page { get; set; }
    public int ResultCount { get; set; }
}

public class Status
{
    public Status()
    {
        Code = 0;
        Message = "";
    }
    public int Code { get; set; }
    public string Message { get; set; }
}
