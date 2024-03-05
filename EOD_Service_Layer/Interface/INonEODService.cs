using EOD_Db_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD_Service_Layer.Interface
{
    public interface INonEODService
    {
        Task<List<NonEODModel>> GetAsync();
        Task<NonEODModel?> GetAsync(string id);
        Task CreateAsync(NonEODModel newNonEODModel);
        Task UpdateAsync(string id, NonEODModel updatedNonEODModel);
        Task RemoveAsync(string id);
    }
}
