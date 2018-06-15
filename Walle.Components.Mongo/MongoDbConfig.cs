using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walle.Components.Mongodb
{
    public class MongodbConfig : Singleton<MongodbConfig>
    {
        private string connectStr = string.Empty;
        private string dbName = string.Empty;
        public string ConnectStr
        {
            get
            {
                if (string.IsNullOrWhiteSpace(connectStr))
                {
                    connectStr = $"mongodb://127.0.0.1:27017/{dbName}";
                    return connectStr;
                }
                return connectStr;
            }
            set
            {
                this.connectStr = value;
            }
        }

        public string DbName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(dbName))
                {
                    dbName = "dbname";
                    return dbName;
                }
                return dbName;
            }
            set
            {
                this.dbName = value;
            }
        }
    }
}
