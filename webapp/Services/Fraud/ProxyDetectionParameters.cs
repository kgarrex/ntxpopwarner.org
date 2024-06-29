using System.ComponentModel.DataAnnotations;
using System.Net;

public class ProxyDetectionParameters : HttpRequestParameters
{
  [HttpRequestParameter("key")]
  public string? PrivateKey { get; set; }

  [HttpRequestParameter("ip")]
  public IPAddress? IpAddress { get; set; }
  /**
   * <value>
   * How in depth (strict) do you want this query to be? Higher values take
   * longer to process and may provide a higher false-positive rate. We
   * recommend starting at "0", the lowest strictness setting, and increasing
   * to "1" depending on your levels of fraud. Levels 2+ are VERY strict and
   * will produce false-positives.
   * </value>
   */
  [HttpRequestParameter("strictness"), Range(0,3)]
  public int Strictness { get; set; } = 0;
  /**
   * <value>
   * You can optionally provide us with the user agent string (browser). This
   * allows us to run additional checks to see if the user is a bot or running
   * an invalid browser. This allows us to evaluate the risk of the user as
   * judged in the "fraud_score".
   * </value>
   */
  [HttpRequestParameter("user_agent")]
  public string? UserAgent { get; set; }
  /**
   * <value>
   * You can optionally provide us with the user's language header. This
   * allows us to evaluate the risk of the user as judged in the "fraud_score".
   * </value>
   */
  [HttpRequestParameter("user_language")]
  public string? UserLanguage { get; set; }
  /**
   * <value>
   * When this parameter is enabled our API will not perform certain forensic
   * checks that take longer to process. Enabling this feature greatly increases
   * the API speed without much impact on accuracy. This option is intended for
   * services that require decision making in a time sensitive manner and can
   * be used for any strictness level.
   * </value>
   */
  [HttpRequestParameter("fast")]
  public bool DoFastLookup { get ; set; } = false;
  /**
   * <value>
   * You can optionally specify that this lookup should be treated as a mobile
   * device. Recommended for mobile lookups that do not have a user agent
   * attached to the request. NOTE: This can cause unexpected and abnormal
   * results if the device is not a mobile device.
   * </value>
   */
  [HttpRequestParameter("mobile")]
  public bool IsMobileDevice { get; set; } = false;
  /**
   * <value>
   * Bypasses certain checks for IP addresses from education and research
   * institutions, schools, and some corporate connections to better
   * accomodate audiences that frequently use public connections.
   * </value>
   */
  [HttpRequestParameter("allow_public_access_points")]
  public bool AllowPublicAccessPoints { get; set; } = true;
  /**
   * <value>
   * Is your scoring too strict? Enable this setting to lower detection rates and
   * Proxy Scores for mixed quality IP addresses. If you experience any false-positives
   * with your traffic then enabling this feature will provide better results.
   * </value>
   */
  [HttpRequestParameter("lighter_penalties")]
  public bool DoLighterPenalties { get; set; } = true;
  /**
   * <value>
   * Adjusts the weights for penalties applied due to irregularities and fraudulent
   * patterns detected on order and transaction details that can be optionally
   * provided on each API request. This feature is only beneficial if you are
   * passing order and transaction details. A table is available further down
   * the page with supported transaction variables.
   * </value>
   */
  [HttpRequestParameter("transaction_strictness"), Range(0,2)]
  public int TransactionStrictness { get; set; } = 0;
}
