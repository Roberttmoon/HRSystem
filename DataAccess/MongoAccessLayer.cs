using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MongoAccessLayer
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<BsonDocument> _collection;
        private string _connectionString;

        public MongoAccessLayer(string database, string collection)
        {
            _connectionString = GetConnectionString();
            _client = new MongoClient(_connectionString);
            _database = _client.GetDatabase(database);
            _collection = _database.GetCollection<BsonDocument>(collection);
        }

        public BsonDocument DeserializeFromString(string json)
        {
            return MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(json);
        }

        public string SerializeToString(BsonDocument document)
        {
            return BsonExtensionMethods.ToJson(document);
        } 

        public async void AddDocument(string singleDocumentJson)
        {
            BsonDocument document = DeserializeFromString(singleDocumentJson);
            await _collection.InsertOneAsync(document);
        }

        public async void AddMultipleBson(List<BsonDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public List<string> QueryTopLevel(KeyValuePair<string, string> inputFilter)
        {
            List<string> jsonDocs = new List<string>();
            FilterDefinition<BsonDocument> filters = Builders<BsonDocument>.Filter.Eq(inputFilter.Key, inputFilter.Value);
            List<BsonDocument> result = _collection.Find(filters).ToList();
            foreach(BsonDocument doc in result)
            {
                jsonDocs.Add(SerializeToString(doc));
            }
            return jsonDocs;
        }

        public async void UpdateTopLevel(KeyValuePair<string, string> updateFilter, KeyValuePair<string, string> updateSet)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq(updateFilter.Key, updateFilter.Value);
            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set(updateSet.Key, updateSet.Value);
            UpdateResult result = await _collection.UpdateOneAsync(filter, update);
        }

        public async void ReplaceDocument(KeyValuePair<string, string> replaceFilter, string json)
        {
            BsonDocument document = DeserializeFromString(json);
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq(replaceFilter.Key, replaceFilter.Value);
            ReplaceOneResult result = await _collection.ReplaceOneAsync(filter, document);
        }

        public async void DeleteDocument(KeyValuePair<string, string> deleteFilter)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq(deleteFilter.Key, deleteFilter.Value);
            DeleteResult result = await _collection.DeleteOneAsync(filter);
        }

        public string GetConnectionString()
        {
            string fileName = @"connectionstring.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            return File.ReadAllText(path);
        }

    }
}
