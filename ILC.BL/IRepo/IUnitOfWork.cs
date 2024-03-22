using ILC.BL.Interfaces.Admin;
using ILC.BL.Repo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.IRepo
{
    public interface IUnitOfWork : IDisposable
    { 
        IAppUserRepo _appUserRepo { get; }
        IProductHomeRepo _productHomeRepo { get; } 
        ISliderHomeService _sliderHomeService { get; }
        IAboutUsHomeService _aboutUsHomeService { get; }
        IServiceHomeRepo _serviceHomeRepo { get; }
        IAgentHomeRepo _agentHomeRepo { get; }
        IBlogHomeRepo _blogHomeRepo { get; }
        IStaffHomeRepo _staffHomeRepo { get; }
        ISupportHomeRepo _supportHomeRepo { get; }
        ICategoryRepo _categoryRepo { get; }
         IProductImageRepo _ProductImageRepo { get; }
         IProductSpecificationRepo _ProductSpecificationRepo { get; }
        IAchievementRepo _AchievementRepo { get; }
        IDownloadRepo _DownloadRepo { get; }
        IContactUsRepo _ContactUsRepo { get; } 
        ICountryRepo _countryRepo { get; }
        ICityRepo _cityRepo { get; }
        IInquiryRepo _inquiryRepo { get; }
        ISimilarProductRepo _similarProductRepo { get; }
        
        int Complete();
        Task<int> CompleteAync(); 
        string UploadedFile(IFormFile file, string url);
    }
}
