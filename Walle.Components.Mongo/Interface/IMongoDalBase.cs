using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Walle.Components.Mongodb.Interface
{
    public interface IMongoDalBase<T> where T : IMongoEntityBase, new()
    {
        T GetById(string id);
        string Add(T document);
        bool Delete(string id);
    }
}
