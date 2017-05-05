using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer.Demo
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>{
                new ApiResource("CustomerProfileAPI", "Profile Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>{
                new Client{
                    ClientId = "host",
                    ClientName = "Host MVC Client",

                    // no interactive user, use the clientid/secret for authentication
		            AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

		            // secret for authentication
		            ClientSecrets =
                    {
                        new Secret("7a72a254-c5bf-4db8-885a-85da7f30cf4f".Sha256())
                    },

                    RedirectUris = { "http://localhost:7635/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:7635/signout-callback-oidc" },

		            // scopes that client has access to
		            AllowedScopes =
		            {
		                IdentityServerConstants.StandardScopes.OpenId,
		                IdentityServerConstants.StandardScopes.Profile,
                        "CustomerProfileAPI"
                    }
                },
                new Client{
                    ClientId = "vendor",
                    ClientName = "3rd Party MVC Vendor Client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("cd546589-c550-4129-9bfa-90c8a54e879a".Sha256())
                    },

                    RedirectUris = { "http://localhost:7638/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:7638/signout-callback-oidc" },

                    // scopes that client has access to
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CustomerProfileAPI"
                    }
                }

            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>{
                new TestUser(){
                    SubjectId = "1",
                    Username = "john",
                    Password = "Snafu201"
                },
                new TestUser(){
                    SubjectId = "2",
                    Username = "Mike",
                    Password = "Secrete1"
                }
            };
        }
    }
}
