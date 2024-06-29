using Microsoft.Extensions.Configuration;
using System.Net.Mail;

public class EmailVisitorLogger : IVisitorLogger
{
  private readonly IEmailService _emailer;
  private readonly IConfiguration _config;
  public EmailVisitorLogger(IEmailService emailer, IConfiguration config)
  {
    _emailer = emailer;
    _config = config;
  }

  public void LogVisit(Visitor visitor)
  {
    string toAddress =   _config.GetValue<string>("VisitorLog:ToAddress");
    string displayName = _config.GetValue<string>("VisitorLog:DisplayName");
    var email = new Email
    {
      To = new MailAddress(toAddress, displayName),
      Subject = "New Site Visitor",
      TextBody = @$"
        IpAddress: {visitor.RemoteIp?.ToString()}
        Port: {visitor.RemotePort.ToString()}
        Path: {visitor.Path}
        Query: {visitor.Query}
        UserAgent: {visitor.UserAgent}
        SessionId: {visitor.SessionId}
        Method: {visitor.HttpMethod?.ToString()}",
    };
    _emailer.SendTextEmail(email);
  }
}
