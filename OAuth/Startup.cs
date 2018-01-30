using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using UserPortalWebApi.Providers;

[assembly: OwinStartup(typeof(UserPortalWebApi.OAuth.Startup))]
namespace UserPortalWebApi.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();

            ConfigureOAuth(appBuilder);

            WebApiConfig.Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }

        private void ConfigureOAuth(IAppBuilder appBuilder)
        {
            OAuthAuthorizationServerOptions oAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                Provider = new TokenAuthorizationProvider()

            };

            appBuilder.UseOAuthAuthorizationServer(oAuthorizationServerOptions);

            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}