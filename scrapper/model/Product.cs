using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public Product()
    {
        Name = "";
        Family = "";
        Manufacturer = "";
        Type = UnitTypes.BED;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string Manufacturer { get; set; }
    public UnitTypes Type { get; set; }
    public string? ProductId_EU { get; set; }
    public string? ProductId_US { get; set; }
    public string? Description { get; set; }

    public List<Review> Reviews { get; set; }
}