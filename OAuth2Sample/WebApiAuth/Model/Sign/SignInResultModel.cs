using ProjsctThis.Model.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuth.Model.Sign
{
    /// <summary>
    /// 사인인 성공시 전달할 모델
    /// </summary>
    public class SignInResultModel : ApiResultBaseModel
    {
        /// <summary>
        /// 엑세스 토큰
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 리플레시 토큰
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 테스트용 레벨
        /// </summary>
        public int Lv { get; set; }

        public SignInResultModel()
            : base()
        {
            this.access_token = string.Empty;
            this.refresh_token = string.Empty;

            this.Lv = 0;
        }
    }
}
