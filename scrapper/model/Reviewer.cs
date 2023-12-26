
using System.ComponentModel.DataAnnotations;
public class Reviewer
{
    [Key]
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
    public string Nickname { get; set; }

    public List<Review> Reviews { get; set; }
}
