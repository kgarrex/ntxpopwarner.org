using System;
using System.Text.Json.Serialization;

public class SMSResponse
{
  [JsonPropertyName("record_type")]
  public string? RecordType { get; set; }

  [JsonPropertyName("direction")]
  public string? Direction { get; set; }

  [JsonPropertyName("id")]
  public Guid? Id { get; set; }

  [JsonPropertyName("type")]
  public string? Type { get; set; }

  [JsonPropertyName("messaging_profile_id")]
  public string? MessagingProfileId { get; set; }

  [JsonPropertyName("organization_id")]
  public Guid? OrganizationId { get; set; }

  [JsonPropertyName("from")]
  public DeviceEndpoint? From { get; set; }

  [JsonPropertyName("to")]
  public DeviceEndpoint[]? To { get; set; }

  [JsonPropertyName("text")]
  public string? Text { get; set; }

  [JsonPropertyName("subject")]
  public string? Subject { get; set; }

  [JsonPropertyName("media")]
  public MediaInfo[]? Media { get; set; }

  [JsonPropertyName("webhook_url")]
  public Uri? WebhookUrl { get; set; }

  [JsonPropertyName("webhook_failover_url")]
  public Uri? WebhookFailoverUrl { get; set; }
  /**
   * <value>Encoding scheme used for the message body.</value>
   */
  [JsonPropertyName("encoding")]
  public string? Encoding { get; set; }
  /**
   * <value>Number of parts into which the message's body must be split.</value>
   */
  [JsonPropertyName("parts")]
  public int? Parts { get; set; }
  /**
   * <value>Tags associated with the resource.</value>
   */
  [JsonPropertyName("tags")]
  public string[]? Tags { get; set; }

  [JsonPropertyName("cost")]
  public CostObject? Cost { get; set; }

  [JsonPropertyName("received_at")]
  public DateTime? ReceivedAt { get; set; }

  [JsonPropertyName("sent_at")]
  public DateTime? SentAt { get; set; }

  [JsonPropertyName("completed_at")]
  public DateTime? CompletedAt { get; set; }

  /**
   * <value>
   * Message must be out of the queue by this time or else it will be discarded and marked
   * as 'sending_failed'. Once the message moves out of the queue, this field will be nulled.
   * </value>
   */
  [JsonPropertyName("valid_until")]
  public DateTime? ValidUntil { get; set; }

  [JsonPropertyName("errors")]
  public Error[]? Errors { get; set; }


  public class DeviceEndpoint
  {
    /**
     * <value>
     * Address of sender/receiver (+E.164 formatted phone number, alphanumeric sender ID, or short code.
     * </value>
     */
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }
    /**
     * <value>The delivery status of the message.</value>
     */
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    /**
     * <value>The carrier of the receiver.</value>
     */
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }
    /**
     * <value>The line-type of the receiver.</value>
     */
    [JsonPropertyName("line_type")]
    public string? LineType { get; set; }
  }

  public class MediaInfo
  {
    /**
     * <value>The url of the media requested to be sent.</value>
     */
    [JsonPropertyName("url")]
    public Uri? Url { get; set; }
    /**
     * <value>The MIME type of the requested media.</value>
     */
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }
    /**
     * <value>The SHA256 hash of the requested media.</value>
     */
    [JsonPropertyName("sha256")]
    public string? SHA256 { get; set; }
    /**
     * <value>The size of the requested media.</value>
     */
    [JsonPropertyName("size")]
    public int? Size { get; set; }
  }

  public class CostObject
  {
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
  }

  public class Error
  {
    [JsonPropertyName("code")]
    public int? Code { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }
    [JsonPropertyName("source")]
    public ErrorSource? Source { get; set; }
    [JsonPropertyName("meta")]
    public object? Meta { get; set; }

    public class ErrorSource
    {
      [JsonPropertyName("pointer")]
      public string? Pointer { get; set; }
      [JsonPropertyName("parameter")]
      public string? Parameter { get; set; }
    }
  }
}
