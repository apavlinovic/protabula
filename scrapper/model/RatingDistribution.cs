using System.ComponentModel.DataAnnotations;

public class RatingDistribution
{
    [Key]
    public Guid Id { get; set; }
    public int RatingValue { get; set; }
    public int RatingCount { get; set; }

    public Guid ReviewStatisticsId { get; set; }
    public ReviewStatistics ReviewStatistics { get; set; }
}
