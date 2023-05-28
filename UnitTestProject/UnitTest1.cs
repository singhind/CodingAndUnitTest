using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            double coinValue = 0.10;
            bool expexted = true;

            //Act
            bool status = CodingTest.VenderMachine.IsValidCoin(coinValue);

            //Assert
            Assert.AreEqual(expexted, status);

        }

        [TestMethod]
        public void _IsValidCoin()
        {
            //Arrange
            double coinValue = 0.10;
            bool expexted = true;

            //Act
            bool status = CodingTest.VenderMachine.IsValidCoin(coinValue);

            //Assert
            Assert.AreEqual(expexted, status);

        }

        [TestMethod]
        public void _SelectProduct()
        {
            //Arrange
            List<CodingTest.product> products = CodingTest.VenderMachine.GetProductList();
            

            int inputProductID = 2;
            CodingTest.product expextedOutput = products[inputProductID-1];

            //Act
            CodingTest.product output = CodingTest.VenderMachine.SelectProduct(inputProductID);

            //Assert
            var js = new JavaScriptSerializer();
            Assert.AreEqual(js.Serialize(expextedOutput), js.Serialize(output));

            
        }

        [TestMethod]
        public void _ShowProductList()
        {
            //Arrange
            List<CodingTest.product> products = CodingTest.VenderMachine.GetProductList();

            string inputProducts = "";
            foreach (var p in products)
            {
                inputProducts = inputProducts + "ProductID : " + p.ID + ", Name : " + p.Name + ", Price : " + p.amount.ToString("0.00") + "\n";
            }

            string outputProducts = CodingTest.VenderMachine.ShowProductList();

            //Act
            //bool status = CodingTest.VenderMachine.IsValidCoin(coinValue);

            //Assert
            var js = new JavaScriptSerializer();
            Assert.AreEqual(js.Serialize(inputProducts), js.Serialize(outputProducts));

        }

        [TestMethod]
        public void _IsValidProductID()
        {
            //Arrange
            int input = 1;
            bool expexted = true;

            //Act
            bool status = CodingTest.VenderMachine.IsValidProductID(input);

            //Assert
            Assert.AreEqual(expexted, status);

        }

        [TestMethod]
        public void _WantCoin()
        {
            #region Test-1

            //Arrange
            string coinValue = "0.10"; double expexted = 0.10;

            //Act
            double output = CodingTest.VenderMachine.WantCoin(coinValue);

            //Assert
            Assert.AreEqual(expexted, output);

            #endregion

            #region Test-2

            //Arrange
            coinValue = "0.20"; expexted = 0.20;

            //Act
            output = CodingTest.VenderMachine.WantCoin(coinValue);

            //Assert
            Assert.AreEqual(expexted, output);

            #endregion

            #region Test-3

            //Arrange
            coinValue = "xyz"; expexted = 0;

            //Act
            output = CodingTest.VenderMachine.WantCoin(coinValue);

            //Assert
            Assert.AreEqual(expexted, output);

            #endregion

            #region Test-4

            //Arrange
            coinValue = "AB"; expexted = 0;

            //Act
            output = CodingTest.VenderMachine.WantCoin(coinValue);

            //Assert
            Assert.AreEqual(expexted, output);

            #endregion

        }

        [TestMethod]
        public void _IsRequiredCoin()
        {
            //Arrange
            List<CodingTest.product> products = CodingTest.VenderMachine.GetProductList();
            CodingTest.product p = products[0];

            double inputCoin = 0.10; bool expexted = true;

            //Act
            bool status = CodingTest.VenderMachine.IsRequiredCoin(p, inputCoin);

            //Assert
            Assert.AreEqual(expexted, status);

        }

        //[TestMethod]
        //public void _Start_Vendor_Program()
        //{
        //    //Arrange
        //    List<CodingTest.product> products = CodingTest.VenderMachine.GetProductList();
        //    CodingTest.product p = products[0];

        //    double[] inputCoin = { 0.10, 0.25, 0.05 }; bool expexted = true;
        //    int productID = 2;

        //    //Act
        //    bool status = CodingTest.VenderMachine.IsRequiredCoin(p, inputCoin);

        //    //CodingTest.Program.Start_Vendor_Program();

        //    //Assert
        //    Assert.AreEqual(expexted, status);

        //}

    }
}
