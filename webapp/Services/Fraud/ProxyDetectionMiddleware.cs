using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


public class ProxyDetectionOptions
{
  public static readonly string SectionName = "ProxyDetector";
  public bool Enabled { get; set; } = false;
}


public partial class ProxyDetectionMiddleware : IMiddleware
{
  private readonly ILogger<ProxyDetectionMiddleware> _logger;
  private readonly ProxyDetectionOptions _options;
  private readonly IHttpClientFactory _httpFactory;
  private string _ipqsKey = "ekJQhLQF5xlz4UHK65K94rNWSI6Wtsi0";
  public ProxyDetectionMiddleware(
    ILogger<ProxyDetectionMiddleware> logger,
    ProxyDetectionOptions options,
    IHttpClientFactory httpFactory)
  {
    _logger = logger;
    _options = options;
    _httpFactory = httpFactory;
  }

  [LoggerMessage(
    EventId = 0,
    Level   = LogLevel.Debug,
    Message = "Form Content: {contentString}")]
  private partial void LogTestContent(string contentString);


  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    if(_options.Enabled)
    {
      var proxyDetected = await DetectProxy(context);
      if(proxyDetected)
      {
        // TODO logic to return 403 forbidden
      }
    }
    await next.Invoke(context);
  }

  private async Task<bool> DetectProxy(HttpContext context)
  {
    var parameters = new ProxyDetectionParameters
    {
      PrivateKey = _ipqsKey,
      IpAddress = context.Connection.RemoteIpAddress,
      UserAgent = !StringValues.IsNullOrEmpty(context.Request.Headers.UserAgent) ?
        context.Request.Headers.UserAgent[0] : null,
      UserLanguage = !StringValues.IsNullOrEmpty(context.Request.Headers.ContentLanguage) ?
        context.Request.Headers.ContentLanguage[0] : null,
    };

    // Testing content
    var content = new FormUrlEncodedContent(parameters.AsEnumerable());
    string contentString = await content.ReadAsStringAsync();
    LogTestContent(Uri.UnescapeDataString(contentString));
    // Testing content

    using HttpRequestMessage request = new HttpRequestMessage
    {
      Method = HttpMethod.Post,
      Content = new FormUrlEncodedContent(parameters.AsEnumerable()),
    };
    HttpClient _http = _httpFactory.CreateClient("ProxyDetection");
    HttpResponseMessage response = await _http.SendAsync(request);
    response.EnsureSuccessStatusCode();
    var result = await response.Content.ReadFromJsonAsync<ProxyDetectionResult>();
    if(!result.Success)
    {
      LogTestContent(result.Message);
      /*
      foreach(string error in result.Errors)
      {
        LogTestContent(error);
      }
      */
    }
    // TODO Need algorithm to determine if we should forbid
    return false;
  }
}

public static partial class Extensions
{
  public static void AddProxyDetection(this IServiceCollection services)
  {
    services.AddHttpClient("ProxyDetection", http =>
    {
      http.BaseAddress = new Uri("https://www.ipqualityscore.com/api/json/ip/");
      http.Timeout = TimeSpan.FromMinutes(2);
      //_http.DefaultRequestHeaders.Add("IPS-KEY", _ipqsKey);
    });
    services.AddTransient<ProxyDetectionMiddleware>(provider =>
    {
      var logger = provider.GetRequiredService<ILogger<ProxyDetectionMiddleware>>();
      var httpFactory = provider.GetRequiredService<IHttpClientFactory>();
      var options = provider
        .GetRequiredService<IConfiguration>()
        .GetSection(ProxyDetectionOptions.SectionName)
        .Get<ProxyDetectionOptions>();
      return new ProxyDetectionMiddleware(logger: logger, options: options, httpFactory: httpFactory);
    });
  }

  public static void AddProxyDetection(this IServiceCollection services, IConfiguration section)
  {
    services.AddHttpClient("ProxyDetection", http =>
    {
      http.BaseAddress = new Uri("https://www.ipqualityscore.com/api/json/ip/");
      http.Timeout = TimeSpan.FromMinutes(2);
      //_http.DefaultRequestHeaders.Add("IPS-KEY", _ipqsKey);
    });
    services.AddOptions<ProxyDetectionOptions>()
      .Bind(section)
      .ValidateDataAnnotations()
      .ValidateOnStart();
    services.AddTransient<ProxyDetectionMiddleware>(provider =>
    {
      var logger = provider.GetRequiredService<ILogger<ProxyDetectionMiddleware>>();
      var httpFactory = provider.GetRequiredService<IHttpClientFactory>();
      var options = provider.GetRequiredService<IOptions<ProxyDetectionOptions>>().Value;
      return new ProxyDetectionMiddleware(logger: logger, options: options, httpFactory: httpFactory);
    });
  }

  public static IApplicationBuilder UseProxyDetection(this IApplicationBuilder app) =>
    app.UseMiddleware<ProxyDetectionMiddleware>();
}

public class IPQSService
{
  private readonly HttpClient _http;

  /*
  public IPQSService(HttpClient http)
  {
    _http = http;
    _http.BaseAddress = new Uri("https://www.ipqualityscore.com/api/json/ip/"),
  }

  public 
  */
}
