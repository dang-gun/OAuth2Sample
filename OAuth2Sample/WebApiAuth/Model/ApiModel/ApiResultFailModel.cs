using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjsctThis.Model.ApiModel
{
    /// <summary>
    /// api 실패시 전달할 모델(자바스크립 전달용)
    /// </summary>
    public class ApiResultFailModel: ApiResultBaseModel
    {
        public ApiResultFailModel()
            : base()
        {
            
        }

        public ApiResultFailModel(string sInfoCode, string sMessage)
            :base(sInfoCode, sMessage)
        {
        }
    }
}
