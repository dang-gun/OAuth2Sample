using ProjsctThis.Model.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPA_NetCore_Foundation.Model
{
    /// <summary>
    /// 테스트용 01
    /// </summary>
    public class TestModel01 : ApiResultBaseModel
    {
        public int nTest { get; set; }
        public string sTest { get; set; }

        public TestModel01() : base()
        {
            this.nTest = 0;
            this.sTest = string.Empty;
        }
    }

    /// <summary>
    /// 테스트용 02
    /// </summary>
    public class TestModel02 : ApiResultBaseModel
    {
        public int nTest001 { get; set; }
        public string sTest002 { get; set; }

        public TestModel02() : base()
        {
            this.nTest001 = 0;
            this.sTest002 = string.Empty;
        }
    }
}
