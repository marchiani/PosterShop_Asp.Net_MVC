using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Shop.Models.ShopModel
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите свое имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите телефон")]
        public string Telephone { get; set; }

        public string Address { get; set; }
        
        public string TypeDelivery { get; set; }
        
        public string PostersThatOrser { get; set; }
        public DateTime DataSet { get; set; }
    }
}