using System.ComponentModel.DataAnnotations;

public class SecondaryRating
{
    [Key]
    public Guid Id { get; set; }
    public string RatingId { get; set; }
    public float RatingValue { get; set; }
    public int RatingRange { get; set; }
    public int RatingPercentage { get; set; }
    public string Label { get; set; }

    public Guid ReviewStatisticsId { get; set; }
    public ReviewStatistics ReviewStatistics { get; set; }
}
