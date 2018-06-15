using System.Linq;
using Walle.Components.Extensions;
using Walle.SSO.Core.Domains;
using static Walle.Components.Mongodb.MongoContext;


namespace Walle.SSO.Business
{
    public class AuthBusiness
    {
        public string SignInToken(string username, string password)
        {
            return string.Empty;
        }

        public bool SignOutToken(string token)
        {
            var users = Context<WalleUser>().Query(p => p.AccessToken == token);
            if (users.HasAny())
            {
                var usr = users.First();
                usr.AccessToken = string.Empty;
               
            }
            else
            {
                return null;
            }
            return false;
        }

        public WalleUser GetUserInfo(string token)
        {
            var users = Context<WalleUser>().Query(p => p.AccessToken == token);
            if (users.HasAny())
            {
                var usr = users.First();
                usr.Password = string.Empty;
                usr.Dept = Context<WalleDept>().GetById(usr.DeptId);
                return usr;
            }
            else
            {
                return null;
            }
        }
    }
}
