using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using BlazorApp1.Components;
using BlazorApp1.Components.Account;
using BlazorApp1.Data;
using BlazorApp1.Helper;
using BlazorApp1.Settings;
using EltafawkPlatform.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Load Mongo settings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

var mongoSettings = builder.Configuration
    .GetSection("MongoDbSettings")
    .Get<MongoDbSettings>();

// Register MongoDB Identity provider
builder.Services.AddIdentityMongoDbProvider<ApplicationUser, MongoRole>(identityOptions =>
{
    identityOptions.Password.RequiredLength = 6;
    identityOptions.Password.RequireDigit = false;
    identityOptions.Password.RequireUppercase = false;
}, mongoOptions =>
{
    mongoOptions.UsersCollection = "Users";
    mongoOptions.RolesCollection = "Roles";
    mongoOptions.ConnectionString = mongoSettings.ConnectionString;
});
// Register MongoClient
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    return new MongoClient(mongoSettings.ConnectionString);
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoSettings.DatabaseName);
});

// Access environment
var env = builder.Environment;

var baseUrl = env.IsDevelopment()
    ? "https://localhost:44337"
    : "https://eltafawk-production.up.railway.app";

builder.Services.AddHttpClient("ServerAPI", client =>
{
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<InboxService>();
builder.Services.AddScoped<SubscribePackageService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddControllers();
var app = builder.Build();
//Fresh database calls
RoleProvider.CreateDefaultRoles(app);
// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
// Identity endpoints
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();
