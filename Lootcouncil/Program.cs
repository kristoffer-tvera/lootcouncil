using Lootcouncil.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lootcouncil.Logging;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Auth");
    options.Conventions.AuthorizeFolder("/Setup");
    options.Conventions.AuthorizeFolder("/Council");
});


builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.Configure<BlizzardSettings>(builder.Configuration.GetSection(BlizzardSettings.Section));
builder.Services.AddScoped<IApiRepository, ApiRepository>();
builder.Services.AddScoped<IDbRepository, DbRepository>();
builder.Services.AddHostedService<WebhookService>();
builder.Services.AddSingleton<WebhookRequestQueue>();
builder.Services.Configure<ForwardedHeadersOptions>(options => //Neccesary to run behind nginx proxy
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Cookie.Name = builder.Configuration["Cookie"];
    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true;
}).AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.Authority = builder.Configuration[$"{BlizzardSettings.Section}:Authority"];
    options.ClientId = builder.Configuration[$"{BlizzardSettings.Section}:ClientId"];
    options.ClientSecret = builder.Configuration[$"{BlizzardSettings.Section}:ClientSecret"];

    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.SaveTokens = true;
    options.UseTokenLifetime = true;
    options.NonceCookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
    options.NonceCookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
    options.NonceCookie.IsEssential = true;

    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("id_token");
    options.Scope.Add("wow.profile");
});

//builder.Services.Configure<BlizzardSettings>(Configuration.GetSection(BlizzardSettings.Section));

builder.Logging.AddDiscordLogger();

var app = builder.Build();
app.UseForwardedHeaders(); //Neccesary to run behind nginx proxy

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
