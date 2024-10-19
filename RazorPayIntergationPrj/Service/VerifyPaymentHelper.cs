using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RazorPayIntergationPrj.Service;

/// <summary>
/// VerifyPaymentHelper is passed as a DotNetObjectReference
/// This enables Javascript to invoke VerifyPayment method
/// </summary>
/// <param name="service"></param>
/// <param name="navManager"></param>
public class VerifyPaymentHelper(IService service, NavigationManager navManager)
{
    IService _service { get; set; } = service;
    NavigationManager _navigationManager { get; set; } = navManager;

    [JSInvokable]
    public void VerifyPayment(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature)
    {
        var result = false;

        result = _service.VerifyPayment(razorpayPaymentId, razorpayOrderId, razorpaySignature);

        _navigationManager.NavigateTo($"/PaymentResultPage/{result}");
    }
}
