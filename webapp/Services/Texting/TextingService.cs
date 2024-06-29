using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public interface ITextingService
{
  public Task SendSMS(string to, string text);
}

public enum MessageType
{
  SMS,
  MMS
}

public enum LineType
{
  Wireline,
  Wireless,
  VoWiFi,
  VoIP,
  PrePaidWireless
}

public enum DeliveryStatus
{
  Queued,
  Sending,
  Sent,
  Expired,
  SendingFailed,
  DeliveryUnconfirmed,
  Delivered,
  DeliveryFailed
}

public partial class TextingService : ITextingService
{
  private readonly ILogger<TextingService> _logger;
  private readonly IConfiguration _config;
  private readonly HttpClient _http;
  public TextingService(ILogger<TextingService> logger, IConfiguration config, HttpClient httpClient)
  {
    _logger = logger;
    _config = config;
    _http = httpClient;
    _http.BaseAddress = new Uri("https://api.telnyx.com/v2/");
    _http.DefaultRequestHeaders.Authorization =
      new AuthenticationHeaderValue("Bearer", _config.GetValue<string>("Telnyx_APIKey"));
  }

  public async Task SendSMS(string to, string text)
  {
    try
    {
      var smsRequest = new SMSRequest
      {
        MessagingProfileId = _config.GetValue<string>("Telnyx_ProfileId"),
        From = _config.GetValue<string>("Telnyx_Phone"),
        To = to,
        Text = text,
      };
      //Console.WriteLine($"From: {from} | To: {to} | Text: {text}");
      var smsResponse = await SendSMS(smsRequest);
      if(smsResponse.Errors.Length > 0)
      {
        foreach(var error in smsResponse.Errors)
        {
          LogFailedSMSMessage(error.Code, error.Title, error.Detail, error.Source.Pointer);
        }
      }
    }
    catch(Exception ex)
    {
       /*
      foreach(var error in response.Errors)
      {
        LogFailedSMSMessage(error.Code, error.Title, error.Detail);
      }
      */
    }
 
  }

  [LoggerMessage(
    EventId = 1,
    Level   = LogLevel.Error,
    Message = "Text Service failed: {Code} | {Title} | {Detail} | {Pointer}")]
  private partial void LogFailedSMSMessage(int? code, string? title, string? detail, string? pointer);


  private async Task<SMSResponse> SendSMS(SMSRequest smsRequest)
  {
    HttpResponseMessage response;
    string mediaType = "application/json";
    string json = JsonSerializer.Serialize<SMSRequest>(smsRequest, new JsonSerializerOptions
    {});
    Console.WriteLine($"Json:\n{json}");
    using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "messages");
    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
    request.Content = new StringContent(json, Encoding.UTF8, mediaType);
    response = await _http.SendAsync(request);
    Console.WriteLine($"Response Code: {response.StatusCode}");
    //response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<SMSResponse>();
  }
}
