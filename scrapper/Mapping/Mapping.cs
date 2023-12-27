public static class Mapping
{
    public static Review MapReviewResponseToReview(int productId, ReviewResponse reviewResponse)
    {
        return new Review
        {
            ReviewGuid = reviewResponse.Id,
            CountryCode = reviewResponse.CountryCode,
            LangCode = reviewResponse.LangCode,
            SourceCountryCode = reviewResponse.SourceCountryCode,
            ContentLocale = reviewResponse.ContentLocale,
            ItemNo = reviewResponse.ItemNo,
            Title = reviewResponse.Title,
            Text = reviewResponse.Text,
            IsRecommended = reviewResponse.IsRecommended,
            IsVerifiedBuyer = reviewResponse.IsVerifiedBuyer,
            SubmissionOn = reviewResponse.SubmissionOn,
            PrimaryRating = MapRatingResponseToPrimaryRating(reviewResponse.PrimaryRating),
            SecondaryRatings = MapRatingResponseToSecondaryRatings(reviewResponse.SecondaryRatings),
            ProductId = productId,
        };
    }

    public static PrimaryRating MapRatingResponseToPrimaryRating(RatingResponse ratingResponse)
    {
        return new PrimaryRating
        {
            RatingValue = ratingResponse.RatingValue,
            RatingRange = ratingResponse.RatingRange,
        };
    }

    public static List<SecondaryRating> MapRatingResponseToSecondaryRatings(Dictionary<string, RatingResponse> ratingResponses)
    {
        var secondaryRatings = new List<SecondaryRating>();
        foreach (var ratingResponse in ratingResponses)
        {
            secondaryRatings.Add(new SecondaryRating
            {
                Label = ratingResponse.Key,
                RatingValue = ratingResponse.Value.RatingValue,
                RatingRange = ratingResponse.Value.RatingRange,
            });
        }
        return secondaryRatings;
    }
}