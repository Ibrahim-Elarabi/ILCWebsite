﻿using ILC.BL.Interfaces.Admin;
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
        public IProductImageRepo _ProductImageRepo { get; }
        public IProductSpecificationRepo _ProductSpecificationRepo { get; } 
        public IAchievementRepo _AchievementRepo { get; }
        public IDownloadRepo _DownloadRepo { get; } 
        public IContactUsRepo _ContactUsRepo { get; }  
        public ICountryRepo _countryRepo { get; }
        public ICityRepo _cityRepo { get; }
        public IInquiryRepo _inquiryRepo { get; }


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
                          ICategoryRepo CategoryRepo,
                          IProductImageRepo productImageRepo,
                          IProductSpecificationRepo productSpecificationRepo,
                          IAchievementRepo achievementRepo,
                          IDownloadRepo downloadRepo,
                          IContactUsRepo contactUsRepo,
                          ICountryRepo countryRepo,
                          ICityRepo cityRepo,
                          IInquiryRepo inquiryRepo)
        {
            _context = context;
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
            _ProductImageRepo = productImageRepo;
            _ProductSpecificationRepo = productSpecificationRepo;
            _AchievementRepo = achievementRepo;
            _DownloadRepo = downloadRepo;
            _ContactUsRepo = contactUsRepo;
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
            _inquiryRepo = inquiryRepo;
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
        public string UploadedFile(IFormFile file ,string url)
        {
            string uniqueFileName = null; 
            if (file != null)
            { 
                string uploadsFolder = Path.Combine("wwwroot", url); 
                if (!Directory.Exists(url))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
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
                        if (_currentUser != null && _currentUser.UserId != null)
                        {
                            entry.Entity.CreatedById = int.Parse(_currentUser.UserId);
                        }
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        if (_currentUser != null && _currentUser.UserId != null)
                        {
                            entry.Entity.LastModifiedById = int.Parse(_currentUser.UserId);
                        }
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
