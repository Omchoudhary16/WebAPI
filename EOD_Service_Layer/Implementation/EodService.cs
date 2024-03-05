using EOD_Db_Layer.Implementation;
using EOD_Db_Layer.Model;
using EOD_Service_Layer.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace EOD_Service_Layer.Implementation
{
    public class EodService : IEodService
    {
        private readonly IMongoCollection<EodModel> _eodService;

        public EodService(IOptions<EODDatabaseSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _eodService = database.GetCollection<EodModel>("EODCollection");
        }

        public async Task CreateAsync(EodModel newEodModel)
        {
            var eodModel = new EodModel();
            if (newEodModel != null)
            {
                eodModel.WorkId = newEodModel.WorkId;
                eodModel.Title = newEodModel.Title;
                eodModel.Date = newEodModel.Date;
                eodModel.ADOTime = newEodModel.ADOTime;
                eodModel.AreaPath = newEodModel.AreaPath;
                eodModel.ProactTime = newEodModel.ProactTime;
                eodModel.WorkType = newEodModel.WorkType;
            }
            await _eodService.InsertOneAsync(eodModel);
        }

        public async Task<List<EodModel>> GetAsync()
        {
            return await _eodService.Find(_ => true).ToListAsync();
        }

        public async Task<EodModel?> GetAsync(string id)
        {
            return await _eodService.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _eodService.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, EodModel updatedEodModel)
        {
            await _eodService.ReplaceOneAsync(x => x.Id == id, updatedEodModel);
        }
    }
}
