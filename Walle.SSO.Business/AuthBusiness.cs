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
            var usertokens = Context<WalleUserToken>().Query(p => p.AccessToken == token);
            if (usertokens.HasAny())
            {
                var usertoken = usertokens.First();
                var result = Context<WalleUserToken>().Delete(usertoken.Id);
                return result;
            }
            return false;
        }

        public WalleUser GetUserInfo(string token)
        {
            var usertokens = Context<WalleUserToken>().Query(p => p.AccessToken == token);
            if (usertokens.HasAny())
            {
                var usertoken = usertokens.First();
                var user = Context<WalleUser>().GetById(usertoken.UserId);
                return user;
            }
            return null;
        }
    }
}
