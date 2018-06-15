using System;
using System.Collections.Generic;
using System.Text;

namespace Walle.SSO.Core.Domains
{
    public class WalleAppAuth : Domain
    {
        public string AppId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
    }
}
