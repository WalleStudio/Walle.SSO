using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Walle.Components.Mongodb.Interface
{
	public interface IMongoEntityBase
	{
        [BsonId]
		ObjectId Id { get; set; }
	}
}
