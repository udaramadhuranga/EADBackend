using EADBackend.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EADBackend.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            MongoClient client = new MongoClient(mongoDbSettings.Value.CONNECTION_STRING);
            IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DATABASE_NAME);
            _userCollection = database.GetCollection<User>(mongoDbSettings.Value.USERS_COLLECTION_NAME);

        }

        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                await _userCollection.InsertOneAsync(user);
                return user;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> GetUrsersAsync()
        {
            try
            {
                return await _userCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public async Task DeleteUserAsync(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
            await _userCollection.DeleteOneAsync(filter);
        }

        public async Task UpdateUser(string id, User user)
        {
            try
            {
                FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
                await _userCollection.ReplaceOneAsync(filter, user);
                return;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public async Task<User> validateUser(string email, string password)
        {
            try
            {
                return await _userCollection.Find(user => user.Email.Equals(email) && user.Password.Equals(password)).FirstOrDefaultAsync();

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            }

        public string GenerateJSONWebToken(User users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzINi"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
           {
                new Claim("email",users.Email),
                new Claim("password",users.Password)
        };
            var token = new JwtSecurityToken("EADBackend",
              "EADBackend",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<User> GetUrserAsync(string id)
        {
            try
            {
                return await _userCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
