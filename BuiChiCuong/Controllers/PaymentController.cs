using BuiChiCuong.Context;
using BuiChiCuong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/
        dbModelDataContext obj = new dbModelDataContext();

        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                Order objOrder = new Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("yyyyMMddmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                obj.Orders.InsertOnSubmit(objOrder);
                obj.SubmitChanges();

                int intOrderId = objOrder.Id;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail objOrderDetail = new OrderDetail();
                    objOrderDetail.Quantity = item.Quantity;
                    objOrderDetail.OrderId = intOrderId;
                    objOrderDetail.ProductId = item.Product.Id;
                    lstOrderDetail.Add(objOrderDetail);
                }
                obj.OrderDetails.InsertAllOnSubmit(lstOrderDetail);
                obj.SubmitChanges();
                Session["cart"] = null;
                Session["count"] = 0;
            }
            return View();
        }
	}
}