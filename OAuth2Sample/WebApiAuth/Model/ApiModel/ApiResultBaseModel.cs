using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjsctThis.Model.ApiModel
{
    /// <summary>
    /// API 결과 공통 베이스.
    /// 자바스크립트에도 전달해야 하므로 소문자로 시작한다.
    /// </summary>
    public class ApiResultBaseModel
    {
        /// <summary>
        /// 실패시 전달한 코드
        /// 0 : 성공.
        /// 다른 값은 모두 실패
        /// </summary>
        public string infoCode { get; set; }
        /// <summary>
        /// 전달할 메시지
        /// </summary>
        public string message { get; set; }

        public ApiResultBaseModel()
        {
            this.infoCode = "0";
            this.message = string.Empty;
        }

        public ApiResultBaseModel(string sInfoCode, string sMessage)
        {
            this.infoCode = sInfoCode;
            this.message = sMessage;
        }
    }
}
