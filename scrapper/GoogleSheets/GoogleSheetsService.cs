// Write a class for loading data from Google Sheets called GoogleSheetsLoader

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

public class GoogleSheetsService
{
    static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    static string ApplicationName = "Furni.Tips sheet service";
    public SheetsService SheetService { get; set; }
    public GoogleSheetsService()
    {
        try
        {
            UserCredential credential;
            // Load client secrets.
            using (var stream =
                   new FileStream("./GoogleSheets/credentials/credentials.json", FileMode.Open, FileAccess.Read))
            {
                /* The file token.json stores the user's access and refresh tokens, and is created
                 automatically when the authorization flow completes for the first time. */
                string credPath = "./GoogleSheets/credentials/";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            this.SheetService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });

        }
        catch (FileNotFoundException e)
        {
            this.SheetService = new SheetsService();
            Console.WriteLine(e.Message);
        }
    }


    public List<SheetItem> GetSheetItems()
    {
        var results = new List<SheetItem>();
        var FURNI_TIPS_SHEET = "11n87cxLEYdrUMJpmZ4AnWfwHD8EV8kX6kQTAnb4FAdM";
        var GET_RANGE = "A2:H";

        foreach (int i in Enum.GetValues(typeof(UnitTypes)))
        {
            var SUBSHEET_NAME = $"{Enum.GetName(typeof(UnitTypes), i)}";

            var request = this.SheetService.Spreadsheets.Values.Get(FURNI_TIPS_SHEET, $"{SUBSHEET_NAME}!{GET_RANGE}");

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            if (values == null || values.Count == 0)
            {
                Console.WriteLine("No data found.");
                return results;
            }

            results.AddRange(SheetItemsMapper.MapFromRangeData(values));
            Console.WriteLine($"[{values.Count}] {SUBSHEET_NAME} found");
        }

        return results;
    }
}