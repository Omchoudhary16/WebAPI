using EOD_Db_Layer.Model;

namespace EOD_Service_Layer.Interface
{
    public interface IEodService 
    {
        Task<List<EodModel>> GetAsync();
        Task<EodModel?> GetAsync(string id);
        Task CreateAsync(EodModel newEodModel);
        Task UpdateAsync(string id, EodModel updatedEodModel);
        Task RemoveAsync(string id);
    }
}
