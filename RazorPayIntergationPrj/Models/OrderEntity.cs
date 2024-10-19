using System.ComponentModel.DataAnnotations;

namespace RazorPayIntergationPrj.Models
{
    public class OrderEntity
    {
        //Todo: put validation here

        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public double TotalAmount { get; set; }

        public string TransactionId { get; set; }

        public string OrderId { get; set; }
    }
}
