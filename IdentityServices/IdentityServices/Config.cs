using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServices
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "google",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
               // AllowedGrantTypes = GrantTypes.List("googleAuth"),
                AllowedGrantTypes =
                        {
                            GrantType.Hybrid,
                            GrantType.ClientCredentials,
                            "googleAuth"
                        },
            AllowedScopes =
                {
                   "offline_access",
                    "api1"
                }
            },
            new Client
            {
                ClientId = "client",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                AllowedScopes =
                {
                    "offline_access",
                    "api1"
                }
            }
        };
        }


        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "vivek",
                    Password = "password"
                }

            };
        }

    }
}
