using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OrderSumaryProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
      
            Console.WriteLine("Enter cliente data ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            string stringClientBirthDate = Console.ReadLine();
            DateTime clientBirthDate = DateTime.Parse(stringClientBirthDate);
            

            Client theClient = new Client(clientName, clientEmail, clientBirthDate);
            
            Console.WriteLine("Enter Oder Data:");
            Console.Write("Status: ");
            string stringOderStatus = Console.ReadLine();
            OrderStatus orderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), stringOderStatus);
            Console.Write("Hou many items to this order? ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Order theOrder = new Order(orderStatus, theClient);
           
            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                int productQuantity = Convert.ToInt32(Console.ReadLine());

                Product theProduct = new Product(productName, productPrice);
                OrderItem theOrderItem = new OrderItem(productQuantity, productPrice, theProduct);
                theOrder.AddItem(theOrderItem);
                
            }

           string summary = theOrder.OrderSummary();
           Console.WriteLine(summary);
            //Console.WriteLine($"{theClient.Name} - {theClient.Email} - {theClient.BirthDate}");
            Console.ReadLine();

        }
    }
}
