﻿namespace RazorPayIntergationPrj.Service
{
    public interface IService
    {
        string CreateOrder(decimal amount);
        bool VerifyPayment(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature);
    }
}