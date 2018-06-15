using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Walle.Components.Mongodb.Base;

namespace Walle.SSO.Core.Domains
{
    public class WalleDept : Domain
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; } = string.Empty;

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 部门负责人Id
        /// </summary>
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// 父部门Id
        /// </summary>
        public string ParentDeptId { get; set; } = string.Empty;

        /// <summary>
        /// (可选)父部门
        /// </summary>
        [BsonIgnore]
        public WalleDept ParentDept { get; set; } = new WalleDept();

        /// <summary>
        /// (可选)部门负责人
        /// </summary>
        [BsonIgnore]
        public WalleUser Owner { get; set; } = new WalleUser();

    }
}
