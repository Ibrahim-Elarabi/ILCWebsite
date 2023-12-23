using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.Domain.DBEntities
{
    public class ILCContext : DbContext
    {
        public ILCContext(DbContextOptions<ILCContext> options) : base(options)
        {
        } 
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<SilderHomeSection> SilderHome { get; set; }
        public DbSet<AboutUsHomeSection> AboutUsHome { get; set; }
        public DbSet<ProductHome> ProductHome { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<AgentHome> AgentHome { get; set; }
        public DbSet<BlogHome> BlogHome { get; set; }
        public DbSet<StaffHome> StaffHome { get; set; }
        public DbSet<SupportHome> SupportHome { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductSpecification> ProductSpecification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(s=>s.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Service>()
                .HasOne(c => c.ParentService)
                .WithMany(s=>s.SubServices)
                .HasForeignKey(c => c.ParentServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            //Add Relation Between ProductImage And Product
            modelBuilder.Entity<ProductImage>()
                        .HasOne(ProductImage => ProductImage.Product)
                        .WithMany(product => product.Images)
                        .HasForeignKey(ProductImage => ProductImage.ProductId);

            //Add Relation Between ProductSpecification And Product
            modelBuilder.Entity<ProductSpecification>()
                        .HasOne(spec => spec.Product)
                        .WithMany(product => product.Specifications)
                        .HasForeignKey(spec => spec.ProductId);
            base.OnModelCreating(modelBuilder);
        }
    }
} 
