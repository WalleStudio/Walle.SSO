using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Walle.Components.Mongodb.Base;

namespace Walle.SSO.Core.Domains
{
    /// <summary>
    /// 基本用户信息
    /// </summary>
    public class WalleUser : Domain
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 密码(加密格式存储)
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 头像信息
        /// </summary>
        public string Avatar { get; set; } = string.Empty;

        /// <summary>
        /// Email信息
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 用户识别access_token
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// 用户所属部门Id
        /// </summary>
        public string DeptId { get; set; } = string.Empty;

        /// <summary>
        /// (可选) 用户所属部门
        /// </summary>
        [BsonIgnore]
        public WalleDept Dept { get; set; } = new WalleDept();

        /// <summary>
        /// (可选)目标登录App
        /// </summary>
        [BsonIgnore]
        public WalleApp TargetApp { get; set; } = new WalleApp();

        /// <summary>
        /// (可选)目标登录App中的角色
        /// </summary>
        [BsonIgnore]
        public WalleAppRole TargetAppRole { get; set; } = new WalleAppRole();
    }
}
