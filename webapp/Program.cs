using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DotNetEnv;

/*
 * Colors
 * #082640 downriver
 * #11593F eden
 * #29F247 malachite 
 * #21A635 forest green
 * #F2F2F2 concrete
 */

DotNetEnv.Env.Load();
DotNetEnv.Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
  .AddJsonFile("appsettings.json", false)
  .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName.ToLower()}.json", true);

//builder.Services.AddHttpClient<IFraudDetectionService, IPQSFraudDetectionService>

builder.Services.AddRazorPages(options =>
{
  options.RootDirectory = "/Pages";
});

// Configure
builder.Services.Configure<RouteOptions>(options =>
{
  options.LowercaseUrls = true;
  options.LowercaseQueryStrings = true;
  options.AppendTrailingSlash = true;
});

/*
builder.Services.Configure<StripeOptions>(options =>
{
  options.PublishableKey = builder.Configuration["STRIPE_PUBLISHABLE_KEY"];
  options.SecretKey = builder.Configuration["STRIPE_SECRET_KEY"];
  options.WebhookSecret = builder.Configuration["STRIPE_WEBHOOK_SECRET"];
  options.Domain = builder.Configuration["DOMAIN"];
});
*/

builder.Services.AddDbContext<AppDbContext>(options =>
{
  string? connectionString;
  if(builder.Environment.IsDevelopment())
  {
    connectionString = builder.Configuration.GetConnectionString("Dev");
    options.UseSqlite(connectionString, x => x.MigrationsAssembly("webapp.migrations"));
  }
  else
  {
    connectionString = builder.Configuration.GetConnectionString("Dev");
    options.UseNpgsql(connectionString, x => x.MigrationsAssembly("webapp.migrations"));
  }
});

builder.Services
  .AddDefaultIdentity<User>(options =>
  {
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedEmail = true;
  })
  .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var visitorLogOptions = builder.Configuration.GetSection(VisitorLogOptions.SectionName);
builder.Services.AddProxyDetection();
builder.Services.AddVisitorLog(visitorLogOptions);

builder.Services.AddSingleton<IDivisionService, DivisionService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddHttpClient<ITextingService, TextingService>();
builder.Services.AddHttpClient<IPaymentService, PaymentService>();
//builder.Services.AddHttpClient<IBackgroundCheckService, AuthenticateService>();


/******************************************************************************
 *  All code above this point is for app configuration
 * ***************************************************************************/

var app = builder.Build();

/******************************************************************************
 *  All code below this point is for pipeline configuration
 * ***************************************************************************/

app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions
{
  SourceCodeLineCount = 5,
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days.
  // You may want to change this for production scenarios,
  // see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
// public assets
app.UseStaticFiles();
app.UseProxyDetection();
app.UseVisitorLog();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//app.UseEndpoints();

app.MapGet("/BackgroundCheck", () => {

});

app.MapRazorPages();

app.Run();
