using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Microsoft.Graph.Auth;

namespace az204_authdemo
{
    class Program
    {
        private const string _clientId = "737acd05-7144-4e50-a6c0-b072c0d6cc22";
        private const string _tenantId = "c4ca661c-1b3a-4db3-aae9-ff0d88b910fd";
        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri("http://localhost")
                .Build();

            // AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
            // Console.WriteLine($"Token:\t{result.AccessToken}");

            string[] scopes = { "user.read" };
            var provider = new InteractiveAuthenticationProvider(app, scopes);
            var client = new GraphServiceClient(provider);
            User me = await client.Me.Request().GetAsync();
            Console.WriteLine($"Display Name:\t{me.DisplayName} and Age Group:\t{me.AgeGroup}");
        }
    }
}
