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
    var ikeaResponse = JsonSerializer.Deserialize<IkeaJSONResponse>(content);

    return ikeaResponse;
}

var response = await FetchIkeaDataAsync("https://api.tugc.ingka.com/review/info/v4/reviews/hr/hr/50552975");
