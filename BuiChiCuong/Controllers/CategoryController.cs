using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        dbModelDataContext obj = new dbModelDataContext();
        public ActionResult Index()
        {
            var lstCategory = obj.Categories.ToList();
            return View(lstCategory);
        }

        public ActionResult ProductCategory(int Id)
        {
            var listProduct = obj.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }

        public ActionResult Category()
        {
            var Category = from b in obj.Categories select b;
            return PartialView(Category);
        }
	}
}