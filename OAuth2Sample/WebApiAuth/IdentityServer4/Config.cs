using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4_Custom.IdentityServer4
{
    /// <summary>
    /// 0. 'IdentityServer4' 설정
    /// </summary>
    public class Config
    {
        /// <summary>
        /// API의 인증 범위를 정의한다.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("dataEventRecords")
                {
                    ApiSecrets = { new Secret("dataEventRecordsSecret".Sha256()) }
                    , Scopes =
                    {
                        new Scope
                        {
                            Name = "dataeventrecordsscope",
                            DisplayName = "Scope for the dataEventRecords ApiResource"
                        }
                    }
                    , UserClaims = 
                    { 
                        "role"
                        , "admin"
                        , "user"
                        , "dataEventRecords"
                        , "dataEventRecords.admin"
                        , "dataEventRecords.user" 
                    }
                }//end new ApiResource
            };//end return
        }

        /// <summary>
        /// 클라이언트 접근 범위를 설정한다.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "resourceownerclient",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials
                    , AccessTokenType = AccessTokenType.Jwt
                    , AccessTokenLifetime = 60
                    , IdentityTokenLifetime = 3600
                    , UpdateAccessTokenClaimsOnRefresh = true
                    , SlidingRefreshTokenLifetime = 30
                    , AllowOfflineAccess = true
                    , RefreshTokenExpiration = TokenExpiration.Absolute
                    , RefreshTokenUsage = TokenUsage.OneTimeOnly
                    , AlwaysSendClientClaims = true
                    , Enabled = true
                    , ClientSecrets =  new List<Secret> { new Secret("dataEventRecordsSecret".Sha256()) }
                    , AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OfflineAccess
                        , "dataEventRecords"
                    }
                }//end new Client
            };//end return
        }


    }//end class Config
}
