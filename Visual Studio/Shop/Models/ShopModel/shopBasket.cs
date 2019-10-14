using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;

namespace Shop.Models.ShopModel
{
    public class shopBasket
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }

        public Product Products { get; set; }
    }

}