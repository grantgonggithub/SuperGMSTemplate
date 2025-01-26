using Newtonsoft.Json;

using SuperGMS.JsonEx;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGMSTemplateDto.UserLoginLogDto
{
    public class GetUserLoginLogResult
    {
        public int Id { get; set; }
        /// <summary>
        /// 登录用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        [DefaultValue(typeof(DateTime), SuperGMSDateTimeJsonConvert.DefaultDateTimeValueString)] // 设置默认值为1900-1-1,用于反序列化赋值
        [JsonConverter(typeof(SuperGMSDateTimeJsonConvert))] // 用于序列化时将1900-1-1设置为空字符串
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIp { get; set; }
        /// <summary>
        /// 登录客户端类型
        /// </summary>
        public string ClientType { get; set; }
        /// <summary>
        /// 登录客户端版本号
        /// </summary>
        public string ClientVersion { get; set; }
        /// <summary>
        /// 登录设备信息
        /// </summary>
        public string LoginDevice { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DefaultValue(typeof(DateTime), SuperGMSDateTimeJsonConvert.DefaultDateTimeValueString)] // 设置默认值为1900-1-1,用于反序列化赋值
        [JsonConverter(typeof(SuperGMSDateTimeJsonConvert))] // 用于序列化时将1900-1-1设置为空字符串
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 性别 1男 2女
        /// </summary>
        public int? Sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [DefaultValue(typeof(DateTime), SuperGMSDateTimeJsonConvert.DefaultDateTimeValueString)] // 设置默认值为1900-1-1,用于反序列化赋值
        [JsonConverter(typeof(SuperGMSDateTimeJsonConvert))] // 用于序列化时将1900-1-1设置为空字符串
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
