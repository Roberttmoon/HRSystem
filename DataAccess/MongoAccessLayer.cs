﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MongoAccessLayer
    {
        public static IMongoClient _client;
        public static IMongoDatabase _database;
        public static IMongoCollection<BsonDocument> _collection;
        public string _connectionString;

        public MongoAccessLayer(string database, string collection)
        {
            _connectionString = GetConnectionString();
            Trace.WriteLine(_connectionString);
            _client = new MongoClient(_connectionString);
            _database = _client.GetDatabase(database);
            _collection = _database.GetCollection<BsonDocument>(collection);
        }

        public List<T> GetAllDocuments<T>()
        {
            List<T> output = new List<T>();
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Empty;
            List<BsonDocument> result = _collection.Find(filter).ToList();
            foreach (BsonDocument doc in result)
            {
                output.Add(DeserializeFromBson<T>(doc));
            }
            return output;
        }

        public T DeserializeFromBson<T>(BsonDocument document)
        {
            return MongoDB.Bson.Serialization.BsonSerializer.Deserialize<T>(document);
        }

        public void AddDocumentFromJsonString(string json)
        {
            BsonDocument document = JsonStringToBson(json);
            _collection.InsertOne(document);
        }

        public BsonDocument JsonStringToBson(string json)
        {
            return MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(json);
        }

        public string SerializeBsonToString(BsonDocument document)
        {
            return BsonExtensionMethods.ToJson(document);
        } 


        public async void AddMultipleBson(List<BsonDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public List<string> QueryTopLevel(KeyValuePair<string, string> inputFilter)
        {
            List<string> jsonDocs = new List<string>();
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq(inputFilter.Key, inputFilter.Value);
            List<BsonDocument> result = _collection.Find(filter).ToList();
            foreach(BsonDocument doc in result)
            {
                jsonDocs.Add(SerializeBsonToString(doc));
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
            BsonDocument document = JsonStringToBson(json);
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
