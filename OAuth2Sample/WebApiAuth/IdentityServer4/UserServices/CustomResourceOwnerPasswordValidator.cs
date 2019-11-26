using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4_Custom.UserServices
{
    /// <summary>
    /// 5. 전달된 유저정보 유효성 검사
    /// </summary>
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository _userRepository;

        public CustomResourceOwnerPasswordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_userRepository.ValidateCredentials(context.UserName, context.Password))
            {//일치하는 유저 정보가 있다.

                //유저 정보 불러오기
                var user = _userRepository.FindByUsername(context.UserName);

                //권한 부여 유형을 지정한다.
                context.Result 
                    = new GrantValidationResult(user.SubjectId
                        , OidcConstants.AuthenticationMethods.Password);
            }
            else
            {//실패

                //실패 코드 작성
                Dictionary<string, object> dictError = new Dictionary<string, object>();
                dictError.Add("errorCode", "1");
                
                //실패 메시지 전달
                context.Result
                    = new GrantValidationResult(TokenRequestErrors.InvalidGrant
                        , "invalid credential"
                        , dictError);
            }

            

            return Task.FromResult(0);
        }
    }
}
