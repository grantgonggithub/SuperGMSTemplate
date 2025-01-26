using SuperGMS.DB.MapperEx;
using SuperGMS.Protocol.RpcProtocol;
using SuperGMS.Rpc.Server;

using SuperGMSTemplateDto.UserInfoDto;

using SuperGMSTemplateModel.supergms_user_db_models;

namespace SuperGMSTemplateService.GetUserInfoApi
{
    internal class GetUserInfoById : RpcBaseServer<GetUserInfoArgs, GetUserInfoResult>
    {
        protected override GetUserInfoResult Process(GetUserInfoArgs valueArgs, out StatusCode code)
        {
            var ctx = Context.GetDbContext<supergms_userContext>();
            var rps = ctx.GetRepository<Userinfo>();
            // 后面false参数表示不跟踪，只查询结果，不做UD操作就不跟踪，否则默认是true，不用这个参数
            var userInfo = rps.GetQueryableByQuery(u => u.UserId == valueArgs.UserId, false).FirstOrDefault(); // 或者用 var userInfo=rps.GetByID(valueArgs.UserId);但是查询参数必须是主键
            code = StatusCode.OK;
            return AutoMapperTool.Mapper.Map<GetUserInfoResult>(userInfo);
        }

        protected override bool Check(GetUserInfoArgs args, out StatusCode code)
        {
            return base.CheckLogin(args, out code); // 只验证登录，根据前端传的tk来取redis的session

           // return base.CheckRights(args, out code);// 验证登录同时验证权限,如果不写这个override bool Check默认是最严格的验证权限
        }
    }
}

#region 测试curl

/*
   curl --location 'http://localhost:20002/v2_api/SuperGMSTemplateService/GetUserInfoById' \
    --header 'Content-Type: application/json' \
    --data '{
        "ct":"web",
        "cv":"2.0.1",
        "tk":"user:08cfc0e5c4414154aee4133a6307fe8a", // login页面返回的Token
        "v":{
            "UserId": 1
        }
    }'
 */

#endregion

#region 返回结果
/*
     {
       "rid": "228311c258804dc7ac83602fceec3951",
       "c": 200,
       "msg": "OK",
       "v": {
           "UserId": 1,
           "RealName": "supergms",
           "Sex": 1,
           "Birthday": "2025-01-01 17:40:32",
           "Remark": "备注",
           "Status": 1,
           "CreatedDate": "2025-01-25 17:40:44",
           "UpdatedDate": "2025-01-25 17:40:46",
           "CreatedBy": "systemm",
           "UpdatedBy": "systemm"
       },
       "icp": false
    }
 */
#endregion

