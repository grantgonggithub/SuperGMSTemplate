using SuperGMS.Cache;
using SuperGMS.Protocol.RpcProtocol;
using SuperGMS.Rpc.Server;

using SuperGMSTemplateDto.UserLoginDto;

using SuperGMSTemplateModel.supergms_user_db_models;

namespace SuperGMSTemplateService.LoginApi
{
    internal class Login : RpcBaseServer<UserLoginArgs, UserLoginResult>
    {
        protected override UserLoginResult? Process(UserLoginArgs valueArgs, out StatusCode code)
        {
            // 获取要操作的数据库的DBContext
            var ctx = Context.GetDbContext<supergms_userContext>();
            // 获取要操作的表的repository
            var repository = ctx.GetRepository<Userlogin>();
            // 做Linq查询
            var userInfo = repository.GetByQuery(u=>u.Email==valueArgs.UserName).FirstOrDefault();
            if (userInfo==null)
            {
                code = StatusCode.GetCode(10000, "登录用户不存在！");
                return null;
            }
            //这里为了演示功能，直接比的明文，实际业务中应该存储和比较的是MD5值或者其他形式的密文
            if (userInfo.LoginPassWord != valueArgs.Password) {
                code = StatusCode.GetCode(10001, "密码错误");
                return null;
            }
            code = StatusCode.OK;
            //获取http的头信息
            args.Headers.TryGetValue(SuperGMS.Protocol.RpcProtocol.HeaderValue.REMOTEIP, out var remoteIp);
            //获取http的头信息
            args.Headers.TryGetValue(SuperGMS.Protocol.RpcProtocol.HeaderValue.USERAGENT, out var userAgent);

            var userContext = new SuperGMS.UserSession.UserContext { 
                ClientType=args.ct,
                ClientVersion=args.cv,
                Token=$"user:{Guid.NewGuid():N}",
                UserInfo=new SuperGMS.UserSession.UserInfo
                {
                    LoginName = userInfo.Email,
                    UserId = userInfo.UserId,
                    // 这个对象是预留的，具体业务可以根据需要自定义对象做登录缓存，设置保存后，在其他的接口上下文即可获取到
                    UserInfoObjCtx =new UserLoginContextInfo
                    {
                        LoginTime = DateTime.Now,
                        ClientType = args.ct,
                        ClientVersion = args.cv,
                        LoginIp = remoteIp?.Value?.ToString(),
                        DeviceInfo=userAgent?.Value?.ToString(),
                    }
                },
            };
            //保存登录Session到Redis中，过期时间为8小时
            // 框架还提供了另外一个ResourceCache 主要的目的是想Redis独立分实例，一般非特殊情况用不到
            DefaultCache.Instance.Set(userContext.Token,userContext,TimeSpan.FromHours(8));

            var rps = ctx.GetRepository<LoginLog>();
            var loginLog = new LoginLog
            {
                ClientType = args.ct,
                ClientVersion = args.cv,
                LoginDevice = remoteIp?.Value?.ToString(),
                LoginIp = userAgent?.Value?.ToString(),
                LoginTime = DateTime.Now,
                UserId=userInfo.UserId,
                CreatedDate = DateTime.Now,
                CreatedBy=userInfo.Email
            };
            rps.Insert(loginLog);
            ctx.Commit();
            //将这个Token返回给前端，每次访问需要携带这个
            return new UserLoginResult { UserId = userInfo.UserId, Token=userContext.Token };
        }


        protected override bool Check(UserLoginArgs args, out StatusCode code)
        {
            // 因为登录接口不能验证登录和权限，所以这里直接不检查
            code = StatusCode.OK;
            return true;
        }
    }
}

#region 接口测试调用方式

/* 测试调用的curl,可以import到postMan中测试
 * 
        curl --location 'http://localhost:20002/v2_api/SuperGMSTemplateService/login' \
        --header 'Content-Type: application/json' \
        --data-raw '{
            "ct":"web",
            "cv":"2.0.1",
            "v":{
                "UserName":"000000@qq.com",
                "Password":"123456"
            }
        }'
 *
 */

#endregion

#region 返回结果
/*
         {
        "rid": "4e307597bd5744a0b26d872726b506ec",
        "c": 200,
        "msg": "OK",
        "v": {
            "UserId": 1,
            "Token": "user:08cfc0e5c4414154aee4133a6307fe8a" // 这里返回的Token会在后面验证登录的接口中作为tk参数值携带提交
        },
        "icp": false
    }
 */

#endregion

