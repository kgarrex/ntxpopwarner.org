using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using Stripe;

public interface IPaymentService
{
  public void MakePayment();
}

public class PaymentService : IPaymentService
{
  private readonly HttpClient _http;
  private readonly IConfiguration _config;
  public PaymentService(HttpClient httpClient, IConfiguration config)
  {
    _http = httpClient;
    _config = config;
    StripeConfiguration.ApiKey = config.GetValue<string>("STRIPE_SECRET_KEY");
  }

  public void MakePayment()
  {
    var options = new PaymentIntentCreateOptions
    {
    
    };
    
  }

  private string NewIdempotencyKey()
  {
    return new Guid().ToString();
  }
}
