using Microsoft.AspNetCore.Identity;
using System;

public class User : IdentityUser {
  public int? UserId { get; set; }
  public string? Firstname { get; set; }
  public string? Lastname { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Address { get; set; }
  public DateTime CreatedOn { get; set; }
  public bool IsSignedIn { get; set; }
}
