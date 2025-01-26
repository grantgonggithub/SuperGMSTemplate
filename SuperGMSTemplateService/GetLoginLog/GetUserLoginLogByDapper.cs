using Microsoft.AspNetCore.Mvc.RazorPages;

using SuperGMS.DB.EFEx.DynamicSearch;
using SuperGMS.DB.EFEx.DynamicSearch.Model;
using SuperGMS.DB.MapperEx;
using SuperGMS.Protocol.RpcProtocol;
using SuperGMS.Rpc.Server;

using SuperGMSTemplateDto.UserLoginLogDto;

using SuperGMSTemplateModel.supergms_user_db_models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGMSTemplateService.GetLoginLog
{
    internal class GetUserLoginLogByDapper : RpcBaseServer<SearchParameters, PageResult<GetUserLoginLogResult>>
    {
        protected override PageResult<GetUserLoginLogResult> Process(SearchParameters valueArgs, out StatusCode code)
        {
            var ctx = Context.GetDapperDbContext<supergms_userContext>();
            var rps = ctx.GetRepository();
            var logs = rps.QueryByPageSqlKey<UserLoginLog>("GetUserLoginLog", valueArgs);
            code = StatusCode.OK;
            return new PageResult<GetUserLoginLogResult>
            {
                ListValue = AutoMapperTool.Mapper.Map<List<GetUserLoginLogResult>>(logs),
                Page = valueArgs.PageInfo,
            };
        }

        protected override bool Check(SearchParameters args, out StatusCode code)
        {
            return base.CheckLogin(args, out code);
        }
    }
}

#region 测试Curl

/*
 curl --location 'http://localhost:20002/v2_api/SuperGMSTemplateService/GetUserLoginLogByDapper' \
--header 'Content-Type: application/json' \
--data '{
    "ct": "web",
    "cv": "2.0.1",
    "tk": "user:08cfc0e5c4414154aee4133a6307fe8a",
    "v": {
        "QueryModel": {
            "Items": [
                {
                    "Field": "UserId",
                    "Method": 0,
                    "Value": 1,
                    "Prefix":"llog"
                },
                {
                    "Field": "ClientType",
                    "Method": 12,
                    "Value": "w",
                    "Prefix":"llog"
                },
                {
                    "Field": "LoginTime",
                    "Method": 1,
                    "Value": "2025-2-1",
                    "Prefix":"llog"
                },
                {
                    "Field": "LoginTime",
                    "Method": 2,
                    "Value": "1990-1-1",
                    "Prefix":"llog"
                }
            ]
        },
        "PageInfo": {
            "CurrentPage": 1,
            "PageSize": 10,
            "SortField": "llog.CreatedDate",
            "SortDirection": "DESC",
            "IsGetTotalCount": true
        }
    }
}'
 */

#endregion

#region 返回结果

/*
{
    "rid": "e4d1d94453354ea29a4af7204f2963c3",
    "c": 200,
    "msg": "OK",
    "v": {
        "Page": {
            "CurrentPage": 1,
            "SkipCount": 0,
            "PageSize": 10,
            "SortField": "llog.CreatedDate",
            "SortDirection": "DESC",
            "IsPaging": false,
            "IsGetTotalCount": true,
            "TotalCount": 4
        },
        "ListValue": [
            {
                "Id": 3,
                "UserId": 1,
                "LoginTime": "2025-01-26 12:18:20",
                "LoginIp": "PostmanRuntime/7.43.0",
                "ClientType": "web",
                "ClientVersion": "2.0.1",
                "LoginDevice": "::ffff:192.168.7.220",
                "CreatedDate": "2025-01-26 12:18:20",
                "CreatedBy": "000000@qq.com",
                "RealName": "supergms",
                "Sex": 1,
                "Birthday": "2000-01-01 17:40:32",
                "Email": "000000@qq.com"
            },
            {
                "Id": 4,
                "UserId": 1,
                "LoginTime": "2025-01-26 12:18:20",
                "LoginIp": "PostmanRuntime/7.43.0",
                "ClientType": "web",
                "ClientVersion": "2.0.1",
                "LoginDevice": "::ffff:192.168.7.220",
                "CreatedDate": "2025-01-26 12:18:20",
                "CreatedBy": "000000@qq.com",
                "RealName": "supergms",
                "Sex": 1,
                "Birthday": "2000-01-01 17:40:32",
                "Email": "000000@qq.com"
            },
            {
                "Id": 2,
                "UserId": 1,
                "LoginTime": "2025-01-26 12:18:18",
                "LoginIp": "PostmanRuntime/7.43.0",
                "ClientType": "web",
                "ClientVersion": "2.0.1",
                "LoginDevice": "::ffff:192.168.7.220",
                "CreatedDate": "2025-01-26 12:18:18",
                "CreatedBy": "000000@qq.com",
                "RealName": "supergms",
                "Sex": 1,
                "Birthday": "2000-01-01 17:40:32",
                "Email": "000000@qq.com"
            },
            {
                "Id": 1,
                "UserId": 1,
                "LoginTime": "2025-01-26 12:18:12",
                "LoginIp": "PostmanRuntime/7.43.0",
                "ClientType": "web",
                "ClientVersion": "2.0.1",
                "LoginDevice": "::ffff:192.168.7.220",
                "CreatedDate": "2025-01-26 12:18:12",
                "CreatedBy": "000000@qq.com",
                "RealName": "supergms",
                "Sex": 1,
                "Birthday": "2000-01-01 17:40:32",
                "Email": "000000@qq.com"
            }
        ]
    },
    "icp": false
}
 */

#endregion