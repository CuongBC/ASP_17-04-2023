using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Admin/User/
        dbModelDataContext obj = new dbModelDataContext();
        public ActionResult Index(String SearchString)
        {
            var listUser = obj.Users.ToList();
            return View(listUser);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User objUser)
        {
            try
            {
                objUser.Password = GetMD5(objUser.Password);
                obj.Users.InsertOnSubmit(objUser);
                obj.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objUser = obj.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objUser = obj.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }

        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objUser = obj.Users.Single(n => n.Id == objPro.Id);
            obj.Users.DeleteOnSubmit(objUser);
            obj.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objUser = obj.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Edit(int id, User objUser)
        {
            try
            {
                User obj_User = new User();
                obj_User = obj.Users.Where(n => n.Id == objUser.Id).Single();
                obj_User.FistName = objUser.FistName;
                obj_User.LastName = objUser.LastName;
                obj_User.IsAdmin = objUser.IsAdmin;
                obj_User.Password = GetMD5(objUser.Password);
                obj_User.Email = objUser.Email;
                obj.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
	}
}