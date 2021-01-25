using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace SpaWebPortofolio
{
    public static class IdentityConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(), 
                new IdentityResources.Profile(), 
                new IdentityResource("Role", 
                    userClaims: new []{ "Role" }, 
                    displayName: "role"),
            };
        }
        
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            
            return new List<ApiScope>
            {
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName, new[]
                {
                    JwtClaimTypes.PreferredUserName,
                    "Role",
                })
            };
        }
        
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "SpaPortofolioWebClient",
                    AllowedGrantTypes = GrantTypes.Code,
                    
                    RedirectUris = new[]
                    {
                        $"{Startup.StaticConfig["SpaBaseUrl"]}/oidc-callback",
                        $"{Startup.StaticConfig["SpaBaseUrl"]}/oidc-client-silent-renew.html",
                    },
                    PostLogoutRedirectUris = new[]
                    {
                        Startup.StaticConfig["SpaBaseUrl"],
                    },
                    
                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "Role",
                    },

                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = false,
                    RequireClientSecret = false,
                }
            };
        }
    }
}