using ProjsctThis.Model.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuth.Model.Sign
{
    public class RefreshToAccessModel : ApiResultBaseModel
    {
        /// <summary>
        /// 엑세스 토큰
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 리플레시 토큰
        /// </summary>
        public string refresh_token { get; set; }

        public RefreshToAccessModel()
            : base()
        {
            this.access_token = string.Empty;
            this.refresh_token = string.Empty;
        }
    }
}
