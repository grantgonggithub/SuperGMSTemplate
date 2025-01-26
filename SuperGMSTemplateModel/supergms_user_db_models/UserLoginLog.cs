using System;
using System.Collections.Generic;

namespace SuperGMSTemplateModel.supergms_user_db_models
{
    public partial class UserLoginLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 登录用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
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
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
