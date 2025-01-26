using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGMSTemplateDto.UserLoginDto
{
    public class UserLoginContextInfo
    {
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录客户端类型
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// 登录客户端版本
        /// </summary>
        public string ClientVersion { get; set; }

        /// <summary>
        /// 登录客户端ip
        /// </summary>
        public string LoginIp { get; set; }

        /// <summary>
        /// 客户端设备信息
        /// </summary>
        public string DeviceInfo { get; set; }
    }
}
