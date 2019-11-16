using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4_Custom.UserServices
{
    /// <summary>
    /// 3. 유저 저장소
    /// 유저 정보 및 데이터 엑세스 기능
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 테스트용 더미 데이터
        /// </summary>
        private readonly List<CustomUser> _users = new List<CustomUser>
        {
            new CustomUser{
                SubjectId = "123",
                UserName = "damienbod",
                Password = "damienbod",
                Email = "damienbod@email.ch"
            },
            new CustomUser{
                SubjectId = "124",
                UserName = "raphael",
                Password = "raphael",
                Email = "raphael@email.ch"
            },
        };

        /// <summary>
        /// 인증정보가 확인
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateCredentials(string username, string password)
        {
            var user = FindByUsername(username);
            if (user != null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }

        /// <summary>
        /// 아이디 검색
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public CustomUser FindBySubjectId(string subjectId)
        {
            return _users.FirstOrDefault(x => x.SubjectId == subjectId);
        }

        /// <summary>
        /// 이름 검색
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public CustomUser FindByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
