using eShopOnWeb.Model.Entities;
using eShopOnWeb.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopOnWeb.Areas.Administrator.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _service;
        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            IEnumerable<ProductCategory> productCategories = _service.GetAllProductCategory();
            return Json(productCategories);
        }
        [HttpPost]
        public JsonResult Add([FromBody] ProductCategory productCategory)
        {
            _service.InsertProductCategory(productCategory);
            return Json(productCategory);
        }
        [HttpPost]
        public JsonResult Update([FromBody] ProductCategory productCategory)
        {
            _service.UpdateProductCategory(productCategory);
            return Json(productCategory);
        }
        public JsonResult GetById(int id)
        {
            ProductCategory productCategory = _service.GetProductCategory(id);
            return Json(productCategory);
        }

        public JsonResult Delete(int id)
        {
            _service.DeleteProductCategory(id);
            return Json(id);
        }
    }
}
