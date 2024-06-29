using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

public record Visitor
{
  public IPAddress? RemoteIp   { get; set; }
  public int?        RemotePort { get; set; }
  public string?     Path       { get; set; }
  public string?     Query      { get; set; }
  public string?     UserAgent  { get; set; }
  public string?     SessionId  { get; set; }
  public HttpMethod? HttpMethod { get; set; }
}

public interface IVisitorLogger
{
  public void LogVisit(Visitor visitor);
}

public class VisitorLogOptions
{
  public static readonly string SectionName = "VisitorLog";
  public bool Enabled { get; set; } = false;
  public string? DisplayName { get; set; }
  public string? Subject { get; set; }
  [EmailAddress] public string? ToAddress { get; set; }
}

/// <summary>
/// Middleware to log a visitor to the website
/// </summary>
public partial class VisitorLogMiddleware : IMiddleware
{
  private readonly VisitorLogOptions _options;
  private readonly ILogger<VisitorLogMiddleware> _logger;
  private readonly IEnumerable<IVisitorLogger> _loggers;
  public VisitorLogMiddleware(
    ILogger<VisitorLogMiddleware> logger,
    VisitorLogOptions options,
    IEnumerable<IVisitorLogger> loggers)
  {
    _logger  = logger;
    _options = options;
    _loggers = loggers;
  }

  [LoggerMessage(
    EventId   = 0,
    Level     = LogLevel.Information,
    Message   = "New site visitor: {Visitor}")]
    //EventName = "My Middleware")]
  private partial void LogNewVisitorSession(Visitor visitor);


  /// <summary>
  /// Creates a visitor log from an HTTP request and passes to the registerd logging services.
  /// </summary>
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    if(_options.Enabled)
      LogVisit(context);
    await next.Invoke(context);
  }

  private async Task LogVisit(HttpContext context)
  {
    var visitor = new Visitor
    {
      RemoteIp = context.Connection.RemoteIpAddress,
      RemotePort = context.Connection.RemotePort,
      Path = context.Request.Path.HasValue
        ? context.Request.Path.Value
        : String.Empty,
      Query = context.Request.QueryString.HasValue
        ? context.Request.QueryString.Value
        : String.Empty,
      UserAgent = StringValues.IsNullOrEmpty(context.Request.Headers.UserAgent)
        ? String.Empty
        : context.Request.Headers.UserAgent[0],
      //SessionId = context.Session.Id,
      HttpMethod = new HttpMethod(context.Request.Method),
    };
    LogNewVisitorSession(visitor);
    foreach(var logger in _loggers) logger.LogVisit(visitor);
  }
}

public static partial class Extensions
{
  private static void AddVisitorLoggers(IServiceCollection services)
  {
    // Use reflection to add all visitor loggers in the assembly as transient services
    var visitorLoggers = Assembly.GetCallingAssembly().GetTypes()
      .Where(type => typeof(IVisitorLogger).IsAssignableFrom(type) && !type.IsInterface);
    foreach(var logger in visitorLoggers)
      services.AddTransient(typeof(IVisitorLogger), logger);
  }

  public static void AddVisitorLog(this IServiceCollection services)
  {
    AddVisitorLoggers(services);
    services.AddTransient<VisitorLogMiddleware>(provider =>
    {
      var logger = provider.GetRequiredService<ILogger<VisitorLogMiddleware>>();
      var loggers = provider.GetRequiredService<IEnumerable<IVisitorLogger>>();
      var options = provider
        .GetRequiredService<IConfiguration>()
        .GetSection(VisitorLogOptions.SectionName)
        .Get<VisitorLogOptions>();
      return new VisitorLogMiddleware(logger: logger, options: options, loggers: loggers);
    });
  }

  public static void AddVisitorLog(this IServiceCollection services, IConfigurationSection section)
  {
    services.AddOptions<VisitorLogOptions>()
      .Bind(section)
      .ValidateDataAnnotations()
      .ValidateOnStart();
    AddVisitorLoggers(services);
    services.AddTransient<VisitorLogMiddleware>(provider =>
    {
      var logger = provider.GetRequiredService<ILogger<VisitorLogMiddleware>>();
      var loggers = provider.GetRequiredService<IEnumerable<IVisitorLogger>>();
      var options = provider.GetRequiredService<IOptions<VisitorLogOptions>>().Value;
      return new VisitorLogMiddleware(logger: logger, options: options, loggers: loggers);
    });
  }

  public static IApplicationBuilder UseVisitorLog(this IApplicationBuilder app) =>
    app.UseMiddleware<VisitorLogMiddleware>();
}
