using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4_Custom.UserServices
{
    /// <summary>
    /// 1. 임의 유저 정보 모델
    /// </summary>
    public class CustomUser
    {
        public string SubjectId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
