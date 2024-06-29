using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection;

public abstract class PublicPageModel : PageModel
{
  //public User? CurrentUser { get; set; }
  protected string _pageTitle;
  

  public PublicPageModel()
  {
    string className = this.GetType().Name;
    //ViewData["PageName"] = className.Remove(className.LastIndexOf("Model"));
    // Set to generic visitor
    //User = 
  }

  public virtual void OnGet()
  {
    ViewData["Title"] = _pageTitle;
  }

  public virtual void OnPostSignIn(string username, string password)
  {
    Console.WriteLine($"Username: {username} | Password: {password}");
  }

  /*
   public virtual IActionResult OnPost()
  {
    var username = Request.Form["Username"];
    var password = Request.Form["Password"];
    ViewData["confirmation"] = $"{username} has signed in with password: {password}";
    return Page();
  }
  */
}
