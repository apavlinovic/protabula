public static class Mapping
{
    public static Review MapReviewResponseToReview(ReviewResponse reviewResponse)
    {
        return new Review
        {
            Id = reviewResponse.Id,
            CountryCode = reviewResponse.CountryCode,
            LangCode = reviewResponse.LangCode,
            SourceCountryCode = reviewResponse.SourceCountryCode,
            ContentLocale = reviewResponse.ContentLocale,
            ItemNo = reviewResponse.ItemNo,
            Title = reviewResponse.Title,
            Text = reviewResponse.Text,
            IsRecommended = reviewResponse.IsRecommended,
            IsVerifiedBuyer = reviewResponse.IsVerifiedBuyer,
            PositiveFeedbacksCount = reviewResponse.PositiveFeedbacksCount,
            NegativeFeedbacksCount = reviewResponse.NegativeFeedbacksCount,
            IsFeatured = reviewResponse.IsFeatured,
            IsForeign = reviewResponse.IsForeign,
            SubmissionOn = reviewResponse.SubmissionOn,
            LatestModificationOn = reviewResponse.LatestModificationOn,
            PrimaryRating = MapRatingResponseToPrimaryRating(reviewResponse.Id, reviewResponse.PrimaryRating),
            SecondaryRatings = MapRatingResponseToSecondaryRatings(reviewResponse.Id, reviewResponse.SecondaryRatings),
        };
    }

    public static PrimaryRating MapRatingResponseToPrimaryRating(string reviewId, RatingResponse ratingResponse)
    {
        return new PrimaryRating
        {
            ReviewId = reviewId,
            RatingValue = ratingResponse.RatingValue,
            RatingRange = ratingResponse.RatingRange,
        };
    }

    public static List<SecondaryRating> MapRatingResponseToSecondaryRatings(string reviewId, Dictionary<string, RatingResponse> ratingResponses)
    {
        var secondaryRatings = new List<SecondaryRating>();
        foreach (var ratingResponse in ratingResponses)
        {
            secondaryRatings.Add(new SecondaryRating
            {
                ReviewId = reviewId,
                Label = ratingResponse.Key,
                RatingValue = ratingResponse.Value.RatingValue,
                RatingRange = ratingResponse.Value.RatingRange,
            });
        }
        return secondaryRatings;
    }
}