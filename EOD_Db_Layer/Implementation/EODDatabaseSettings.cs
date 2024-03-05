using EOD_Db_Layer.Interface;

namespace EOD_Db_Layer.Implementation
{
    public class EODDatabaseSettings : IEODDatabaseSettings
    {
        public string ConnectionStrings { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;        
    }
}
