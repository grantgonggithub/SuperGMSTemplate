using AutoMapper;

using SuperGMS.DB.MapperEx;

using SuperGMSTemplateDto.UserInfoDto;
using SuperGMSTemplateDto.UserLoginLogDto;

using SuperGMSTemplateModel.supergms_user_db_models;

namespace SuperGMSTemplateService.AppStart
{
    /// <summary>
    /// 注册对象映射
    /// <see cref="AutoMapperProfile" langword="" />
    /// </summary>
    public class AutoMapperProfile: Profile
    {
        // 注册对象映射
        public AutoMapperProfile()
        {
            this.CreateMap<UserLoginLog, GetUserLoginLogResult>();
            this.CreateMap<Userinfo,GetUserInfoResult>();
        }
    }


    public static class AutoMapperRegister
    {
        /// <summary>
        /// 初始化AutoMapper
        /// </summary>
        public static void Initlize()
        {
            AutoMapperTool.Initlize(new AutoMapperProfile());
        }
    }
}
