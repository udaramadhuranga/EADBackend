using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Models
{
    public class MongoDBSettings
    {
        public string CONNECTION_STRING { get; set; } = null;
        public string DATABASE_NAME { get; set; } = null;

        public string COLLECTION_NAME { get; set; } = null;

        public string STATION_COLLECTION_NAME { get; set; } = null;
    }
}
