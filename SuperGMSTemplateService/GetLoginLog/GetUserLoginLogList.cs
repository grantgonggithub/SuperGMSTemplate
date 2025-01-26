using SuperGMS.DB.EFEx.DynamicSearch;
using SuperGMS.DB.EFEx.DynamicSearch.Model;
using SuperGMS.DB.MapperEx;
using SuperGMS.Protocol.RpcProtocol;
using SuperGMS.Rpc.Server;

using SuperGMSTemplateDto.UserLoginLogDto;

using SuperGMSTemplateModel.supergms_user_db_models;

namespace SuperGMSTemplateService.GetLoginLog
{
    internal class GetUserLoginLogList : RpcBaseServer<SearchParameters, PageResult<GetUserLoginLogResult>>
    {
        protected override PageResult<GetUserLoginLogResult> Process(SearchParameters valueArgs, out StatusCode code)
        {
            var ctx = Context.GetDbContext<supergms_userContext>();
            var rps = ctx.GetRepository<UserLoginLog>();
            var logs = rps.GetByPage(valueArgs);
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

#region 测试curl

/*
curl --location 'http://localhost:20002/v2_api/SuperGMSTemplateService/GetUserInfoList' \
--header 'Content-Type: application/json' \
--data '{
    "ct": "web",
    "cv": "2.0.1",
    "tk": "user:08cfc0e5c4414154aee4133a6307fe8a",
    "v": {
        "QueryModel": {
            "Items": [
                {
                    "Field": "RealName",
                    "Method": 12,
                    "Value": "super"
                },
                {
                    "Field": "Sex",
                    "Method": 0,
                    "Value": 1
                },
                {
                    "Field": "Birthday",
                    "Method": 1,
                    "Value": "2020-1-1"
                },
                {
                    "Field": "Birthday",
                    "Method": 2,
                    "Value": "1990-1-1"
                }
            ]
        },
        "PageInfo": {
            "CurrentPage": 1,
            "PageSize": 10,
            "SortField": "UpdatedDate",
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
    "rid": "42f20eaaa12c42dbbc10f6ae1b83d212",
    "c": 200,
    "msg": "OK",
    "v": {
        "Page": {
            "CurrentPage": 1,
            "SkipCount": 0,
            "PageSize": 10,
            "SortField": "UpdatedDate",
            "SortDirection": "DESC",
            "IsPaging": false,
            "IsGetTotalCount": true,
            "TotalCount": 1
        },
        "ListValue": [
            {
                "UserId": 1,
                "RealName": "supergms",
                "Sex": 1,
                "Birthday": "2000-01-01 17:40:32",
                "Remark": "备注",
                "Status": 1,
                "CreatedDate": "2025-01-26 09:35:05",
                "UpdatedDate": "2025-01-26 09:35:10",
                "CreatedBy": "systemm",
                "UpdatedBy": "systemm"
            }
        ]
    },
    "icp": false
}
 */

#endregion
