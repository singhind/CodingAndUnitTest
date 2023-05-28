using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class Program
    {
        static double totalCoin = 0;
        static product p = new product();
        static int productIDorIndex = -1;

        static void Main(string[] args)
        {
            Start_Vendor_Program();

            Console.ReadLine();
            Console.ReadLine();
        }

        public static void Start_Vendor_Program()
        {
            Console.WriteLine("Valid Coin for this Machine ::  $0.05, $0.10, $0.25 only ");
            Console.WriteLine("\n");

            Console.WriteLine("Enter Coin : ");
            double newCoin = EnterMoreCoin(Console.ReadLine());
            totalCoin = totalCoin + newCoin;

            string ProductList = VenderMachine.ShowProductList();
            Console.WriteLine("Please select product by Product ID...");
            Console.WriteLine(ProductList);

            Console.WriteLine("\n");

            bool IsValidProductID = false;
            while (!IsValidProductID)
            {
                Console.WriteLine("Select product from above product list :: ");

                try { productIDorIndex = Convert.ToInt32(Console.ReadLine()); }
                catch { productIDorIndex = 0; }

                IsValidProductID = VenderMachine.IsValidProductID(productIDorIndex);
                if (!IsValidProductID) { Console.WriteLine("Select Product is invalid. Please select valid product.\n"); }
            }

            Console.WriteLine("\n");


            p = VenderMachine.SelectProduct(productIDorIndex);
            Console.WriteLine("Selected Product  is: " + p.Name + ", and Price is : $" + p.amount.ToString("0.00"));
            Console.WriteLine("\n\n");


            while (VenderMachine.IsRequiredCoin(p, totalCoin))
            {
                Console.WriteLine("Please insert $" + (p.amount - totalCoin).ToString("0.00") +
                                   " more coin, your selected Product price is $" + p.amount + " and you have inserted $" + totalCoin.ToString("0.00") + " coin only.");

                newCoin = EnterMoreCoin(Console.ReadLine());
                totalCoin = totalCoin + newCoin;
            }

            Start_Process_To_Provide_Product(p, totalCoin);

        }

        public static void Start_Process_To_Provide_Product(product p, double totalCoinValue)
        {
            double balance = totalCoinValue - p.amount;
            if (balance == 0) { Console.WriteLine("Please collect your Product. Thank you."); }
            if (balance > 0) { Console.WriteLine("Please collect your Product and remaining amount $" + balance.ToString("0.00") + " will return in your wallet. Thank you."); }
        }

        public static double EnterMoreCoin(string inputCoin)
        {
            double newCoin = VenderMachine.WantCoin(inputCoin);
            while (!VenderMachine.IsValidCoin(newCoin))
            {
                Console.WriteLine("Enter valid Coin : ");
                newCoin = VenderMachine.WantCoin(Console.ReadLine());
            }

            return newCoin;
        }
    }
}




