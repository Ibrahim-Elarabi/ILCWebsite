using ILC.BL.Interfaces.Admin;
using ILC.BL.IRepo;
using ILC.Domain.DBCommon;
using ILC.Domain.DBEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public IProductHomeRepo _productHomeRepo { get; }
        public ISliderHomeService _sliderHomeService { get; }
        public IServiceHomeRepo _serviceHomeRepo { get; }
        public IAboutUsHomeService _aboutUsHomeService { get; } 
        public IAgentHomeRepo _agentHomeRepo { get; }
        public IBlogHomeRepo _blogHomeRepo { get; }
        public IStaffHomeRepo _staffHomeRepo { get; }
        public ISupportHomeRepo _supportHomeRepo { get; }
        public ICategoryRepo _categoryRepo { get; }
        private readonly ICurrentUser _currentUser;
        public UnitOfWork(ILCContext context,
                          IAppUserRepo AppUserRepo,
                          ICurrentUser currentUser,
                          ISliderHomeService sliderHomeService,
                          IProductHomeRepo productHomeRepo,
                          IAboutUsHomeService aboutUsHomeService,
                          IServiceHomeRepo serviceHomeRepo,
                          IAgentHomeRepo agentHomeRepo,
                          IBlogHomeRepo blogHomeRepo,
                          IStaffHomeRepo staffHomeRepo,
                          ISupportHomeRepo supportHomeRepo,
                          ICategoryRepo CategoryRepo)
        {
            this._context = context;
            _appUserRepo = AppUserRepo;
            _productHomeRepo = productHomeRepo;
            _currentUser = currentUser;
            _sliderHomeService = sliderHomeService;
            _aboutUsHomeService = aboutUsHomeService;
            _serviceHomeRepo = serviceHomeRepo;
            _agentHomeRepo = agentHomeRepo;
            _blogHomeRepo = blogHomeRepo;
            _staffHomeRepo = staffHomeRepo;
            _supportHomeRepo = supportHomeRepo;
            _categoryRepo = CategoryRepo;
        }
        public int Complete()
        {
            try
            {
                AddLogs();
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
                AddLogs();
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
        public string UploadedFile(IFormFile image ,string url)
        {
            string uniqueFileName = null; 
            if (image != null)
            { 
                string uploadsFolder = Path.Combine("wwwroot", url); 
                if (!Directory.Exists(url))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                uniqueFileName = $"/{url}/{uniqueFileName}";
            }
            return uniqueFileName;
        } 
        private void AddLogs()
        {
            foreach (var entry in _context.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = int.Parse(_currentUser.UserId); 
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedById = int.Parse(_currentUser.UserId);
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
