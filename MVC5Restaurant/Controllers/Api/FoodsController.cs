using MVC5Restaurant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC5Restaurant.Controllers.Api
{
    public class FoodsController : ApiController
    {
        private ApplicationDbContext _context;

        public FoodsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageFood)]
        public void DeleteFood(int id)
        {
            var foodInDb = _context.Foods.SingleOrDefault(f => f.Id == id);

            if (foodInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                //var foodController = DependencyResolver.Current.GetService<MVC5Restaurant.Controllers.FoodsController>();
                //foodController.UnsetFile(id);

                var fullPathToPhoto = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Images/" + foodInDb.File);

                if (System.IO.File.Exists(fullPathToPhoto))
                {
                    System.IO.File.Delete(fullPathToPhoto);
                }

                _context.Foods.Remove(foodInDb);
                _context.SaveChanges();
            }
        }
    }
}
