using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldPrice
{
    class Program : Gold
    {
        static void Main(string[] args)
        {
            int loggedInFlag = 0;

            Console.WriteLine("Enter Username : ");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter Password : ");
            string password = Console.ReadLine();

            string storedUserName = ConfigurationManager.AppSettings["UserName"];
            string storedPassword = ConfigurationManager.AppSettings["Password"];

            if (userName.Equals(storedUserName) && password.Equals(storedPassword))
            {
                loggedInFlag = 1;
            }

            if (loggedInFlag == 1)
            {
                Program gold = new Program();

                Console.WriteLine("Enter gold price : ");
                int price = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter gold weight : ");
                int weight = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter discount to be offered : ");
                int discount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Your gold price is : {gold.CalculateGoldPrice(price, weight, discount)}");
            }
            else
            {
                Console.WriteLine("Please enter a valid Username and Password");
            }

            Console.ReadLine();
        }

    }

    public class Gold
    {
        protected int CalculateGoldPrice(int price, int weight, int discount = 0)
        {
            int totalPrice = price * weight;
            int discountOnPrice = (int)Math.Round((double)(discount * totalPrice) / 100);
            return totalPrice - discountOnPrice;
        }
    }
}
