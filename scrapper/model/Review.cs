using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Review
{
    public Review()
    {
        ReviewGuid = "";
        CountryCode = "";
        LangCode = "";
        SourceCountryCode = "";
        ContentLocale = "";
        ItemNo = "";
        Title = "";
        Text = "";
        IsRecommended = false;
        IsVerifiedBuyer = false;
        SubmissionOn = new DateTime();
        PrimaryRating = new PrimaryRating();
        SecondaryRatings = new List<SecondaryRating>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string ReviewGuid { get; set; }
    public string CountryCode { get; set; }
    public string LangCode { get; set; }
    public string SourceCountryCode { get; set; }
    public string ContentLocale { get; set; }
    public string ItemNo { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public bool IsRecommended { get; set; } = false;
    public bool IsVerifiedBuyer { get; set; }
    public DateTime SubmissionOn { get; set; }
    [JsonIgnore]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public PrimaryRating PrimaryRating { get; set; }
    public List<SecondaryRating> SecondaryRatings { get; set; }
}
