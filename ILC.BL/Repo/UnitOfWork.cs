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
        public IAppUserRepo _AppUserRepo { get; }

        public ISliderHomeService _sliderHomeService { get; }

        private readonly ICurrentUser _currentUser;
        public UnitOfWork(ILCContext context,
                          IAppUserRepo AppUserRepo,
                          ICurrentUser currentUser,
                          ISliderHomeService sliderHomeService)
        {
            this._context = context;
            _AppUserRepo = AppUserRepo;
            _currentUser = currentUser;
            _sliderHomeService = sliderHomeService;
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
            //if (model.ProfileImage != null)
            if (image != null)
            {
                var folder = "Images/Admin/Home";
                string uploadsFolder = Path.Combine("wwwroot", folder);
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
