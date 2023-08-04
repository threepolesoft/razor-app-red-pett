
namespace ReDpett.Service
{
    public interface IntermediateResidentDataService
    {
        void InsertOfflineDB(ListIntermediateResidentData _data);
        Task<ListIntermediateResidentData> GetDataFromOfflineDB();
    }
}
