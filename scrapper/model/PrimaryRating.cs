using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PrimaryRating
{
    [Key]
    public int Id { get; set; }
    public float RatingValue { get; set; }
    public float RatingRange { get; set; }

    [ForeignKey("Review")]
    public string ReviewId { get; set; }
}
