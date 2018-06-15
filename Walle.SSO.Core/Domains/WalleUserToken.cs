using System;
using System.Collections.Generic;
using System.Text;
using Walle.Components.Const;

namespace Walle.SSO.Core.Domains
{
    public class WalleUserToken : Domain
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime Expire { get; set; } = DateTimeValue.Default;
    }
}
