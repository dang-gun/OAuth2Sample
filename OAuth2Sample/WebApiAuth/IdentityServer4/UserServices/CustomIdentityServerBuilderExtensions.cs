using IdentityServer4_Custom.UserServices;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 6. 'Microsoft.Extensions.DependencyInjection'에 확장 메소드 추가
    /// 'IdentityServerBuilder'에 추가할 종속성을 정의 한다.
    /// </summary>
    public static class CustomIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
        {
            //사용자 데이터 접근
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            //토큰에 필요함 클레임 추가
            builder.AddProfileService<CustomProfileService>();
            //사용자 자격 증명 유효성 검사
            builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}
