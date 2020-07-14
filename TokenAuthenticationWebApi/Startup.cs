using System;
using Microsoft.Owin;
using Owin;
//using TokenAuthenticationInWebAPI.Models;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using TokenAuthenticationWebApi.Data;
using TokenAuthenticationWebApi;

[assembly: OwinStartup(typeof(TokenAuthenticationInWebAPI.App_Start.Startup))]

namespace TokenAuthenticationInWebAPI.App_Start
{
    //OAuth Authorization Server.
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable CORS 
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                //generating the Toekn
                TokenEndpointPath = new PathString("/token"),

                //Setting the Token Expired Time (24 hours)
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                //MyAuthorizationServerProvider class will validate the user credentials this is hardcoded :p 
                Provider = new MyAuthorizationServerProvider()
            };

            //Token Generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}