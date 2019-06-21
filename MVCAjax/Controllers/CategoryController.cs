using MVCAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCAjax.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _service;

        public CategoryController()
        {
            _service = new NorthwindEntities();
        }

        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public JsonResult Create(Category data)
        {
            Thread.Sleep(3000);
            JsonResultVM jr = new JsonResultVM();
            if (data.CategoryName == null)
            {
                jr.IsSuccess = false;
                jr.UserMessage = "Kategori Adı Boş Geçilemez";
            }
            else
            {
                try
                {
                    _service.Categories.Add(data);
                    _service.SaveChanges();

                    jr.IsSuccess = true;
                    jr.UserMessage = "Kategori başarıyla eklendi";
                }
                catch (Exception)
                {
                    jr.IsSuccess = false;
                    jr.UserMessage = "Kayıt İşlemi Hatası";
                    throw;
                }
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }

    }
}