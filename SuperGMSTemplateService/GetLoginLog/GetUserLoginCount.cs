using SuperGMS.Protocol.RpcProtocol;
using SuperGMS.Rpc.Server;

using SuperGMSTemplateDto.UserLoginLogCountDto;

using SuperGMSTemplateModel.supergms_user_db_models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGMSTemplateService.GetLoginLog
{
    internal class GetUserLoginCount : RpcBaseServer<GetUserLoginLogCountArgs, GetUserLoginLogCountResult>
    {
        protected override GetUserLoginLogCountResult Process(GetUserLoginLogCountArgs valueArgs, out StatusCode code)
        {
            var ctx = Context.GetDapperDbContext<supergms_userContext>();
            var rps = ctx.GetRepository();
            var time = DateTime.Now;

            var dayCount = rps.ExecuteScalarSqlKey<int>("GetUserLoginCount", new[] { "start", "end" }, new[] { time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd 23:59:59") }, System.Data.CommandType.Text);
            var weekIndex = time.DayOfWeek;
            var start = time.AddDays(-1 * (int)weekIndex);
            var weekCount = rps.ExecuteScalarSqlKey<int>("GetUserLoginCount", new[] { "start", "end" }, new object[] { start.ToString("yyyy-MM-dd"), start.AddDays(6).ToString("yyyy-MM-dd 23:59:59") }, System.Data.CommandType.Text);
            var monthIndex = time.Month;
            start = new DateTime(time.Year, time.Month, 1);
            var end = new DateTime(time.Year, time.Month, DateTime.DaysInMonth(time.Year, time.Month));
            var monthCount = rps.ExecuteScalarSqlKey<int>("GetUserLoginCount", new[] { "start", "end" }, new object[] { start, end }, System.Data.CommandType.Text);
            code = StatusCode.OK;
            return new GetUserLoginLogCountResult { DayCount = dayCount, WeekCount = weekCount, MonthCount = monthCount };
        }

        protected override bool Check(GetUserLoginLogCountArgs args, out StatusCode code)
        {
            return base.CheckLogin(args, out code);
        }
    }
}

#region 测试Curl

/*
curl --location 'http://localhost:20002/v2_api/SuperGMSTemplateService/GetUserLoginCount' \
--header 'Content-Type: application/json' \
--data '{
    "ct":"web",
    "cv":"2.0.1",
    "tk":"user:08cfc0e5c4414154aee4133a6307fe8a",
    "v":{
        "UserId": 1
    }
}'
 */

#endregion

#region 返回结果

/*
{
    "rid": "281abeb5161f48baae1ffc5742572f83",
    "c": 200,
    "msg": "OK",
    "v": {
        "DayCount": 4,
        "WeekCount": 4,
        "MonthCount": 4
    },
    "icp": false
}
*/

#endregion
