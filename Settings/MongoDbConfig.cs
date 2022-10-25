using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Settings
{
    public class MongoDbConfig
    {
        public string CONNECTION_STRINGs => "mongodb+srv://EAD:EAD12345@cluster0.rzmvinq.mongodb.net/FuelDB?retryWrites=true&w=majority";
        public string DATABASE_NAME { get; set; } = null;

        public string COLLECTION_NAME { get; set; } = null;

        public string STATION_COLLECTION_NAME { get; set; } = null;

        public string USERS_COLLECTION_NAME { get; set; } = null;
    }
}
