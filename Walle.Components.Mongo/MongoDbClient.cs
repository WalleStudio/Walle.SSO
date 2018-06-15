using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walle.Components.Mongodb
{
    public class MongoDbClient
    {
        private static MongoDbClient dbclient = null;
        public MongoClient client = null;
        private MongoDbClient()
        {
            try
            {
                MongoClientSettings set = new MongoClientSettings();
                List<MongoServerAddress> address = new List<MongoServerAddress>();
                List<MongoCredential> lstCredential = new List<MongoCredential>();
                //加载配置
                string ConnectStr = MongodbConfig.Instance.ConnectStr;
                if (string.IsNullOrEmpty(ConnectStr))
                {
                    ConnectStr = "mongodb://localhost";
                }
                client = new MongoClient(ConnectStr);
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        public static MongoDbClient Instance
        {
            get
            {
                if (dbclient != null && dbclient.client != null)
                {
                    return dbclient;
                }
                else
                {
                    dbclient = new MongoDbClient();
                    return dbclient;
                }
            }
        }

        public IMongoDatabase GetDefaultDataBase()
        {
            return client.GetDatabase(MongodbConfig.Instance.DbName);
        }

        public IMongoCollection<T> GetDefaultCollection<T>()
        {
            var database = GetDefaultDataBase();
            var type = typeof(T);
            var collectionName = type.Name;
            var collection = database.GetCollection<T>(collectionName);
            return collection;
        }
    }
}
