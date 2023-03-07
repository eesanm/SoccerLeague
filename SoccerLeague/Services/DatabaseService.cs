using MongoDB.Bson;
using MongoDB.Driver;
using SoccerLeague.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeague.Services
{
    public static class DatabaseService
    {
        private const string _connectionString = "mongodb+srv://demouser:W1kerXxKdL0oHYAL@cluster0.pqv4vu8.mongodb.net/?retryWrites=true&w=majority";
        private static MongoClientSettings _settings =
            MongoClientSettings.FromConnectionString(_connectionString);

        public static void PersistLeague(League league)
        {
            try
            {
                _settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                var client = new MongoClient(_settings);

                var collection = client.GetDatabase("soccer").GetCollection<BsonDocument>("league");
                collection.DeleteMany(new BsonDocument());

                var documents = new List<BsonDocument>();

                league.GetLeague().ForEach(team =>
                {
                    documents.Add(new BsonDocument {
                    { "name", team.Key },
                    { "points", team.Value}
                    });
                });

                collection.InsertMany(documents);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error writing to the db", ex);
            }

        }
    }
}
