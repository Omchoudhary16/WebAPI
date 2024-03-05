using EOD_Db_Layer.Implementation;
using EOD_Db_Layer.Model;
using EOD_Service_Layer.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD_Service_Layer.Implementation
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly IMongoCollection<WorkType> _workTypeService;

        public WorkTypeService(IOptions<EODDatabaseSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _workTypeService = database.GetCollection<WorkType>("WorkCollection");
        }

        public async Task CreateAsync(WorkType newWorkType)
        {
            await _workTypeService.InsertOneAsync(newWorkType);
        }

        public async Task<List<WorkType>> GetAsync()
        {
            return await _workTypeService.Find(_ => true).ToListAsync();
        }

        public async Task<WorkType?> GetAsync(string id)
        {
            return await _workTypeService.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
