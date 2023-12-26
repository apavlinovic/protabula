using System.ComponentModel.DataAnnotations;

public class PrimaryRating
{
    [Key]
    public Guid Id { get; set; }
    public float RatingValue { get; set; }
    public int RatingRange { get; set; }
    public int RatingPercentage { get; set; }

    public Guid ReviewStatisticsId { get; set; }
    public ReviewStatistics ReviewStatistics { get; set; }
}
