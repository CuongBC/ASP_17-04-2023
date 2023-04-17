using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Admin/Category/
        dbModelDataContext obj = new dbModelDataContext();
        public ActionResult Index(String SearchString)
        {
            var listCategory = obj.Categories.ToList();
            return View(listCategory);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category objCategory)
        {
            try
            {
                if (objCategory.DisplayOrder == null || objCategory.Name == null || objCategory.ShowOnHomePage == null || objCategory.Slug == null)
                {
                    ViewData["Loi"] = "Vui long dien day du thong tin";
                    return this.Create();
                }
                else
                {
                    if (objCategory.ImageUpload != null)
                    {

                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        //tenhinh
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        //png
                        fileName = fileName + extension;
                        // tenhinh.png
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category"), fileName));
                    }

                    obj.Categories.InsertOnSubmit(objCategory);
                    obj.SubmitChanges();

                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCategory = obj.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCategory = obj.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objCategory = obj.Categories.Single(n => n.Id == objPro.Id);
            obj.Categories.DeleteOnSubmit(objCategory);
            obj.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategory = obj.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category objCategory)
        {
            try
            {

                if (objCategory.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                    string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objCategory.Avatar = fileName;
                    objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category"), fileName));
                }
                Category obj_Category = new Category();
                obj_Category = obj.Categories.Where(n => n.Id == objCategory.Id).Single();
                obj_Category.Name = objCategory.Name;
                if (objCategory.Avatar != null)
                {
                    obj_Category.Avatar = objCategory.Avatar;
                }
                obj_Category.Deleted = objCategory.Deleted;
                obj_Category.ShowOnHomePage = objCategory.ShowOnHomePage;
                obj_Category.DisplayOrder = objCategory.DisplayOrder;
                obj_Category.CreatedOnUtc = objCategory.CreatedOnUtc;
                obj_Category.UpdateddOnUtc = objCategory.UpdateddOnUtc;
                obj.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
	}
}