using System;
using System.Collections.Generic;

namespace SuperGMSTemplateModel.supergms_user_db_models
{
    public partial class LoginLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public string LoginIp { get; set; }
        public string ClientType { get; set; }
        public string ClientVersion { get; set; }
        public string LoginDevice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
