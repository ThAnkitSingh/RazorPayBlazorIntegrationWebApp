using Razorpay.Api;
using Microsoft.AspNetCore.Components;
using BlazorRazorPay.Models;

namespace BlazorRazorPay.Services;

/// <summary>
/// RazorpayService class implements IService and provides methods to 
/// create order using Razorpay API
/// verify payment if it was successful
/// </summary>
public class RazorpayService(NavigationManager navigationManager) : IService
{
    private readonly string _key = "Your_Api_Key";
    private readonly string _secret = "Your_Secret_Key";
    private readonly NavigationManager _navigationManager = navigationManager;

    public string CreateOrder(decimal amount)
    {
        //random id generate
        Random _random = new();
        string TransactionId = _random.Next(0, 10000).ToString();

        Dictionary<string, object> options = new()
        {
            { "amount", amount * 100 }, // Amount in paise (multiply by 100)
            { "currency", "MYR" },
            { "receipt", $"TxnId_{TransactionId}" }
        };

        RazorpayClient client = new(_key, _secret);
        Order order = client.Order.Create(options);
        return order["id"].ToString();
    }

    public bool VerifyPayment(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature)
    {
        Dictionary<string, string> attributes = new()
        {
            { "razorpay_payment_id", razorpayPaymentId },
            { "razorpay_order_id", razorpayOrderId },
            { "razorpay_signature", razorpaySignature }
        };

        try
        {
            Utils.verifyPaymentSignature(attributes);

            OrderEntity orderEntity = new()
            {
                TransactionId = razorpayPaymentId,
                OrderId = razorpayOrderId
            };

            return true;
        }
        catch (Exception ex)
        {
            // Handle exception
            var message = ex.Message;
            Console.WriteLine(message);
            return false;
        }              

    }
}
