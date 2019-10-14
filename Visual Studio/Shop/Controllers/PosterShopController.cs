using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Shop.Models.ShopModel;

 
namespace Shop.Controllers
{
    public class PosterShopController : Controller
    {
        ShopContext db = new ShopContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Index(int page=1)
        {
            int pageSize = 3;
            var categories = db.Categorieses.ToList();
            IEnumerable<Product> productPerPages = db.Products
                .OrderBy(t => t.id)
                .Include(t => t.Categories)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo{PageNumber = page, PageSize = pageSize, TotalItem = db.Products.Count()};
            IndexViewModel ivm = new IndexViewModel{PageInfo = pageInfo, Products = productPerPages,  Categories = categories, ShopBasket = new shopBasket()};
            return View(ivm);
        }
        [HttpPost]
        public ActionResult Index(shopBasket shopBasket)
        {
            db.ShopBaskets.Add(shopBasket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProduxtToDatabase(int id, string size)
        {
            var product = new shopBasket() {ProductId = id, Size = size};
            db.ShopBaskets.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CountPoster()
        {

            return PartialView();
        }













        public ActionResult Logic_Deleting_product(int? id)
        {
            var obj = db.ShopBaskets.Where(t => t.Id == id);
            db.ShopBaskets.RemoveRange(obj);
            db.SaveChanges();
            return RedirectToAction("shopBasket");
        }

        
        public ActionResult SALE()
        {
            return View();
        }

        public ActionResult case_for_phone()
        {
            return View();
        }

        public ActionResult T_shirts()
        {
            return View();
        }

        [HttpGet]
        public ActionResult shopBasket()
        {
            var order = db.ShopBaskets.ToList();
            var products = db.Products.ToList();
            List<Product> list = new List<Product>();
            for (int i = 0; i < order.Count; i++)
            {
                for (int j = 0; j < products.Count; j++)
                {
                    if (order[i].ProductId == products[j].id)
                    {
                        list.Add(products[j]);
                        break;
                    }
                }
            }

            var tuple = new Tuple<ICollection<Product>, ICollection<shopBasket>>(list, order);
            return View(tuple);
        }

        [HttpGet]
        public ActionResult DelteStopData()
        {
            var items = db.ShopBaskets.ToList();
            db.ShopBaskets.RemoveRange(items);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Order()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {
            List<Product> list = new List<Product>();

            var orders = db.ShopBaskets.ToList();
            var products = db.Products.ToList();
            if (orders.Count < 1)
            {
                throw new HttpException(412, "Сперва закажи что-нибудь голупчик!");
            }
            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = 0; j < products.Count; j++)
                {
                    if (orders[i].ProductId == products[j].id)
                    {
                        products[j].Size = orders[i].Size;
                        list.Add(products[j]);
                        break;
                    }
                }
            }
            string orderString = "";
            foreach (var i in list)
            {
                orderString += $"{i.heading} {i.Size}, ";

            }
            order.PostersThatOrser = orderString;
            order.DataSet = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");

            }   
            return View();
        }


        

        

    }
    
}