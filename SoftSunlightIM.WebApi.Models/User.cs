using System;

namespace MyQQ.WebApi.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
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
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPicUrl { get; set; }
        /// <summary>
        /// PC端在线状态
        /// </summary>
        public int PcOnlineStatus { get; set; }
        /// <summary>
        /// Web端在线状态
        /// </summary>
        public int WebOnlineStatus { get; set; }
        /// <summary>
        /// 手机端在线状态
        /// </summary>
        public int MobileOnlineStatus { get; set; }
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
