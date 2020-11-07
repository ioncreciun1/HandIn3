using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using HandIn_3.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace HandIn3.Database
{
    public class UserDAOImpl : UserDAO
    {
        private MongoClient client;
        private IMongoDatabase database;

        public UserDAOImpl()
        {
            client = new MongoClient("mongodb+srv://admin:admin@test.b0aui.mongodb.net/HandIn3?retryWrites=true&w=majority");
            database = client.GetDatabase("HandIn3");
        }
        public async Task<IList<User>> getUsers()
        {
            IList<User> users = new List<User>();
            var collection = database.GetCollection<BsonDocument>("Users");
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach(BsonDocument doc in documents)
            {
                var user = BsonSerializer.Deserialize<User>(doc);
                users.Add(user);
            }
           return users;
        }
    }
}