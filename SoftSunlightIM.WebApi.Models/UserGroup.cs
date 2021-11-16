using System;
using System.Collections.Generic;
using System.Text;

namespace SoftSunlightIM.WebApi.Models
{
    /// <summary>
    /// 用户群组
    /// </summary>
    public class UserGroup
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 群组账号
        /// </summary>
        public string GroupAccount { get; set; }
        /// <summary>
        /// 群组名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
