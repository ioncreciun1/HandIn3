using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using HandIn3.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace HandIn3.Database
{
    public class DAOAdultsImpl : DAOAdults
    {
        private MongoClient client;
        private IMongoDatabase database;

        public DAOAdultsImpl()
        {
            client = new MongoClient(
                "mongodb+srv://admin:admin@test.b0aui.mongodb.net/HandIn3?retryWrites=true&w=majority");
            database = client.GetDatabase("HandIn3");
        }

        public async Task<IList<Adult>> getAdults(
            string firstName,
            string lastName,
            string jobTitle,
            string hairColor,
            string eyeColor,
            string sex,
            int? age,
            int? AdultID
        )
        {
            FilterDefinition<BsonDocument> filter = FilterDefinition<BsonDocument>.Empty;
            if (firstName != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("FirstName", firstName);
            }

            if (lastName != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("LastName", lastName);
            }

            if (jobTitle != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("JobTitle", jobTitle);
            }

            if (hairColor != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("HairColor", hairColor);
            }

            if (eyeColor != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("EyeColor", eyeColor);
            }

            if (sex != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("Sex", sex);
            }

            if (age != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("Age", age);
            }

            if (AdultID != null)
            {
                filter = filter & Builders<BsonDocument>.Filter.Eq("AdultID", AdultID);
            }
            
            List<Adult> adults = new List<Adult>();
            var collection = database.GetCollection<BsonDocument>("Adults");
            var documents = collection.Find(filter).ToList();
            foreach (BsonDocument doc in documents)
            {
                var adult = BsonSerializer.Deserialize<Adult>(doc);
                adults.Add(adult);
            }

            return adults;
        }

        public async Task addAdult(Adult adult)
        {
            var collection = database.GetCollection<BsonDocument>("Adults");
            var document = adult.ToBsonDocument();
            collection.InsertOne(document);
        }

        public async Task deleteAdult(int adultID)
        {
            var collection = database.GetCollection<BsonDocument>("Adults");
            var deleteFilter = Builders<BsonDocument>.Filter.Eq("AdultID", adultID);
            collection.DeleteOne(deleteFilter);
        }

        public async Task updateAdult(int adultID)
        {
            var collection = database.GetCollection<BsonDocument>("Adults");
            var filter = Builders<BsonDocument>.Filter.Eq("AdultID", adultID);
            var update = Builders<BsonDocument>.Update.Set("AdultID", adultID);
            collection.UpdateOne(filter, update);
        }
    }
}