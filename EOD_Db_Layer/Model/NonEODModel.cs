using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD_Db_Layer.Model
{
    public class NonEODModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateOnly Date { get; set; }

        public string LeaveType { get; set; }
        public string Note { get; set; }

        public bool DayType { get; set; }
    }
}
