﻿using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.Categories;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ILCWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(int? id =null)
        {
            try
            {
                
                var categories = id == null ? _unitOfWork._categoryRepo.Find(c => c.ParentCategoryId != null)
                                            : _unitOfWork._categoryRepo.Find(c => c.Id == id && c.ParentCategoryId != null);
                var newList = _mapper.Map<List<CategoryVM>>(categories);
                return View(newList.ToList());
            }
            catch (Exception ex)
            {
                return View(new List<CategoryVM>());
            }
        }
        public IActionResult Detials()
        {
            return View();
        }
        public PartialViewResult _Header()
        {
            var lst = _unitOfWork._categoryRepo.Find(c => c.ParentCategoryId == null,false,true,c=>c.SubCategories);
            var newList = _mapper.Map<List<CategoryVM>>(lst);
            return PartialView("_GetCategories", newList.ToList());   
        }
    }
}
