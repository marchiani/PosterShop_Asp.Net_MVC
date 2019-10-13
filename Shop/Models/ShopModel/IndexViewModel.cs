using System.Collections.Generic;

namespace Shop.Models.ShopModel
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public PageInfo PageInfo { get; set; }
        
    }
}