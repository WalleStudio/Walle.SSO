using System;
using System.Collections.Generic;
using System.Text;
using Walle.Components.Mongodb.Base;
using Walle.Components.Mongodb.Interface;

namespace Walle.Components.Mongodb
{
    public static class MongoContext
    {
        public static MongoDalBase<T> Context<T>() where T : IMongoEntityBase, new() => new MongoDalBase<T>();
    }
}
