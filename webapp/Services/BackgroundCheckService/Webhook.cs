using System;

public enum WebhookEventType {

  /// <summary>The user's PII has been updated.</summary>
  UserProfileUpdated,

  /// <summary>Medallion try status</summary>
  SelfVerificationTryStatus,

  /// <summary>
  /// COUNTY_CRIMINAL, COUNTY_CIVIL, FEDERAL_CRIMINAL, and FEDERAL_CIVIL
  /// updates for a particular search request placed.
  /// </summary>
  CriminalRequestStatusUpdate,

  /// <summary>All county criminal requests have been completed for a particular user.</summary>
  AllCriminalRequestsComplete,

  /// <summary>
  /// Upload ID Enhanced review completed. Results can be fetched through the
  /// Test Results Object.
  /// </summary>
  ///
  UploadIdEnhancedReviewStatus,
  /// <summary>
  /// Upload Passport Enhanced review completed. Results can be fetched through the
  /// Test Results Object.
  /// </summary>
  UploadPassportEnhancedReviewStatus,

  /// <summary>
  /// Each stage of user pdf report generation. There are three stages INITIATED, COMPLETED and FAILED.
  /// The reportLink and expires fields are only shown when the stage is COMPLETED.
  /// </summary>
  UserPdfReportGeneration
}

public class WebhookEvent {
  public string? Id { get; set; }
  public WebhookEventType? Event { get; set; }
  public DateTime? EventDate { get; set; }
  public object? Order { get; set; }
}
