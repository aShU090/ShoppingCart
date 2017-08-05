using System.Collections.Generic;
using Apttus.ShoppingCart.Shopping_Cart.Model;

namespace Apttus.ShoppingCart.Shopping_Cart
{
    public class CartItem
    {
        public int Quantity { get; set; }
        private decimal Total;

        List<decimal> Price_list = new List<decimal>();
        public decimal UnitPrice(Product prod)
        {
            return prod.Price;
        }

        private decimal Total_Price = 0m;

        public decimal TotalPricePerProduct(Product prod, int Quantity)
        {
            Total = UnitPrice(prod) * Quantity;
            return Total;
        }
        public decimal TotalPrice(List<Product> product, int Quantity)
        {
            foreach (var prod in product)
            {
                Total = UnitPrice(prod) * Quantity;
                Price_list.Add(Total);
            }
            for (int j = 0; j < Price_list.Count; j++)
            {
                Total_Price += Price_list[j];
            }
            return Total_Price;
        }

    }
}

