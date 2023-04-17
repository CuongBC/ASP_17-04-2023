using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BuiChiCuong.Areas.Admin.Models;

namespace BuiChiCuong.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Admin/Order/
        dbModelDataContext obj = new dbModelDataContext();
        public ActionResult Index(String SearchString)
        {
            var listOrder = obj.Orders.Where(n => n.Status == 1).ToList();
            return View(listOrder);
        }

        public ActionResult Confirmed(String SearchString)
        {
            var listOrder = obj.Orders.Where(n=>n.Status == 0).ToList();
            return View(listOrder);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            List<OrderDetail> lstOrderDetail = obj.OrderDetails.Where(n => n.OrderId == id).ToList();
            var order = obj.Orders.Where(n => n.Id == id).FirstOrDefault();
            var user = obj.Users.Where(n=>n.Id == order.UserId).FirstOrDefault();
            List<DetailOrder> list_order = new List<DetailOrder>();
            foreach (var item in lstOrderDetail)
            {
                list_order.Add(new DetailOrder { Product = obj.Products.FirstOrDefault(n => n.Id == item.ProductId), Quantity = item.Quantity });
            }
            ViewBag.TenDonHang = order.Name;
            ViewBag.NguoiMua = user.LastName+" "+user.FistName;
            return View(list_order);
        }

        [HttpGet]
        public ActionResult Confirm(int id)
        {
            var order = obj.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public ActionResult Confirm(Order order)
        {
            var objOrder = obj.Orders.Where(n => n.Id == order.Id).FirstOrDefault();
            objOrder.Status = 0;
            obj.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var order = obj.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(Order order)
        {
            var objOrder = obj.Orders.Where(n => n.Id == order.Id).FirstOrDefault();
            objOrder.Status = 0;
            obj.Orders.DeleteOnSubmit(objOrder);
            obj.SubmitChanges();
            return RedirectToAction("Index");
        }
	}
}