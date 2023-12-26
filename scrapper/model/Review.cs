using System.ComponentModel.DataAnnotations;

public class Review
{
    [Key]
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

    public PrimaryRating PrimaryRating { get; set; }
    public List<SecondaryRating> SecondaryRatings { get; set; }
}
