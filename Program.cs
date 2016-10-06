using System;
using Bangazon.Customers;
using Bangazon.Orders;
using Bangazon.Payments;

namespace Bangazon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a customer and grab first/last name from first argument
            Customer firstCustomer = new Customer();
            firstCustomer.firstName = args[0].Split(new Char[] { ' ' })[0];
            firstCustomer.lastName = args[0].Split(new Char[] { ' ' })[1];
            firstCustomer.greet();

            // Create an order and add product from argument list
            Order firstOrder = new Order();
            for(int i = 1; i < args.Length - 1; i++)
            {
                firstOrder.addProduct(args[i]);
            }

            Console.WriteLine(firstOrder.listProducts());

            // Create a payment
            Payment payment = null;
            string mainEmailAddress = "steve@stevebrownlee.com";

            // Depending on the value of the last argument, assign
            // the payment variable to the correct derived class
            switch (args[args.Length - 1])
            {
                case "credit":
                    payment = new CreditCard(firstOrder)
                    {
                        bankName = "Amex",
                        accountNumber = "948587245092"
                    };
                    break;
                case "paypal":
                    payment = new Paypal(firstOrder)
                    {
                        email = mainEmailAddress,
                        password = "1234512345"
                    };
                    break;
                default:
                    break;
            }

            // Simplistic operation to calculate total order cost
            payment.amount = firstOrder.products.Count * 9.99;

            // Process the payment
            Console.WriteLine(payment.process());

            // Send confirmation email
            payment.confirm(mainEmailAddress);
        }
    }
}
