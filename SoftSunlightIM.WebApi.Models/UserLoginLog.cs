using System;

namespace SoftSunlightIM.WebApi.Models
{
    /// <summary>
    /// 用户登录日志
    /// </summary>
    public class UserLoginLog
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
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// 登录地址
        /// </summary>
        public string LoginAddress { get; set; }
        /// <summary>
        /// 登录设备
        /// </summary>
        public int LoginDevice { get; set; }
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
