using System;

namespace Walle.SSO.Models
{
    public class SignInModel
    {
        public string UserName { get; set; } = string.Empty;

        public string Password {get;set;} = string.Empty;
    }
}