using System;
using System.Net.Http;

namespace Services.Authenticate;

public class User {
  public string? FirstName { get; set; }
  public string? MiddleName { get; set; }
  public string? LastName { get; set; }
  public string? DateOfBirth { get; set; }
  public string? EmailAddress { get; set; }
  public string? PhoneNumber { get; set; }
  public string? HouseNumber { get; set; }
  public string? StreetName { get; set; }

  /// <value>DEPRECATED, add houseNumber and streetName instead</value>
  public string? Address { get; set; }

  /// <value>City of the user</value>
  public string? City { get; set; }

  /// <value>State of the user</value>
  public string? State { get; set; }

  /// <value>Zip code of the user</value>
  public string? ZipCode { get; set; }

  /// <value>Social Security Number of the user (Full 9 digit SSN or First 5 digits or Last 4 digits)</value>
  public string? SSN { get; set; }

  /// <value>ISO 3166-1 alpha-3</value>
  public string? Country { get; set; }

}

public class UserConsent
{
  public string? UserAccessCode { get; set; }
  public bool? IsBackgroundDisclosureAccepted { get; set; }
  public bool? GLBPurposeAndDPPAPurpose { get; set; }
  public bool? FCRAPurpose { get; set; }
  public string? FullName { get; set; }
}

public interface IBackgroundCheckService
{
  public void RunBackground();
}

public class AuthenticateService 
{
  private readonly HttpClient _client;

  public AuthenticateService(HttpClient client)
  {
    _client = client;
  }

  public void RunBackground(){}

  /**
   * <summary>
   * Creates a user profile or an object on the Authenticate system.
   * </summary>
   * <returns>The userAccessCode to be used on subsequent user API calls.</returns>
   */
  public string CreateUser(User user) {
    throw new NotImplementedException();
  }

  public void GetMedallionToken(string userAccessCode, Uri redirectUrl, string preferredWorkflowId)
  {
    throw new NotImplementedException();
  }

  public bool SubmitUserConsent(UserConsent consent) {
    throw new NotImplementedException();
  }

  public bool UpdateUser(User user) {
    throw new NotImplementedException();
  }

  public bool SetWebhook(string accessCode, Uri url) {
    //https://api-v3.authenticating.com/company/webhook
    throw new NotImplementedException();
  }
}
