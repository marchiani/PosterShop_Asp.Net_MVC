using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.ShopModel
{
    public class Product
    {
        
        public int id { get; set; }
        public string srcImg { get; set; }
        public string heading { get; set; }
        public int Price { get; set; }


        public string Categoriesname { get; set; }
        public int? CategoriesId { get; set; }
        public Categories Categories { get; set; }

    }
}