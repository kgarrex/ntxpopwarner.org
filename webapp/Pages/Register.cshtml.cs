using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

//namespace ntxpopwarner.team;

public partial class RegisterModel : PublicPageModel {

  private readonly ILogger<RegisterModel> _logger;
  //private readonly UserManager<IdentityUser> _userManager;

  public Team? Team { get; set; }


  public RegisterModel(ILogger<RegisterModel> logger) : base()
  {
    _logger = logger;
    _pageTitle = "Sign Up With North Texas Pop Warner";
  }


  public async Task<IActionResult> OnPostAsync()
  {
    // 1. Write the team registration to the database
    try
    {
      if(ModelState.IsValid)
      {
      }
      return Page();
    } catch(Exception ex)
    {
      LogRegistrationFailed(ex);
    }
    return Page();
  }

  [LoggerMessage(
    EventId = 0,
    Level   = LogLevel.Error,
    Message = "Failed to post registration {ex}")]
  private partial void LogRegistrationFailed(
    Exception ex);


  public partial class BindingModel
  {
   
  }
}
