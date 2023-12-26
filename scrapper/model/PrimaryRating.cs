using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PrimaryRating
{
    [Key]
    public int Id { get; set; }
    public float RatingValue { get; set; }
    public int RatingRange { get; set; }
    public string TypeOfRating { get; set; }

    [ForeignKey("Review")]
    public string ReviewId { get; set; }
}
