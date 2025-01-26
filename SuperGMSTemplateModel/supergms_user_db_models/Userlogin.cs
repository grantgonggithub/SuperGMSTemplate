using System;
using System.Collections.Generic;

namespace SuperGMSTemplateModel.supergms_user_db_models
{
    public partial class Userlogin
    {
        /// <summary>
        /// 关联UserInfo的UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string LoginPassWord { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
