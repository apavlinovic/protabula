public static class ReviewUrlBuilder
{
    public static string BuildUrl(string locale, string productId)
    {
        return $"https://api.tugc.ingka.com/review/info/v4/reviews/{locale}/{productId}";
    }
}