using Razorpay.Api;
using Microsoft.AspNetCore.Components;

namespace RazorPayIntergationPrj.Service;

/// <summary>
/// RazorpayService class implements IService and provides methods to 
/// create order using Razorpay API
/// verify payment if it was successful
/// </summary>
public class RazorpayService : IService
{
    private readonly string _key;
    private readonly string _secret;
    private readonly NavigationManager _navigationManager;

    public RazorpayService(NavigationManager navigationManager)
    {
        _key = "your_key";
        _secret = "your_secrete_key";
        _navigationManager = navigationManager;
    }

    public string CreateOrder(decimal amount)
    {
        //random id generate
        Random _random = new();
        string TransactionId = _random.Next(0, 10000).ToString();

        Dictionary<string, object> options = new Dictionary<string, object>
        {
            { "amount", amount * 100 }, // Amount in paise (multiply by 100)
            { "currency", "INR" },
            { "receipt", "TransactionId" }
        };

        RazorpayClient client = new RazorpayClient(_key, _secret);
        Order order = client.Order.Create(options);
        return order["id"].ToString();
    }

    public bool VerifyPayment(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature)
    {
        Dictionary<string, string> attributes = new Dictionary<string, string>();
        attributes.Add("razorpay_payment_id", razorpayPaymentId);
        attributes.Add("razorpay_order_id", razorpayOrderId);
        attributes.Add("razorpay_signature", razorpaySignature);

        try
        {
            Utils.verifyPaymentSignature(attributes);

            OrderEntity orderEntity = new OrderEntity();

            orderEntity.TransactionId = razorpayPaymentId;
            orderEntity.OrderId = razorpayOrderId;

            return true;
        }
        catch (Exception ex)
        {
            // Handle exception
            var message = ex.Message;
            return false;
        }              

    }
}
