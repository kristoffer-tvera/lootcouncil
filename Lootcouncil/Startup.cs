using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;

namespace Lootcouncil
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.Configure<BlizzardSettings>(Configuration.GetSection(BlizzardSettings.Section));
            services.AddTransient<IApiRepository, ApiRepository>();
            
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.Name = Configuration["Cookie"];
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                })
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = Configuration[$"{BlizzardSettings.Section}:Authority"];

                    options.ClientId = Configuration[$"{BlizzardSettings.Section}:ClientId"];
                    options.ClientSecret = Configuration[$"{BlizzardSettings.Section}:ClientSecret"];
                    
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;

                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("id_token");
                    options.Scope.Add("wow.profile");

                    //options.Events = new OpenIdConnectEvents
                    //{
                    //    OnTokenValidated = async ctx =>
                    //    {
                    //        foreach(var claim in ctx.Principal.Claims)
                    //        {
                    //            Console.WriteLine($"Claim name:{claim.Type} , claim value:{claim.Value}");
                    //        }
                    //    }
                    //};
                });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            IdentityModelEventSource.ShowPII = true;
        }
    }
}
