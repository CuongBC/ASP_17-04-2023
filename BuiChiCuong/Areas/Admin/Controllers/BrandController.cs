using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuiChiCuong.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        //
        // GET: /Admin/Brand/
        dbModelDataContext obj = new dbModelDataContext();
        public ActionResult Index(String SearchString)
        {
            var listBrand = obj.Brands.ToList();
            return View(listBrand);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brand objBrand)
        {
            try
            {
                if (objBrand.DisplayOrder == null || objBrand.Name == null || objBrand.ShowOnHomePage == null || objBrand.Slug == null)
                {
                    ViewData["Loi"] = "Vui long dien day du thong tin";
                    return this.Create();
                }
                else
                {
                    if (objBrand.ImageUpload != null)
                    {

                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        //tenhinh
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        //png
                        fileName = fileName + extension;
                        // tenhinh.png
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/brands"), fileName));
                    }

                    obj.Brands.InsertOnSubmit(objBrand);
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
            var objBrand = obj.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = obj.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }

        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objBrand = obj.Brands.Single(n => n.Id == objPro.Id);
            obj.Brands.DeleteOnSubmit(objBrand);
            obj.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = obj.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand objBrand)
        {
            try
            {

                if (objBrand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/brands"), fileName));
                }
                Brand obj_brand = new Brand();
                obj_brand = obj.Brands.Where(n => n.Id == objBrand.Id).Single();
                obj_brand.Name = objBrand.Name;
                if (objBrand.Avatar != null)
                {
                    obj_brand.Avatar = objBrand.Avatar;
                }
                obj_brand.Deleted = objBrand.Deleted;
                obj_brand.ShowOnHomePage = objBrand.ShowOnHomePage;
                obj_brand.DisplayOrder = objBrand.DisplayOrder;
                obj_brand.CreatedOnUtc = objBrand.CreatedOnUtc;
                obj_brand.UpdateddOnUtc = objBrand.UpdateddOnUtc;
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