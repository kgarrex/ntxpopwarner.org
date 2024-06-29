using System;
using System.Text.Json.Serialization;

public class SMSRequest
{
  /**
   * <value>
   * Sending address (+E.164 formatted phone number, alphanumeric sender ID, or short code).
   * Required if sending with a phone number, short code, or alphanumeric sender ID.
   * </value>
   */
  [JsonRequired]
  [JsonPropertyName("from")]
  public string? From { get; set; }
  /**
   * <value>
   * Unique identifier for a messaging profile.
   * Required if sending via number pool or with an alphanumeric sender ID.
   * </value>
   */
  [JsonPropertyName("messaging_profile_id")]
  public string? MessagingProfileId { get; set; }
  /**
   * <value>
   * Receiving address (+E.164 formatted phone number or short code).
   * </value>
   */
  [JsonRequired]
  [JsonPropertyName("to")]
  public string? To { get; set; }
  /**
   * <value>
   * Message body (i.e., content) as a non-empty string.
   * Required for SMS.
   * </value>
   */
  [JsonRequired]
  [JsonPropertyName("text")]
  public string? Text { get; set; }
  /**
   * <value>Subject of a multimedia message</value>
   */
  [JsonPropertyName("subject")]
  public string? Subject { get; set; }
  /**
   * <value>
   * A list of media URLs. The total media size must be less than 1 MB.
   * Required for MMS.
   * </value>
   */
  [JsonPropertyName("media_urls")]
  public Uri[]? MediaUrls { get; set; }
  /**
   * <value> The URL where webhooks related to this message will be sent.</value>
   */
  [JsonPropertyName("webhook_url")]
  public Uri? WebhookUrl { get; set; }
  /**
   * <value>
   * The failover URL where webhooks related to this message will be sent if
   * sending to the primary URL fails.
   * </value>
   */
  [JsonPropertyName("webhook_failover_url")]
  public Uri? WebhookFailoverUrl { get; set; }
  /**
   * <value>
   * Default value: true
   * If the profile this number is associated with has webhooks, use them for delivery notifications.
   * If webhooks are also specified on the message itself, they will be attempted first, then
   * those on the profile.
   * </value>
   */
  [JsonPropertyName("use_profile_webhooks")]
  public bool UseProfileWebhooks { get; set; } = true;
  /**
   * <value>The protocol for sending the message, either SMS or MMS.</value>
   */
  [JsonPropertyName("type")]
  public string Type { get; set; } = "SMS";
  /**
   * <value>
   * Automatically detect if an SMS message is unusually long and exceeds
   * a recommended limit of message parts.
   * </value>
   */
  [JsonPropertyName("auto_detect")]
  public bool AutoDetect { get; set; } = true;
}


