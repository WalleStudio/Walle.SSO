using Walle.Components.Mongodb.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Walle.Components.Mongodb.Base
{
    public class MongoDalBase<T> : IMongoDalBase<T> where T : IMongoEntityBase, new()
    {
        public T GetById(string id)
        {
            try
            {
                var result = MongoDbClient.Instance.Find<T>(p => p.Id == new ObjectId(id)).FirstOrDefault();
                return result;
            }
            catch
            {
                return default(T);
            }
        }
        public T GetById(ObjectId id)
        {
            try
            {
                var result = MongoDbClient.Instance.Find<T>(p => p.Id == id).FirstOrDefault();
                return result;
            }
            catch
            {
                return default(T);
            }
        }
        public string Add(T document)
        {
            MongoDbClient.Instance.Insert(document);
            return document.Id.ToString();
        }
        public bool Delete(string id)
        {
            var result = MongoDbClient.Instance.DeleteOne<T>(p => p.Id == new ObjectId(id));
            return result;
        }
        public bool Delete(ObjectId id)
        {
            var result = MongoDbClient.Instance.DeleteOne<T>(p => p.Id == id);
            return result;
        }
        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            var result = MongoDbClient.Instance.Find<T>(filter);
            return result;
        }
        public IQueryable<T> AsQueryable()
        {
            var col = MongoDbClient.Instance.GetDefaultCollection<T>();
            return col.AsQueryable();
        }
        public (IEnumerable<T> Result, long Count) Query(IQueryable<T> query, int pageIndex, int pageSize)
        {
            var count = query.Count<T>();
            if (pageIndex != 0 && pageSize != 0)
            {
                query = query.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
            var result = query.ToList();
            return (result, count);
        }
    }

}
