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
        IAppUserRepo _AppUserRepo { get; } 
        ISliderHomeService _sliderHomeService { get; }
        int Complete();
        Task<int> CompleteAync();
        string UploadedFile(IFormFile image, string url);
    }
}
