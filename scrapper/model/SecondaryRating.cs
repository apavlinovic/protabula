using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class SecondaryRating
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public float RatingValue { get; set; }
    public float RatingRange { get; set; }
    public string Label { get; set; }

    [ForeignKey("Review")]
    public int ReviewId { get; set; }
}
