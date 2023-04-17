using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/
        dbModelDataContext obj = new dbModelDataContext();


        public ActionResult Index()
        {
            return View();
        }
	}
}