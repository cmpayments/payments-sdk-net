using System;

namespace CM.Payments.Client.SampleWebApp.Models
{
    public class OrderItem
    {
        public DateTime AddedOn { get; set; }
        public int Id { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public double GetTotalPrice()
        {
            return this.Product.Price * this.Quantity;
        }
    }
}