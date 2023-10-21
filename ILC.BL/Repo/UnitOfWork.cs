using ILC.BL.IRepo;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Repo
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ILCContext _context; 
        public IAppUserRepo _appUserRepo { get; } 
        public IProductHomeSectionRepo _productHomeSectionRepo { get; }
        public UnitOfWork(ILCContext context,
                          IAppUserRepo AppUserRepo,
                          IProductHomeSectionRepo productHomeSectionRepo)
        {
            this._context = context;
            _appUserRepo = AppUserRepo;
            _productHomeSectionRepo = productHomeSectionRepo;
        }
        public int Complete()
        {
            try
            {
                int result = _context.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public async Task<int> CompleteAync()
        {
            try
            {
                int result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
