// See https://aka.ms/new-console-template for more information
using System.Text.Json;

async Task<IkeaJSONResponse> FetchIkeaDataAsync(string url)
{
    var httpClient = new HttpClient();

    // Set the headers
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
    httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "cross-site");
    httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-GB,en;q=0.9");
    httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
    httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
    httpClient.DefaultRequestHeaders.Add("Host", "api.tugc.ingka.com");
    httpClient.DefaultRequestHeaders.Add("Origin", "https://www.ikea.com");
    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.1.2 Safari/605.1.15");
    httpClient.DefaultRequestHeaders.Add("Referer", "https://www.ikea.com/");
    httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
    httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
    httpClient.DefaultRequestHeaders.Add("client-id", "35c8ad54-a47f-4c9d-9fc3-511acd9bd595");

    // Send the POST request
    var response = await httpClient.PostAsync(url, null);

    // Ensure the request was successful
    response.EnsureSuccessStatusCode();

    // Deserialize the response
    var content = await response.Content.ReadAsStringAsync();
    var ikeaResponse = JsonSerializer.Deserialize<IkeaJSONResponse>(content, new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });

    return ikeaResponse;
}


var respones = new List<IkeaJSONResponse>();
foreach (var locale in Locales.GetLocales())
{
    try
    {
        var response = await FetchIkeaDataAsync(
            ReviewUrlBuilder.BuildUrl(locale, "00211088")
        );

        if (response != null)
        {
            respones.Add(response);
            Console.WriteLine($"Fetched data for locale {locale} and productId 00211088");
        }
    }
    catch (System.Exception)
    {
        // Console.WriteLine($"Failed to fetch data for locale {locale} and productId 90339233");
    }
}



foreach (var response in respones)
{
    using (var context = new ScrapperDbContext())
    {
        var reviews = response.Reviews.Select(r => Mapping.MapReviewResponseToReview(r)).ToList();

        foreach (var review in reviews)
        {

            // Check if the review already exists in the database
            var existingReview = context.Reviews.FirstOrDefault(r => r.Id == review.Id);

            if (existingReview == null)
            {
                // Review does not exist, add it to the database
                context.Reviews.Add(review);
            }

            context.SaveChanges();
        }
    }

}

Console.WriteLine("Hello, World!");