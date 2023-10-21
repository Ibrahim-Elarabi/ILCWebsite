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
        int Complete();
        Task<int> CompleteAync();
    }
}
