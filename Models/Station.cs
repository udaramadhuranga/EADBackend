using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Models
{
    public class Station
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string StationName { get; set; }

        public int StationId { get; set; }

        public string OwnerId { get; set; }

        public string Petrol_available_state { get; set; }

        public string Diesel_available_state { get; set; }

        public int Cars_quque_count { get; set; }

        public int Bike_quque_count { get; set; }

        public int Threewheel_quque_count { get; set; } 

        public int Others_prtrol_quque_count { get; set; }
        
        public int Bus_quque_count { get; set; }

        public int Van_quque_count { get; set; }

        public int Others_diesel_count { get; set; }

        public string  address { get; set; }

        public int Fueling_Time_per_vehicle { get; set; }

        public DateTime Next_petrol_refill_date { get; set; }

        public DateTime Next_diesel_refill_date { get; set; }

    }
}
