using System;
using System.Security.AccessControl;

namespace Shop.Models.ShopModel
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItem { get; set; }

        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItem / PageSize); }

        }
    }
}