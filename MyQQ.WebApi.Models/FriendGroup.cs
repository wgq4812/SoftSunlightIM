using System;

namespace MyQQ.WebApi.Models
{
    /// <summary>
    /// 用户好友分组
    /// </summary>
    public class FriendGroup
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id{ get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account{ get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName{ get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime{ get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime{ get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark{ get; set; }
    }
}
