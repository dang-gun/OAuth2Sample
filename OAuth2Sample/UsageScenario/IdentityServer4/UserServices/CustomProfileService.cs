using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4_Custom.UserServices
{
    /// <summary>
    /// 4. 'IdentityServerBuilder'에 전달될 프로필 서비스를 만든다.
    /// 유효성 검증이 된경우 토큰에 정보나 요구사항을 추가한다.
    /// </summary>
    public class CustomProfileService : IProfileService
    {
        /// <summary>
        /// 로거
        /// </summary>
        protected readonly ILogger Logger;

        /// <summary>
        /// 전달받은 유저 저장소
        /// </summary>
        protected readonly IUserRepository _userRepository;

        public CustomProfileService(IUserRepository userRepository, ILogger<CustomProfileService> logger)
        {
            _userRepository = userRepository;
            Logger = logger;
        }

        /// <summary>
        /// 서브젝트아이디에 해당하는 정보를 만든다.
        /// 주의 : 직접 참조만 없을뿐이지 실제론 사용된다.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();

            Logger.LogDebug("Get profile called for subject {subject} from client {client} with claim types {claimTypes} via {caller}",
                context.Subject.GetSubjectId(),
                context.Client.ClientName ?? context.Client.ClientId,
                context.RequestedClaimTypes,
                context.Caller);

            var user = _userRepository.FindBySubjectId(context.Subject.GetSubjectId());

            var claims = new List<Claim>
            {
                new Claim("role", "dataEventRecords.admin"),
                new Claim("role", "dataEventRecords.user"),
                new Claim("username", user.UserName),
                new Claim("email", user.Email)
            };

            context.IssuedClaims = claims;
        }

        /// <summary>
        /// 전달받은 서브젝트아이디가 있는지 확인한다.
        /// 주의 : 직접 참조만 없을뿐이지 실제론 사용된다.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = _userRepository.FindBySubjectId(context.Subject.GetSubjectId());
            //여기서 인증성공여부를 판단해서 메시지를 보낼 수 있을듯 한데...
            //인증관련 내용만 처리 가능
            //context.Subject.Claims
            context.IsActive = user != null;
        }
    }
}
