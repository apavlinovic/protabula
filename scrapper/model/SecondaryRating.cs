using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SecondaryRating
{
    [Key]
    public int Id { get; set; }
    public float RatingValue { get; set; }
    public float RatingRange { get; set; }
    public string Label { get; set; }

    [ForeignKey("Review")]
    public string ReviewId { get; set; }
}
