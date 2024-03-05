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
    public class NonEODService : INonEODService
    {
        private readonly IMongoCollection<NonEODModel> _nonEodService;

        public NonEODService(IOptions<EODDatabaseSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _nonEodService = database.GetCollection<NonEODModel>("NonEODCollection");
        }

        public async Task CreateAsync(NonEODModel newNonEODModel)
        {
            var nonEodModel = new NonEODModel();
            if(newNonEODModel != null)
            {
                nonEodModel.LeaveType = newNonEODModel.LeaveType;
                nonEodModel.DayType = newNonEODModel.DayType;
                nonEodModel.Date = newNonEODModel.Date;
                nonEodModel.Note = newNonEODModel.Note;
            }
            await _nonEodService.InsertOneAsync(nonEodModel);
        }

        public async Task<List<NonEODModel>> GetAsync()
        {
            return await _nonEodService.Find(_ => true).ToListAsync();
        }

        public async Task<NonEODModel?> GetAsync(string id)
        {
            return await _nonEodService.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _nonEodService.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, NonEODModel updatedNonEODModel)
        {
            await _nonEodService.ReplaceOneAsync(x => x.Id == id, updatedNonEODModel);
        }
    }
}
