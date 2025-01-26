using SuperGMS.Config;
using SuperGMS.DB.EFEx.DynamicSearch;
using SuperGMS.Extend.BackGroundMessage;
using SuperGMS.Extend.MQ;
using SuperGMS.Rpc.Server;

using SuperGMSTemplateModel.supergms_user_db_models;

using SuperGMSTemplateService.GetLoginLog;

namespace SuperGMSTemplateService.AppStart
{
    /// <summary>
    /// 引用程序初始化入口
    /// <see cref="AppInitlize" langword="" />
    /// </summary>
    [InitlizeMethod]
    public class AppInitlize
    {
        [InitlizeMethod]
        public static void Start()
        {
            // 初始化AutoMapper
            AutoMapperRegister.Initlize();
           
            DbColumnMaps.InitDbContextFiledMaps<supergms_userContext>();

            //初始化MQ点对点消息队列
            // 接口可以使用一步消息的方式
            SuperDirectMessageHelper.Initlize(new[]
            {
                new MessageRouterMap
                {
                    BussinessApi = typeof(GetUserLoginCount), // 统计数据
                    MQRouterName = $"{ServerSetting.AppName}_{nameof(GetUserLoginCount)}"
                }
            });
        }
    }
}
