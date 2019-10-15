using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Shop.Models;
using System.Web.Security;
using Shop.Models.ShopModel;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {

        ShopContext db = new ShopContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddPosters()
        {

            //var AllProduct = db.Products.ToList();
            //var tuple = new Tuple<ICollection<Product>, Product>(AllProduct, new Product());
            return View();
        }


        [HttpPost]
        public ActionResult AddPosters(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("AddPosters");
            }

            return View();
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = db.Products.Where(t => t.id == id).ToList();
            db.Products.RemoveRange(product);
            db.SaveChanges();
            return View();
        }

        public ActionResult PosterSearch(string name)
        {
            var allorder = db.Products.Where(a => a.heading == name).ToList();
            return PartialView(allorder);
            
        }


        public ActionResult AllPoster()
        {
            var allorder = db.Products.ToList();
            return PartialView(allorder);

        }

        public ActionResult AllCategories()
        {
            var allCategorieses = db.Categorieses.ToList();
            return PartialView(allCategorieses);

        }


        [HttpPost]
        public ActionResult CustomerSerch(string name)
        {
            var allorder = db.Orders.Where(a => a.Name == name).ToList();
            return PartialView(allorder);
        }


        [Authorize]
        public ActionResult AllOrder()
        {
            var or = db.Orders.ToList();
            return View(or);
        }



        public ActionResult CRM()
        {
            var order = db.Orders.ToList();
            return View(order);
        }












        public ActionResult Login()
        {
            return View();
        }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(Login model)
            {
                if (ModelState.IsValid)
                {
                    // поиск пользователя в бд
                    User user = null;
                    
                        user = db.Admins.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);

                    

                    if (user != null)
                    {
                    //FormsAuthentication.RedirectFromLoginPage(model.Name, false);


                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    //FormsAuthentication.RedirectFromLoginPage(model.Name, true);
                    return RedirectToAction("CheckAuto", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                    }
                }

                return View(model);
            }

            public ActionResult Register()
            {
                return View();
            }
            [

            HttpPost]
            [ValidateAntiForgeryToken]
            [Authorize]
            public ActionResult Register(Register model)
            {
                if (ModelState.IsValid)
                {
                    User user = null;
                    
                        user = db.Admins.FirstOrDefault(u => u.Email == model.Name);
                    

                    if (user == null)
                    {
                        // создаем нового пользователя
                        
                            db.Admins.Add(new User {Email = model.Name, Password = model.Password});
                            db.SaveChanges();

                            user = db.Admins.Where(u => u.Email == model.Name && u.Password == model.Password)
                                .FirstOrDefault();
                        

                        // если пользователь удачно добавлен в бд
                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            return RedirectToAction("Index", "PosterShop");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    }
                }

                return View(model);
            }

            public ActionResult Logoff()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "PosterShop");
            }
        public string CheckAuto()
        {

            string result = "Пользователь не авторизован";
            if (User.Identity.IsAuthenticated)
            {
                result = $"Пользователь авторизован {User.Identity.Name}";
            }

            return HttpContext.User.Identity.Name;
        }
    }
}