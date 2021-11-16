using System;

namespace SoftSunlightIM.WebApi.Models
{
    /// <summary>
    /// 用户好友
    /// </summary>
    public class UserFriend
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 好友账号
        /// </summary>
        public string FriendAccount { get; set; }
        /// <summary>
        /// 所属分组Id
        /// </summary>
        public int? GroupId { get; set; }
        /// <summary>
        /// 所属分组名称
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
