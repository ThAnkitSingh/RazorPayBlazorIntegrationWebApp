function openRazorpay(dotNetHelper, orderId, customerName, email, mobile) {
    var options = {
        "name": customerName,
        "description": "Payment for order",
        "order_id": orderId, // Order ID generated from server
        "image": "https://example.com/your_logo",
        "handler": function (response) {
            dotNetHelper.invokeMethodAsync('VerifyPayment', response.razorpay_payment_id, response.razorpay_order_id, response.razorpay_signature);            
        },
        "prefill": {
            "name": customerName,
            "email": email,
            "contact": mobile
        },
        "notes": {
            "address": "Hello World"
        },
        "theme": {
            "color": "#3399cc"
        }
    };
    options.theme.image_padding = false;
    options.modal = {
        ondismiss: function () {
            console.log("This code runs when the popup is closed");
        },
        // Boolean indicating whether pressing escape key
        // should close the checkout form. (default: true)
        escape: true,
        // Boolean indicating whether clicking translucent blank
        // space outside checkout form should close the form. (default: false)
        backdropclose: false
    };
    var rzp = new Razorpay(options);
    rzp.open();
}