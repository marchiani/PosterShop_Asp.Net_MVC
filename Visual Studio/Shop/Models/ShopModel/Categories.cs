using System.Collections.Generic;

namespace Shop.Models.ShopModel
{
    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<Product> Products { get; set; }

        public Categories()
        {
            Products = new List<Product>();
        }
    }
}