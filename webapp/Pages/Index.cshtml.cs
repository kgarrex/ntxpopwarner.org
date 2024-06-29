using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

//namespace Ntxpopwarner.Public;

public class IndexModel : PublicPageModel 
{
  private readonly IConfiguration _config;
  private readonly ITextingService _texting;
  public string Message { get; set; }
 
  public IndexModel(ITextingService texting, IConfiguration config)
  {
    _config = config;
    _texting = texting;
    _pageTitle = "Welcome to North Texas Pop Warner!";
  }

  public override void OnGet()
  {
    base.OnGet();
  }

  public void OnPost()
  {
    Message = "Post used";
  }

  public override void OnPostSignIn(string username, string password)
  {
    base.OnPostSignIn(username, password);
    Message = $"Username: {username} | Password: {password}";
  }

}
