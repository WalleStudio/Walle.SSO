using MongoDB.Bson.Serialization.Attributes;

namespace Walle.SSO.Core.Domains
{
    public class WalleApp : Domain
    {
        /// <summary>
        /// App名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// App 接入秘钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// App 登录页面背景图片
        /// </summary>
        public string AppImage { get; set; } = string.Empty;

        /// <summary>
        /// App Icon 
        /// </summary>
        public string AppIcon { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// App管理员Id
        /// </summary>
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// App管理部门Id
        /// </summary>
        public string OwnerDeptId { get; set; } = string.Empty;

        /// <summary>
        /// App管理部门 
        /// </summary>
        [BsonIgnore]
        public WalleDept OwnerDept { get; set; } = new WalleDept();

        /// <summary>
        /// App管理员
        /// </summary>
        [BsonIgnore]
        public WalleUser Owner { get; set; } = new WalleUser();

    }
}
