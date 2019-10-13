using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Shop.Models;
using Shop.Models.ShopModel;

namespace Shop.Controllers
{
    public class Categori_for_posterController : Controller
    {
        ShopContext db = new ShopContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ActionResult Кухня(int page = 1)
        {
            int pageSize = 3;
            var categories = db.Categorieses.ToList();
            string name1 = categories[0].name;
            IEnumerable<Product> productPerPages = db.Products
                .Include(t => t.Categories)
                .Where(t => t.Categoriesname == name1)
                .OrderBy(t => t.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItem = db.Products.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = productPerPages, Categories = categories };
            return View(ivm);
        }

        public ActionResult Графика(int page = 1)
        {
            int pageSize = 3;
            var categories = db.Categorieses.ToList();
            string name1 = categories[1].name;
            IEnumerable<Product> productPerPages = db.Products
                .Include(t => t.Categories)
                .Where(t => t.Categoriesname == name1)
                .OrderBy(t => t.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItem = db.Products.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = productPerPages, Categories = categories };
            return View(ivm);
        }



        public ActionResult Винтаж(int page = 1)
        {
            int pageSize = 3;
            var categories = db.Categorieses.ToList();
            string name1 = categories[2].name;
            IEnumerable<Product> productPerPages = db.Products
                .Include(t => t.Categories)
                .Where(t => t.Categoriesname == name1)
                .OrderBy(t => t.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItem = db.Products.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = productPerPages, Categories = categories };
            return View(ivm);
        }



        public ActionResult Море(int page = 1)
        {
            int pageSize = 3;
            var categories = db.Categorieses.ToList();
            string name1 = categories[3].name;
            IEnumerable<Product> productPerPages = db.Products
                .Include(t => t.Categories)
                .Where(t => t.Categoriesname == name1)
                .OrderBy(t => t.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItem = db.Products.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = productPerPages, Categories = categories };
            return View(ivm);
        }



        public ActionResult Природа(int page = 1)
        {
            int pageSize = 3;
            var categories = db.Categorieses.ToList();
            string name1 = categories[4].name;
            IEnumerable<Product> productPerPages = db.Products
                .Include(t => t.Categories)
                .Where(t => t.Categoriesname == name1)
                .OrderBy(t => t.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItem = db.Products.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = productPerPages, Categories = categories };
            return View(ivm);
        }



        public ActionResult Путешествия(int page = 1)
        {
            int pageSize = 3;
            var categories = db.Categorieses.ToList();
            string name1 = categories[5].name;
            IEnumerable<Product> productPerPages = db.Products
                .Include(t => t.Categories)
                .Where(t => t.Categoriesname == name1)
                .OrderBy(t => t.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItem = db.Products.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Products = productPerPages, Categories = categories };
            return View(ivm);
        }




    }
}