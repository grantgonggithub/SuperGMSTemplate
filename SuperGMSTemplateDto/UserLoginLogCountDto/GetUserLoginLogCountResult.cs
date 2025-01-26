using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGMSTemplateDto.UserLoginLogCountDto
{
    public class GetUserLoginLogCountResult
    {
        /// <summary>
        /// 当天登录次数
        /// </summary>
        public int DayCount { get; set; }
        /// <summary>
        /// 本周登录次数
        /// </summary>
        public int WeekCount { get; set; }
        /// <summary>
        /// 本月登录次数
        /// </summary>
        public int MonthCount { get; set; }
    }
}
