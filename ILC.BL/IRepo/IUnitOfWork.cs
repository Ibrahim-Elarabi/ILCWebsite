using ILC.BL.Interfaces.Admin;
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
        IProductHomeSectionRepo _productHomeSectionRepo { get; } 
        ISliderHomeService _sliderHomeService { get; }
        IAboutUsHomeService _aboutUsHomeService { get; }
        int Complete();
        Task<int> CompleteAync();
        string UploadedFile(IFormFile image, string url);
    }
}
