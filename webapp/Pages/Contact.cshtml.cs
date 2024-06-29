using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

public partial class ContactModel : PublicPageModel 
{
  private readonly ILogger<ContactModel> _logger;
  private readonly IEmailService _emailService;

  [BindProperty]
  public InputModel Input { get; set; }
  public ContactModel(ILogger<ContactModel> logger, IEmailService emailService) : base()
  {
    _logger = logger;
    _emailService = emailService;
    _pageTitle = "Contact Us";
  }

  [LoggerMessage(
    EventId = 0,
    Level   = LogLevel.Warning,
    Message = "Contact form:\n\t{Email}\n\t{Subject}\n\t{Message}")]
  private partial void LogContactForm(string email, string subject, string message);

  public void OnPost()
  {
    LogContactForm(Input.Email, Input.Subject, Input.Message);
    string emailFormat = "Sender: {0}\n\nMessage: {1}"; 
    _emailService.SendTextEmail(new Email
    {
      To = new MailAddress("info@ntxpopwarner.org"),
      Subject = Input.Subject,
      TextBody = String.Format(emailFormat, Input.Email, Input.Message),
    });
  }

  public partial class InputModel 
  {
    [EmailAddress]
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
  }
}
