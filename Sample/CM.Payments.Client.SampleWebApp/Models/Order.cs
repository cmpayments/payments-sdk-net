using System;
using System.Collections.Generic;
using System.Linq;

namespace CM.Payments.Client.SampleWebApp.Models
{
    public enum Status
    {
        Open = 1,
        Cancelled = 2,
        Paid = 3
    }

    public class Order
    {
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
        public DateTime Created { get; set; }
        public int Id { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public DateTime? PaidOn { get; set; }
        public Status Status { get; set; }

        public double GetTotalCost()
        {
            var total = this.OrderItems.Sum(e => e.GetTotalPrice());
            return double.Parse(total.ToString("F"));
        }
    }
}