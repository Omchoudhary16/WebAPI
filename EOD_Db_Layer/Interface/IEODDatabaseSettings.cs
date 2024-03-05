namespace EOD_Db_Layer.Interface
{
    public interface IEODDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
