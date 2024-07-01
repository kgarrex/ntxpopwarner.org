using System.Text.Json.Serialization;

public class WeatherForecastResponse
{
  public class Timelines
  {
    public WeatherData[] Minutely { get; set; }
    public WeatherData[] Hourly { get; set; }
    public WeatherData[] Daily { get; set; }
  }

  public class WeatherData
  {
    /// <value>
    /// The lowest altitude at which at which the visible portion of a cloud begins.
    /// </value>
    [JsonPropertyName("cloudBase")]
    public int CloudBase { get; set; }

    /// <value>
    /// The highest altitude of the visible portion of a cloud
    /// (above ground level).
    /// </value>
    [JsonPropertyName("cloudCeiling")]
    public string CloudCeiling { get; set; }

    /// <value>
    /// The fraction of the sky obscured by clouds when observed
    /// from a particular location.
    /// </value>
    [JsonPropertyName("cloudCover")]
    public int CloudCover { get; set; }

    /// <value>
    /// The temperature to which air must be cooled to become
    /// saturated with water vapor.
    /// </value>
    [JsonPropertyName("dewPoint")]
    public int DewPoint { get; set; }

    /// <value>
    /// The combined processes by which water moves from the earth's surface into
    /// the atmosphere.
    /// </value>
    [JsonPropertyName("evapoTranspiration")]
    public int EvapoTranspiration { get; set; }

    /// <value>
    /// The measure of the intensity of freezing rain by calculating the amount of
    /// freezing rain that would fall over a given interval of time if the
    /// freezing rain intensity were constant over that time period.
    /// The rate is expressed in terms of length (depth) per unit time, in
    /// millimeters per hour, or inches per hour.
    /// </value>
    [JsonPropertyName("freezingRainIntensity")]
    public int FreezingRainIntensity { get; set; }

    /// <value>
    /// The concentration of water vapor present in the air represented
    /// as a percentage.
    /// </value>
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    /// <value>
    /// The accumulated amount of of ice from freezing rain that has or will
    /// accumulate for the past or future hour of the requested time.
    /// </value>
    [JsonPropertyName("iceAccumulation")]
    public int IceAccumulation { get; set; }

    /// <value>
    /// The liquid water equivalent accumulated amount of ice from freezing rain
    /// that has or will accumulate for the past or future hour of the requested
    /// time.
    /// </value>
    [JsonPropertyName("iceAccumulationLwe")]
    public int IceAccumulationLwe { get; set; }

    
    /// <value>
    /// Probability of precipitation represents the chance of >0.0254 cm (0.01 in.)
    /// of liquid equivalent precipitation at a radius surrounding a point location
    /// over a specific period of time.
    /// </value>
    [JsonPropertyName("precipationProbability")]
    public int PrecipitationProbability { get; set; }

    /// <value>
    /// The force exerted against a surface by the weight of the air above the
    /// surface (at the surface level).
    /// </value>
    [JsonPropertyName("pressureSurfaceLevel")]
    public decimal PressureSurfaceLevel { get; set; }


    [JsonPropertyName("rainAccumulation")]
    public int RainAccumulation { get; set; }

    [JsonPropertyName("rainIntensity")]
    public int RainIntensity { get; set; }

    [JsonPropertyName("sleetAccumulation")]
    public int SleetAccumulation { get; set; }

    [JsonPropertyName("sleetAccumulationLwe")]
    public int SleetAccumulationLwe { get; set; }

    [JsonPropertyName("sleetIntensity")]
    public int SleetIntensity { get; set; }

    [JsonPropertyName("snowAccumulation")]
    public int SnowAccumulation { get; set; }

    [JsonPropertyName("snowAccumulationLwe")]
    public int SnowAccumulationLwe { get; set; }

    [JsonPropertyName("snowIntensity")]
    public int SnowIntensity { get; set; }

    [JsonPropertyName("temperature")]
    public decimal Temperature { get; set; }

    [JsonPropertyName("temperatureApparent")]
    public decimal TemperatureApparent { get; set; }

    [JsonPropertyName("uvHealthConcern")]
    public int UVHealthConcern { get; set; }

    [JsonPropertyName("uvIndex")]
    public int UVIndex { get; set; }

    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [JsonPropertyName("weatherCode")]
    public int WeatherCode { get; set; }

    [JsonPropertyName("windDirection")]
    public decimal WindDirection { get; set; }

    [JsonPropertyName("windGust")]
    public int WindGust { get; set; }

    [JsonPropertyName("windSpeed")]
    public decimal WindSpeed { get; set; }
  }
}


