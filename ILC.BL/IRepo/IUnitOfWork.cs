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
        int Complete();
        Task<int> CompleteAync();
        string UploadedFile(IFormFile image, string url);
    }
}
