using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace EOD_Db_Layer.Model
{
    public class EodModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string WorkId { get; set; }

        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string AreaPath { get; set; }

        public string ADOTime { get; set; }

        public string ProactTime { get; set; }

        public string WorkType { get; set; } 

        public bool DayType { get; set; }
    }
}
