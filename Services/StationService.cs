using EADBackend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Services
{
    public class StationService
    {
        private readonly IMongoCollection<Station> _stationCollection;

        public StationService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            MongoClient client = new MongoClient(mongoDbSettings.Value.CONNECTION_STRING);
            IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DATABASE_NAME);
            _stationCollection = database.GetCollection<Station>(mongoDbSettings.Value.STATION_COLLECTION_NAME);

        }

        public async Task<Station> CreateStationAsync(Station station)
        {
          await _stationCollection.InsertOneAsync(station);
            return station;
        }

        public async Task<List<Station>> GetstationsAsync()
        {
            List<Station> stationlist =  await _stationCollection.Find(new BsonDocument()).ToListAsync();
            return stationlist;
        }

        public async Task<Station> IncrementCars_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Cars_quque_count", (station.Cars_quque_count +1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return station;

        }

        public async Task IncrementBikes_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Bike_quque_count", (station.Bike_quque_count + 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task IncrementThreeWheel_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Threewheel_quque_count", (station.Threewheel_quque_count + 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task IncrementOthersPrtrol_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Others_prtrol_quque_count", (station.Others_prtrol_quque_count + 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }


        public async Task IncrementBus_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Bus_quque_count", (station.Bus_quque_count + 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task IncrementVan_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Van_quque_count", (station.Van_quque_count + 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task IncrementOthersDiesel_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Others_diesel_count", (station.Others_diesel_count + 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }


        public async Task DcrementCars_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Cars_quque_count", (station.Cars_quque_count - 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }



        //start here

        public async Task DecrementBikes_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Bike_quque_count", (station.Bike_quque_count - 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task DecrementThreeWheel_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Threewheel_quque_count", (station.Threewheel_quque_count - 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task DecrementOthersPrtrol_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Others_prtrol_quque_count", (station.Others_prtrol_quque_count - 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }


        public async Task DecrementBus_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Bus_quque_count", (station.Bus_quque_count -1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task DecrementVan_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Van_quque_count", (station.Van_quque_count -1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        public async Task DecrementOthersDiesel_ququeAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Others_diesel_count", (station.Others_diesel_count - 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }


        //gas available state update 


        public async Task Update_Petrol_AvailabilityAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Petrol_available_state", station.Petrol_available_state);

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }


        public async Task Update_diesel_AvailabilityAsync(string id, Station station)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set("Diesel_available_state", station.Diesel_available_state);

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

      



        public async Task DeleteStationAsync(string id)
        {
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            await _stationCollection.DeleteOneAsync(filter);
        }

        //CommonQuqueIncrement
        public async Task IncrementququeAsync(string id,string quque, Station station)
        {
            int incrementvalue = 0;
            if (quque.Equals("Cars_quque_count"))
            {
                incrementvalue = station.Cars_quque_count;
            }
            else if (quque.Equals("Bike_quque_count")) {
                incrementvalue = station.Bike_quque_count;
            }
            else if (quque.Equals("Threewheel_quque_count"))
            {
                incrementvalue = station.Threewheel_quque_count;
            }
            else if (quque.Equals("Others_prtrol_quque_count"))
            {
                incrementvalue = station.Others_prtrol_quque_count;
            }
            else if (quque.Equals("Bus_quque_count"))
            {
                incrementvalue = station.Bus_quque_count;
            }
            else if (quque.Equals("Van_quque_count"))
            {
                incrementvalue = station.Van_quque_count;
            }
            else if (quque.Equals("Others_diesel_count"))
            {
                incrementvalue = station.Others_diesel_count;
            }
            else
            {
                incrementvalue = 0;
            }
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set(quque,(incrementvalue + 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        // common decrement quque

        public async Task DecrementququeAsync(string id, string quque, Station station)
        {
            int incrementvalue = 0;
            if (quque.Equals("Cars_quque_count"))
            {
                incrementvalue = station.Cars_quque_count;
            }
            else if (quque.Equals("Bike_quque_count"))
            {
                incrementvalue = station.Bike_quque_count;
            }
            else if (quque.Equals("Threewheel_quque_count"))
            {
                incrementvalue = station.Threewheel_quque_count;
            }
            else if (quque.Equals("Others_prtrol_quque_count"))
            {
                incrementvalue = station.Others_prtrol_quque_count;
            }
            else if (quque.Equals("Bus_quque_count"))
            {
                incrementvalue = station.Bus_quque_count;
            }
            else if (quque.Equals("Van_quque_count"))
            {
                incrementvalue = station.Van_quque_count;
            }
            else if (quque.Equals("Others_diesel_count"))
            {
                incrementvalue = station.Others_diesel_count;
            }
            else
            {
                incrementvalue = 0;
            }
            FilterDefinition<Station> filter = Builders<Station>.Filter.Eq("Id", id);
            UpdateDefinition<Station> update = Builders<Station>.Update.Set(quque, (incrementvalue - 1));

            await _stationCollection.UpdateOneAsync(filter, update);
            return;

        }

        //search station

        public async Task<Station> SearchstationsAsync(int stationId)
        {
            Station resultstation = await _stationCollection.Find(staion=>staion.StationId == stationId).FirstOrDefaultAsync();
            return resultstation;

        }

        public async Task<List<Station>> getstationsofownerAsync(string ownerid)
        {
            List<Station> resultstationlist = await _stationCollection.Find(staion => staion.OwnerId == ownerid).ToListAsync();
            return resultstationlist;

        }

    }
}
