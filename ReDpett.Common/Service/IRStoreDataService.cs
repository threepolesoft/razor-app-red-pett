using Newtonsoft.Json;

namespace ReDpett.Service
{
    public class IRStoreDataService : IntermediateResidentDataService
    {
        string applicationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ReDpettApp");
        
        private ListIntermediateResidentData _data;
        private static readonly string _fileName = "IntermediateResidents.json";
        public IRStoreDataService(ListIntermediateResidentData data)
        {
            _data = data;
        }

        public async Task<ListIntermediateResidentData> GetDataFromOfflineDB()
        {
            try
            {
                if (!Directory.Exists(applicationFolderPath))
                {
                    Directory.CreateDirectory(applicationFolderPath);
                }
                string databaseFileName = Path.Combine(applicationFolderPath, _fileName);
                if(!File.Exists(databaseFileName))
                {
                    var myFile = File.Create(databaseFileName);
                    myFile.Close();
                }

                var str = File.ReadAllText(databaseFileName);
                if (!String.IsNullOrEmpty(str))
                {
                    var data = JsonConvert.DeserializeObject<ListIntermediateResidentData>(str);
                    _data = data;
                }
                
            }
            catch (Exception ex)
            {
               // await Application.Current.MainPage.DisplayAlert("Alert!", "Data was retrived from local db. Error Occured.." + ex.Message, "OK");
            }
            return _data;
        }

        public async void InsertOfflineDB(ListIntermediateResidentData __data)
        {
            try
            {
                if (!Directory.Exists(applicationFolderPath))
                {
                    Directory.CreateDirectory(applicationFolderPath);
                }
                string databaseFileName = Path.Combine(applicationFolderPath, _fileName);

                string req_json_string = JsonConvert.SerializeObject(__data);
                File.WriteAllText(databaseFileName, req_json_string);
            }
            catch (Exception ex)
            {
               // await Application.Current.MainPage.DisplayAlert("Alert!", "Data was not saved in local db. Error Occured.." + ex.Message, "OK");
            }
        }

    }
}
