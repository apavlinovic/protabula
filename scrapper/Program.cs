// See https://aka.ms/new-console-template for more information
using System.Text.Json;

async Task<IkeaJSONResponse> FetchIkeaDataAsync(string url)
{
    var httpClient = new HttpClient();

    // Set the headers
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
    httpClient.DefaultRequestHeaders.Add("Host", "api.tugc.ingka.com");
    httpClient.DefaultRequestHeaders.Add("Origin", "https://www.ikea.com");
    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.1.2 Safari/605.1.15");
    httpClient.DefaultRequestHeaders.Add("Referer", "https://www.ikea.com/");
    httpClient.DefaultRequestHeaders.Add("client-id", "35c8ad54-a47f-4c9d-9fc3-511acd9bd595");

    try
    {
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
    catch (System.Exception e)
    {
        Console.WriteLine(e.Message);
        return null;
    }
}



var sheetsService = new GoogleSheetsService();
var items = sheetsService.GetSheetItems();

using (var db = new ScrapperDbContext())
{
    foreach (var item in items)
    {
        // Check if the product already exists in the database and creeate it if it does not
        var existingProduct = db.Products.FirstOrDefault(p => p.ProductId_EU == item.ProductId_EU);
        if (existingProduct == null)
        {
            var product = new Product
            {
                Name = item.Name,
                Family = item.Family,
                Manufacturer = item.Manufacturer,
                Type = item.Type,
                ProductId_EU = item.ProductId_EU,
                ProductId_US = item.ProductId_US,
                Description = item.Description
            };

            db.Products.Add(product);
        }
    }

    db.SaveChanges();
}

var respones = new List<IkeaJSONResponse>();
using (var db = new ScrapperDbContext())
{
    foreach (var item in db.Products.ToList())
    {
        // Fetch the data for each locale and productId
        foreach (var locale in Locales.GetLocales())
        {

            if (item.ProductId_EU != null)
            {
                var euResponse = await FetchIkeaDataAsync(
                    ReviewUrlBuilder.BuildUrl(locale, item.ProductId_EU)
                );


                if (euResponse != null)
                {
                    euResponse.ProductId = item.Id;
                    respones.Add(euResponse);
                    Console.WriteLine($"Fetched data for locale {locale} and EU productId {item.ProductId_EU}");
                }
            }

            if (item.ProductId_US != null)
            {
                var usResponse = await FetchIkeaDataAsync(
                    ReviewUrlBuilder.BuildUrl(locale, item.ProductId_US)
                );

                if (usResponse != null)
                {
                    usResponse.ProductId = item.Id;
                    respones.Add(usResponse);
                    Console.WriteLine($"Fetched data for locale {locale} and US productId {item.ProductId_US}");
                }
            }
        }
    }
}

foreach (var response in respones)
{
    using (var context = new ScrapperDbContext())
    {
        var reviews = response.Reviews.Select(r => Mapping.MapReviewResponseToReview(response.ProductId, r)).ToList();
        foreach (var review in reviews)
        {
            // Check if the review already exists in the database
            var existingReview = context.Reviews.FirstOrDefault(r => r.ReviewGuid == review.ReviewGuid);

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