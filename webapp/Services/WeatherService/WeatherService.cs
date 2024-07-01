using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class WeatherForecastParameters : HttpRequestParameters
{
  public decimal Latitude { get; set; }
  public decimal Longitude { get; set; }
  public string ApiKey { get; set; }
}

public partial class WeatherService
{
  private readonly HttpClient _http;
  private readonly IConfiguration _config;
  private readonly ILogger<WeatherService> _logger;
  private readonly string _baseAddress = "https://api.tomorrow.io/v4/weather/";
  private readonly string _apikey = "5i3Un26pMz40yCYr235hGvlDCRjSmuoF"; 

  public WeatherService(
    HttpClient http,
    IConfiguration config,
    ILogger<WeatherService> logger)
  {
    _http = http;
    _config = config;
    _logger = logger;
  }

  /*
  GetForecast(new WeatherForecastParameters
  {
    Latitude = 0,
    Longitude = 0,
    ApiKey = 
  });
  */

  public async Task<WeatherForecastResponse> GetForecast(WeatherForecastParameters parameters)
  {
    string mediaType = "application/json";
    var request = new HttpRequestMessage(HttpMethod.Get, "forecast"); 
    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
    HttpResponseMessage response = await _http.SendAsync(request);
    return await response.Content.ReadFromJsonAsync<WeatherForecastResponse>();
  }
}
