using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public partial class AuthModel : PublicPageModel 
{
  private readonly ILogger<AuthModel> _logger;
  private readonly SignInManager<User> _signInManager;
 
  [BindProperty]
  public BindingModel Input { get; set; }

  public AuthModel(ILogger<AuthModel> logger)
  {
    _logger = logger;
  }

  public void OnPost()
  {
    if(!ModelState.IsValid)
    {
    
    }
    LogAuth(Input.Username, Input.Password);
  }

  public class BindingModel
  {
    [EmailAddress]
    public string Username { get; set; }
    public string Password { get; set; }
  }

  

/***********************************************************************
 * Logger Messages
 ***********************************************************************/

  [LoggerMessage(
    EventId = 1,
    Level   = LogLevel.Information,
    Message = "Username: {Username} | Password: {Password}")]
  private partial void LogAuth(string username, string password);

}
