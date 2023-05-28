using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public static class VenderMachine
    {
        public static List<product> GetProductList()
        {
            //cola for $1.00, chips for $0.50, and candy for $0.65.

            List<product> products = new List<product>();
            product p = new product();
            p.ID = 1;
            p.Name = "cola";
            p.amount = 1.00;
            products.Add(p);

            p = new product();
            p.ID = 2;
            p.Name = "chips";
            p.amount = 0.50;
            products.Add(p);

            p = new product();
            p.ID = 3;
            p.Name = "candy";
            p.amount = 0.65;
            products.Add(p);


            return products;

        }

        public static product SelectProduct(int productID)
        {
            //cola for $1.00, chips for $0.50, and candy for $0.65.

            if (productID <= 0) { return null; }

            List<product> products = GetProductList();
            return products[productID - 1];

        }

        public static string ShowProductList()
        {
            List<product> products = GetProductList();

            string ProductList = "";
            foreach (var p in products)
            {
                ProductList = ProductList + "ProductID : " + p.ID + ", Name : " + p.Name + ", Price : " + p.amount.ToString("0.00") + "\n";
            }

            return ProductList;
        }

        public static bool IsValidCoin(double coinValue)
        {
            bool isValid = false;
            //(nickels(1/20 $), dimes (1/10 $), and  quarters(1 / 4 $)) and reject invalid ones(pennies(1 / 100 $)).
            double[] validCoins = { 0.05, 0.10, 0.25 };

            foreach (var coin in validCoins)
            {
                if (coinValue == coin) { isValid = true; break; }
            }


            return isValid;
        }

        public static bool IsValidProductID(int productID)
        {
            if (productID > 0 && productID <= VenderMachine.GetProductList().Count) { return true; }
            return false;
        }

        public static double WantCoin(string inputCoin = "0")
        {
            double newCoin = 0;

            try { newCoin = Convert.ToDouble(inputCoin); }
            catch { newCoin = 0; }

            return newCoin;
        }

        public static bool IsRequiredCoin(product p, double totalCoin = 0)
        {
            if ((totalCoin - p.amount) < 0) { return true; }
            return false;
        }

    }

    public class product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double amount { get; set; }
    }

}
