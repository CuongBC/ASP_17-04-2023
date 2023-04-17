using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Controllers
{
    public class BrandController : Controller
    {
        //
        // GET: /Brand/
        dbModelDataContext obj = new dbModelDataContext();

        public ActionResult Index()
        {
            var lstBrand = obj.Brands.ToList();
            return View(lstBrand);
        }

        public ActionResult ProductBrand(int Id)
        {
            var listProduct = obj.Products.Where(n => n.BrandId == Id).ToList();
            return View(listProduct);
        }

        public ActionResult Brand()
        {
            var brand = from b in obj.Brands select b;
            return PartialView(brand);
        }
	}
}