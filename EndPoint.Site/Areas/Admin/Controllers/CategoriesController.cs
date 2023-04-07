﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebStoreCore.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class CategoriesController : Controller
    {

        private readonly IProductFacad _productFacad;

        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }


        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId, string Name)
        {
            var result = _productFacad.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }
    }
}
