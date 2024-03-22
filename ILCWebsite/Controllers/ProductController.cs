using AutoMapper;
using ILC.BL.IRepo;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Repo;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ILCWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork,
                                    IWebHostEnvironment hostingEnvironment,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public IActionResult Index(int? categoryId)
        {
            List<ProductHome>lst = new List<ProductHome>();   
            try
            {
                if (categoryId == null)
                {
                    lst = _unitOfWork._productHomeRepo.GetAll().ToList();
                }
                else
                { 
                    lst = _unitOfWork._productHomeRepo.Find(p => p.CategoryId == categoryId).ToList(); 
                } 
                var newList = _mapper.Map<List<ProductHomeVM>>(lst);
                return View(newList.ToList());
            }
            catch (Exception ex)
            {
                return View(new List<ProductHomeVM>());
            } 
        }
        public IActionResult Details(int id)
        {
            var product = _unitOfWork._productHomeRepo
                   .Find(d => d.Id == id)
                   .Include(p => p.Images)
                   .Include(p => p.Specifications) 
                   .FirstOrDefault(); 

            var similarProductsIds = _unitOfWork._similarProductRepo
                                    .Find(d => d.ProductId == id)
                                    .Select(d => d.SimilarProductId)
                                    .ToList();

            var similarProducts = _unitOfWork._productHomeRepo
                   .Find(d => similarProductsIds.Contains(d.Id))
                   .Include(p => p.Images)
                   .ToList(); 
            var similarProductsVM = _mapper.Map<List<ProductHomeVM>>(similarProducts);
             
            var result = _mapper.Map<ProductHomeVM>(product);
            result.SimilarProducts = similarProductsVM;
            return View(result);
        } 
    }
}
