using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSumaryProject
{
    internal class Order
    {
        public DateTime Moment { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; }
        public Client Client { get; set; } 
        public List<OrderItem> OrderItems = new List<OrderItem>();

        public Order(OrderStatus status, Client client)
        {
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItems.Remove(item);
        }

        private double Total()
        {
            double total = 0.0;
            foreach (OrderItem item in OrderItems)
            {
                total += item.Subtotal();
            }

            return total;
        }

    

        public string OrderSummary()
        {
            StringBuilder summary = new StringBuilder();

            summary.AppendLine("Order Summary:");
            summary.AppendLine($"Order moment:\t{Moment}");
            summary.AppendLine($"Order status{Status}");
            summary.AppendLine($"Client: {Client.Name} - ({Client.BirthDate.Year}) - {Client.Email}");
            summary.AppendLine($"Order Item(s):");
            foreach (var orderItem in OrderItems)
            {
                summary.AppendLine($"Name: {orderItem.Product.Name}, Quantity: {orderItem.Quantity}, Subtotal: {orderItem.Subtotal():C}");
            }
            summary.AppendLine($"Total price: {Total():C}");
        
            string finalSummary = summary.ToString();
            return finalSummary;
        }






    }
}
