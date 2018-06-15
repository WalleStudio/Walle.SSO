using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Walle.Components.Mongodb.Interface;

namespace Walle.Components.Mongodb.Base
{
    public class MongoEntityBase : IMongoEntityBase
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime GetCreateTime()
        {
            return DateTime.Parse(Id.CreationTime.ToLocalTime().ToString());
        }
     
        public string GetId()
        {
            return Id.ToString();
        }
    }
}
