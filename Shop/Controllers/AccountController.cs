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
        public ActionResult AddPosters()
        {

            var AllProduct = db.Products.ToList();
            var tuple = new Tuple<ICollection<Product>, Product>(AllProduct, new Product());
            return View(tuple);
        }


        [HttpPost]
        public ActionResult AddPosters(Product product)
        {

            string cotegori = $"/Content/img/Posters/{product.srcImg}.jpg";
            product.srcImg = cotegori;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("AddPosters");
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







        [HttpPost]
        public ActionResult CustomerSerch(string name)
        {
            var allorder = db.Orders.Where(a => a.Name == name).ToList();
            return PartialView(allorder);
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
                    Admin admin = null;
                    
                        admin = db.Admins.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);

                    

                    if (admin != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
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
            public ActionResult Register(Register model)
            {
                if (ModelState.IsValid)
                {
                    Admin admin = null;
                    
                        admin = db.Admins.FirstOrDefault(u => u.Email == model.Name);
                    

                    if (admin == null)
                    {
                        // создаем нового пользователя
                        
                            db.Admins.Add(new Admin {Email = model.Name, Password = model.Password});
                            db.SaveChanges();

                            admin = db.Admins.Where(u => u.Email == model.Name && u.Password == model.Password)
                                .FirstOrDefault();
                        

                        // если пользователь удачно добавлен в бд
                        if (admin != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
            }
        }
    }