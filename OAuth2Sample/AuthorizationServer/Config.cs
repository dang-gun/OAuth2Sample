using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthorizationServer
{
    public class Config
    {
        // scopes define the API resources in your system
        //API의 인증 범위를 정의한다.
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("scope.readaccess", "Example API"),
                new ApiResource("scope.fullaccess", "Example API"),
                new ApiResource("YouCanActuallyDefineTheScopesAsYouLike", "Example API")
            };
        }

        // client wants to access resources (aka scopes)
        //클라이언트 접근 범위를 설정한다.
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ClientIdThatCanOnlyRead"
                    , AllowedGrantTypes = GrantTypes.ClientCredentials

                    , ClientSecrets = { new Secret("secret1".Sha256())}
                    , AllowedScopes = { "scope.readaccess" }
                }
                , new Client
                {
                    ClientId = "ClientIdWithFullAccess"
                    , AllowedGrantTypes = GrantTypes.ClientCredentials

                    , ClientSecrets = { new Secret("secret2".Sha256()) }
                    , AllowedScopes = { "scope.fullaccess" }
                }
            };
        }

    }
}
