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
    public class MongoDBServices
    {
        private readonly IMongoCollection<Vehicle> _vehicleCollection;

        public MongoDBServices(IOptions<MongoDBSettings> mongoDbSettings)
        {
            MongoClient client = new MongoClient(mongoDbSettings.Value.CONNECTION_STRING);
            IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DATABASE_NAME);
            _vehicleCollection = database.GetCollection<Vehicle>(mongoDbSettings.Value.COLLECTION_NAME);

        }

        public async Task CreateVehicleAsync(Vehicle vehicle)
        {
            await _vehicleCollection.InsertOneAsync(vehicle);
            return;
        }

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            return await _vehicleCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateVehicleAsync(string id, Vehicle vehicle)
        {
            FilterDefinition<Vehicle> filter = Builders<Vehicle>.Filter.Eq("Id", id);
            UpdateDefinition<Vehicle> update = Builders<Vehicle>.Update.Set("Type", vehicle.Type);

            await _vehicleCollection.UpdateOneAsync(filter, update);
            return;
        
        }

        public async Task DeleteVehicleAsync(string id)
        {
            FilterDefinition<Vehicle> filter = Builders<Vehicle>.Filter.Eq("Id", id);
            await _vehicleCollection.DeleteOneAsync(filter);
        }
    }
}
