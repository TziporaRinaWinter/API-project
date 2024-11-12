using System;
using System.Collections.Generic;

namespace myModels
{

    public class Order
    {
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; }
        public PaymentCC pay {get; set;}

        public Order()
        {
            Items = new List<OrderItem>();
        }
    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class PaymentCC
    {
        public string num {get; set;}
        public string expires {get; set;}
        public string cvv {get; set;}
    }
}

