
public static class SheetItemsMapper
{
    public static List<SheetItem> MapFromRangeData(IList<IList<object>> values)
    {
        var items = new List<SheetItem>();
        foreach (var value in values)
        {
            Enum.TryParse(value[3].ToString(), out UnitTypes type);

            var item = new SheetItem();

            if (value.ElementAtOrDefault(0) != null)
            {
                item.Name = value.ElementAtOrDefault(0)!.ToString()!;
            }

            if (value.ElementAtOrDefault(1) != null)
            {
                item.Family = value.ElementAtOrDefault(1)!.ToString()!;
            }

            if (value.ElementAtOrDefault(2) != null)
            {
                item.Manufacturer = value.ElementAtOrDefault(2)!.ToString()!;
            }

            if (value.ElementAtOrDefault(4) != null)
            {
                item.ProductId_EU = value.ElementAtOrDefault(4)?.ToString();
            }

            if (value.ElementAtOrDefault(5) != null)
            {
                item.ProductId_US = value.ElementAtOrDefault(5)?.ToString();
            }

            if (value.ElementAtOrDefault(6) != null)
            {
                item.Name_US = value.ElementAtOrDefault(6)?.ToString();
            }

            if (value.ElementAtOrDefault(7) != null)
            {
                item.Description = value.ElementAtOrDefault(7)?.ToString();
            }

            items.Add(item);
        }
        return items;
    }
}