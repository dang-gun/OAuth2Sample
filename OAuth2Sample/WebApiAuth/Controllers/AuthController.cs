using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjsctThis.Model.ApiModel;
using WebApiAuth.Model.Sign;

namespace WebApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// 인증에 사용할  http클라이언트
        /// </summary>
        private HttpClient hcAuthClient = new HttpClient();
        /// <summary>
        /// IdentityServer4로 구현된 서버 주소
        /// </summary>
        private string sIdentityServer4_Url = "https://localhost:44343/";

        [HttpPost]
        [Route("SignIn")]
        public ActionResult<SignInResultModel> SignIn(
            [FromForm]string sID
            , [FromForm]string sPW)
        {
            //결과용
            ApiResultReadyModel armResult = new ApiResultReadyModel(this);
            //로그인 처리용 모델
            SignInResultModel smResult = new SignInResultModel();


            //토큰 요청
            TokenResponse tr = RequestTokenAsync(sID, sPW).Result;

            if(true == tr.IsError)
            {//에러가 있다.
                armResult.infoCode = "1";
                armResult.message = "아이디나 비밀번호가 틀렸습니다.";

                armResult.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {//에러가 없다.
                smResult.access_token = tr.AccessToken;
                smResult.refresh_token = tr.RefreshToken;
            }

            return armResult.ToResult(smResult);
        }

        [HttpPost]
        [Route("SignOut")]
        public ActionResult<SignInResultModel> SignOut(
            [FromForm]string sRefreshToken)
        {
            ApiResultReadyModel armResult = new ApiResultReadyModel(this);
            ApiResultBaseModel arbm = new ApiResultBaseModel();

            //사인아웃에 필요한 작업을 한다.


            //임시로 아이디를 넘긴다.
            return armResult.ToResult(arbm);
        }


        [HttpPost]
        [Route("RefreshToAccess")]
        public ActionResult<SignInResultModel> RefreshToAccess(
            [FromForm]string sRefreshToken)
        {
            //결과용
            ApiResultReadyModel armResult = new ApiResultReadyModel(this);
            //엑세스 토큰 갱신용 모델
            RefreshToAccessModel smResult = new RefreshToAccessModel();

            //토큰 갱신 요청
            TokenResponse tr = RefreshTokenAsync(sRefreshToken).Result;

            if (true == tr.IsError)
            {//에러가 있다.
                armResult.infoCode = "1";
                armResult.message = "토큰 갱신에 실패하였습니다.";

                armResult.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {//에러가 없다.
                smResult.access_token = tr.AccessToken;
                smResult.refresh_token = tr.RefreshToken;
            }

            return armResult.ToResult(smResult);
        }



        /// <summary>
        /// 인증서버에 인증을 요청한다.
        /// </summary>
        /// <param name="sID"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        private async Task<TokenResponse> RequestTokenAsync(string sID, string sPassword)
        {
            TokenResponse trRequestToken 
                = await hcAuthClient
                        .RequestPasswordTokenAsync(new PasswordTokenRequest
                        {
                            Address = this.sIdentityServer4_Url + "connect/token",

                            ClientId = "resourceownerclient",
                            ClientSecret = "dataEventRecordsSecret",
                            Scope = "dataEventRecords offline_access",

                            //유저 인증정보 : 아이디
                            UserName = sID,
                            //유저 인증정보 : 비밀번호
                            Password = sPassword
                        });

            return trRequestToken;
        }

        /// <summary>
        /// 액세스 토큰 갱신
        /// </summary>
        /// <param name="sRefreshToken">리플레시토큰</param>
        /// <returns></returns>
        private async Task<TokenResponse> RefreshTokenAsync(string sRefreshToken)
        {
            TokenResponse trRequestToken
                = await hcAuthClient
                        .RequestRefreshTokenAsync(new RefreshTokenRequest
                        {
                            Address = this.sIdentityServer4_Url + "connect/token",

                            ClientId = "resourceownerclient",
                            ClientSecret = "dataEventRecordsSecret",
                            Scope = "dataEventRecords offline_access",

                            RefreshToken = sRefreshToken
                        });

            return trRequestToken;
        }

    }
}