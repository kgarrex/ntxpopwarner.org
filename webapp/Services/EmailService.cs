using MimeKit;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.IO;

public class Email
{
  public System.Net.Mail.MailAddress? To;
  public string? Subject;
  public string? TextBody;
  public string? HtmlBody;
}

public interface IEmailService
{
  public void SendTextEmail(Email email);
  public void SendHtmlEmail(Email email);
}

public class EmailService : IEmailService
{
  private readonly string _fromAddress = "info@ntxpopwarner.org";
  private readonly string _fromName = "North Texas Pop Warner";
  private readonly string _password = "ntxpopwarner24";
  private readonly string _serverName = "smtp.office365.com";
  private readonly int    _port = 587;

  public void SendTextEmail(Email email)
  {
    MimeMessage message = new MimeMessage();
    message.From.Add(new MailboxAddress(_fromName, _fromAddress));
    message.To.Add((MailboxAddress)email.To);
    message.Subject = email.Subject;
    message.Body = (new BodyBuilder { TextBody = email.TextBody }).ToMessageBody();

    using SmtpClient smtp = new SmtpClient();
    smtp.Connect(_serverName, _port, SecureSocketOptions.StartTls);
    smtp.Authenticate(_fromAddress, _password);
    smtp.Send(message);
    smtp.Disconnect(true);
  }

  public void SendHtmlEmail(Email email)
  {
    MimeMessage message = new MimeMessage();
    message.From.Add(new MailboxAddress(_fromName, _fromAddress));
    message.To.Add((MailboxAddress)email.To);
    message.Subject = email.Subject;
    message.Body = (new BodyBuilder { HtmlBody = email.HtmlBody}).ToMessageBody();

    using SmtpClient smtp = new SmtpClient();
    smtp.Connect(_serverName, _port, SecureSocketOptions.StartTls);
    smtp.Authenticate(_fromAddress, _password);
    smtp.Send(message);
    smtp.Disconnect(true);
  }

  public void LoadHtmlEmail(Email email, string filename, params object?[] args)
  {
    using FileStream stream = new FileStream(filename, FileMode.Open);
    using StreamReader reader = new StreamReader(stream);
    var htmlString = String.Format(reader.ReadToEnd(), args);
    email.HtmlBody = htmlString;
  }
}
