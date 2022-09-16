using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ManageBunker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateSpeardsheet_Click(object sender, EventArgs e)
        {
            CreateSheet();
        }
        public Google.Apis.Drive.v3.Data.File CreateSheet()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,
                      DriveService.Scope.DriveFile,};
            var clientId = "70360481467-ecj6j608hg9in2t4da3ee6g0nqnnlha6.apps.googleusercontent.com";      // From https://console.developers.google.com  
            var clientSecret = "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";          // From https://console.developers.google.com  
                                                                  // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, scopes,
            Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
            //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   
            DriveService _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DemoApp",

            });
            var _parent = "";//ID of folder if you want to create spreadsheet in specific folder
            var filename = "DemoApp";
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = filename,
                MimeType = "application/vnd.google-apps.spreadsheet",
                //TeamDriveId = teamDriveID, // IF you want to add to specific team drive  
            };
            FilesResource.CreateRequest request = _service.Files.Create(fileMetadata);
            request.SupportsTeamDrives = true;
            fileMetadata.Parents = new List<string> { _parent }; // Parent folder id or TeamDriveID  
            request.Fields = "id";
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            var file = request.Execute();
            MessageBox.Show("File ID: " + file.Id);
            return file;
        }

        private void btnUpdateSpreadsheet_Click(object sender, EventArgs e)
        {
            UpdateSpreadSheet();
        }
        private void UpdateSpreadSheet()
        {
            // SpreadhSheetID of above created document.  
            var SheetId = "1ZCIKtF2FE2BHnIgmiLu3junMJGKRDJfU2RbXQ_BksN8";
            var service = AuthorizeGoogleAppForSheetsService();
            string newRange = GetRange(service, SheetId);
            IList<IList<Object>> objNeRecords = GenerateData();
            UpdatGoogleSheetinBatch(objNeRecords, SheetId, newRange, service);
            MessageBox.Show("done!");
        }
        private static SheetsService AuthorizeGoogleAppForSheetsService()
        {
            // If modifying these scopes, delete your previously saved credentials  
            // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json  
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string ApplicationName = "Google Sheets API .NET Quickstart";
            UserCredential credential;
            using (var stream =
               new FileStream("spreadsheetcredentials.json", FileMode.Open, FileAccess.Read))
            {

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("MyAppsToken")).Result;

            }

            // Create Google Sheets API service.  
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
        protected static string GetRange(SheetsService service, string SheetId)
        {
            // Define request parameters.  
            String spreadsheetId = SheetId;
            String range = "A:A";

            SpreadsheetsResource.ValuesResource.GetRequest getRequest =
                       service.Spreadsheets.Values.Get(spreadsheetId, range);
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            ValueRange getResponse = getRequest.Execute();
            IList<IList<Object>> getValues = getResponse.Values;
            if (getValues == null)
            {
                // spreadsheet is empty return Row A Column A  
                return "A:A";
            }

            int currentCount = getValues.Count() + 1;
            String newRange = "A" + currentCount + ":A";
            return newRange;
        }
        private static IList<IList<Object>> GenerateData()
        {
            List<IList<Object>> objNewRecords = new List<IList<Object>>();
            int maxrows = 5;
            for (var i = 1; i <= maxrows; i++)
            {
                IList<Object> obj = new List<Object>();
                obj.Add("Data row value - " + i + "A");
                obj.Add("Data row value - " + i + "B");
                obj.Add("Data row value - " + i + "C");
                objNewRecords.Add(obj);
            }
            return objNewRecords;
        }

        private static void UpdatGoogleSheetinBatch(IList<IList<Object>> values, string spreadsheetId, string newRange, SheetsService service)
        {
            SpreadsheetsResource.ValuesResource.AppendRequest request =
               service.Spreadsheets.Values.Append(new ValueRange() { Values = values }, spreadsheetId, newRange);
            request.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
            var response = request.Execute();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}