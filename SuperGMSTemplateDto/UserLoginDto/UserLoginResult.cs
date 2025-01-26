using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGMSTemplateDto.UserLoginDto
{
    public class UserLoginResult
    {
        /// <summary>
        /// 登录成功后返回UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 登录凭证
        /// </summary>
        public string Token { get; set; }
    }
}
