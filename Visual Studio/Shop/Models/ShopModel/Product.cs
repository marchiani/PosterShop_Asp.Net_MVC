using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.ShopModel
{
    public class Product
    {

        public int id { get; set; }
        [Required] 
        public string srcImg { get; set; }
        [Required] 
        public string heading { get; set; }
        [Required] 
        public int Price { get; set; }

        public string Size { get; set; }

        [Required]
        public string Categoriesname { get; set; }
        public Categories Categories { get; set; }

    }
}