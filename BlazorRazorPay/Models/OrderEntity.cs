using System.ComponentModel.DataAnnotations;

namespace BlazorRazorPay.Models;
public class OrderEntity
{
    //Todo: put validation here

    public int Id { get; set; }

    [Required]
    public string CustomerName { get; set; } = "Leong Wen Hock";

    [Required]
    public string CustomerEmail { get; set; } = "leongwh@gmail.com";

    [Required]
    public string Mobile { get; set; } = "9873749374";

    [Required]
    public double TotalAmount { get; set; } = 1.11;

    public string TransactionId { get; set; }

    public string OrderId { get; set; }
}
