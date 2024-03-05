using EOD_Db_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD_Service_Layer.Interface
{
    public interface IWorkTypeService
    {
        Task<List<WorkType>> GetAsync();

        Task<WorkType?> GetAsync(string id);
        Task CreateAsync(WorkType newWorkType);
    }
}
