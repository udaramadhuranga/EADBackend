using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EADBackend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("email")]
        public string Email  { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("phoneno")]
        public string PhoneNo { get; set; }
        [Required]
        [JsonPropertyName("nic")]
        public string NIC { get; set; }

        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        [JsonPropertyName("userrole")]
        public string UserRole { get; set; }

        [JsonPropertyName("vehicletypeid")]
        public string VehicleTypeId { get; set; }

        [JsonPropertyName("vehiclenumber")]
        public string VehicleNumber { get; set; }

    }
}
