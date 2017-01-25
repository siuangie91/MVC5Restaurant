using MVC5Restaurant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5Restaurant.Controllers
{
    public class FoodsController : Controller
    {
        private ApplicationDbContext _context;

        public FoodsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Foods
        // custom route name to Menu
        [Route("Menu")]
        public ActionResult Index()
        {
            var food = _context.Foods.ToList();

            if(User.IsInRole(RoleName.CanManageFood))
            {
                return View("Menu", food);
            }
            else
            {
                return View("ReadOnlyMenu", food);
            }
        }

        [Route("Gallery")]
        public ActionResult Gallery()
        {
            var food = _context.Foods.ToList();

            if (User.IsInRole(RoleName.CanManageFood))
            {
                return View("Gallery", food);
            }
            else
            {
                return View("ReadOnlyGallery", food);
            }
        }

        [Authorize(Roles = RoleName.CanManageFood)]
        public ActionResult New()
        {
            return View("FoodForm");
        }

        [Authorize(Roles = RoleName.CanManageFood)]
        public ActionResult Edit(int id)
        {
            var food = _context.Foods.SingleOrDefault(f => f.Id == id);

            if (food == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("FoodForm", food); //specify the view you want to return
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Id,Name,Price,Description")]Food food, HttpPostedFileBase File)
        {
            if (food.Id == 0)
            {
                /*Comment out check for ModelState.IsValid because Id is included in the Bind(),
                but for new Food item, Id is null, so ModelState will always be invalid!*/
                //if(ModelState.IsValid)
                //{
                if (File != null && File.ContentLength > 0)
                {
                    var filename = Path.GetFileNameWithoutExtension(File.FileName);
                    var extension = Path.GetExtension(File.FileName);

                    food.File = String.Concat(filename, extension);

                    var path = Path.Combine(Server.MapPath("~/Content/Images"), filename + extension);

                    File.SaveAs(path);
                }
                //}

                _context.Foods.Add(food);
            }
            else
            {
                var foodInDb = _context.Foods.Single(f => f.Id == food.Id);

                foodInDb.Name = food.Name;
                foodInDb.Price = food.Price;
                foodInDb.Description = food.Description;

                if (ModelState.IsValid)
                {
                    if (File != null && File.ContentLength > 0)
                    {
                        var filename = Path.GetFileNameWithoutExtension(File.FileName);
                        var extension = Path.GetExtension(File.FileName);

                        foodInDb.File = String.Concat(filename, extension);

                        var path = Path.Combine(Server.MapPath("~/Content/Images"), filename + extension);

                        File.SaveAs(path);
                    }
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Foods");
        }

        //Moved to inside the api delete method
        //[HttpPost]
        //public void UnsetFile(int id)
        //{
        //    var foodInDb = _context.Foods.SingleOrDefault(f => f.Id == id);

        //    var fullPathToPhoto = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Images/" + foodInDb.File);

        //    if (System.IO.File.Exists(fullPathToPhoto))
        //    {
        //        System.IO.File.Delete(fullPathToPhoto);
        //    }
        //}
    }
}