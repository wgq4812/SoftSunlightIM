using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSunlightIM
{
    public class ApiResponse
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}
