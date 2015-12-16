﻿using DataAccess;
using TaskTimeEntry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public static class ModelView
    {
        public static void AddCredentialsToDatabase(BillableAsset asset, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "credentials");
            List<Credentials> allCredentials = mongo.GetAllDocuments<Credentials>();
            if (!allCredentials.Exists(item => item.email == asset.email))
            {
                Credentials credentials = new Credentials(asset.email, asset._id, password);
                string json = Serializer<Credentials>.SerializeToJson(credentials);
                mongo.AddDocumentFromJsonString(json);
            } else
            {
                throw new Exception("Credentials Already Exist.");
            }
        }

        public static void AddAssetToDatabase(BillableAsset asset)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>();
            if (!assets.Exists(item => item.email == asset.email))
            {
                string json = Serializer<BillableAsset>.SerializeToJson(asset);
                mongo.AddDocumentFromJsonString(json);
            } else
            {
                throw new Exception("Asset already exists.");
            }
        }

        public static bool CheckCredentials(string email, string password)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "credentials");
            List<Credentials> credentials = mongo.GetAllDocuments<Credentials>();
            if (credentials.Exists(item => item.email == email && item.password == password)) return true;
            else return false;
        }

        public static BillableAsset GetAsset(string email)
        {
            MongoAccessLayer mongo = new MongoAccessLayer("main", "assets");
            List<BillableAsset> assets = mongo.GetAllDocuments<BillableAsset>();
            return assets.Find(item => item.email == email);
        }
    }
}
