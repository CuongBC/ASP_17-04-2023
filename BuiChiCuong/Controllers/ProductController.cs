
using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        dbModelDataContext obj = new dbModelDataContext();
        public ActionResult Detail(int Id)
        {
            var objProuct = obj.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProuct);
        }
	}
}