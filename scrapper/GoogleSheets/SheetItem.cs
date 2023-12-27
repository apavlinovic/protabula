public record SheetItem
{

    public SheetItem()
    {
        Name = "";
        Family = "";
        Manufacturer = "";
        Type = UnitTypes.BED;
    }

    public string Name { get; set; }
    public string? Name_US { get; set; }
    public string Family { get; set; }
    public string Manufacturer { get; set; }
    public string? ProductId_EU { get; set; }
    public string? ProductId_US { get; set; }
    public string? Description { get; set; }
    public UnitTypes Type { get; set; }
}