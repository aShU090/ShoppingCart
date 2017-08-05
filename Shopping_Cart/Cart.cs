using System;
using System.Collections.Generic;
using System.Xml;

namespace Apttus.ShoppingCart.Product.Model
{
    public class Cart
    {
        static void Main(string[] args)
        {
            CartItem cart = new CartItem();
            List<decimal> PriceList = new List<decimal>();
            string fetch = "";
            List<Product> ProductList = new List<Product>();
            string id = "", name = "", description = "";
            decimal Price = 0m;
            Dictionary<string, Product> dictionary = new Dictionary<string, Product>();
            List<Product> value = new List<Product>();

            //Getting the list from XML File
            var doc = new XmlDocument();
            doc.Load(@"C:\Data\ShoppingCart\ShoppingCart\Product.xml");
            var root = doc.DocumentElement;
            var nodes = root.SelectNodes("Product");
            foreach (XmlNode node in nodes)
            {
                id = node.SelectSingleNode("id").InnerText;
                name = node.SelectSingleNode("Name").InnerText;
                description = node.SelectSingleNode("Description").InnerText;
                Price = Convert.ToDecimal(node.SelectSingleNode("price").InnerText);
                ProductList.Add(new Product { Id = id, Name = name, Description = description, Price = Price });
            }
            foreach (var temp in ProductList)
            {
                Console.WriteLine("id: " + temp.Id + "    " + "Name: " + temp.Name + "    " + "Description: " + temp.Description + "  " + "price: " + "Rs." + temp.Price);
            }
            for (int j = 0; j < ProductList.Count; j++)
            {
                dictionary.Add(ProductList[j].Id, ProductList[j]);
            }

            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < ProductList.Count; i++)
            {
                Console.WriteLine("Enter the product id");
                fetch = Console.ReadLine();
                Console.WriteLine("price of product is" + dictionary[fetch].Price);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("how many quantity do you want");
                int quant = Convert.ToInt32(Console.ReadLine());
                cart.Quantity = quant;
                dictionary[fetch].Quantity = cart.Quantity;
                Console.WriteLine("total price of product is" + cart.TotalPricePerProduct(dictionary[fetch], cart.Quantity));
                Console.WriteLine("---------------------------------------");

                //Adding items to the cart
                Console.WriteLine("Do you want to add in cart? y or n");
                string result = Console.ReadLine();
                if (result == "y")
                {
                    value.Add(dictionary[fetch]);
                }
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Do you want more product y or n");
                string fetch1 = Console.ReadLine();
                if (fetch1 == "y") continue;
                Console.WriteLine("-------------------------");
                Console.WriteLine("you have selected");
                Console.WriteLine("no. of item" + " " + value.Count);
                Console.WriteLine("item description");
                foreach (var temp1 in value)
                {

                    Console.WriteLine("id: " + temp1.Id + "      " + "Name: " + temp1.Name + "      " +
                                      "Description: " +
                                      temp1.Description + "      " + "Quantity: " + temp1.Quantity + "      " +
                                      "Price:" + "Rs." + temp1.Price + "      " + "TotalPrice: " + "Rs." +
                                      cart.TotalPricePerProduct(temp1, temp1.Quantity));
                    PriceList.Add(cart.TotalPricePerProduct(temp1, temp1.Quantity));
                }
                decimal Total_Price = 0m;
                for (int j = 0; j < PriceList.Count; j++)
                {
                    Total_Price += PriceList[j];
                }
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Your Total cost is:" + "Rs." + Total_Price + "/-");

                Console.ReadLine();
            }

        }
    }
}


