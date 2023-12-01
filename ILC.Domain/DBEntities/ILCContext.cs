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
        public DbSet<ServiceHome> ServiceHome { get; set; }
        public DbSet<AgentHome> AgentHome { get; set; }
        public DbSet<BlogHome> BlogHome { get; set; }
        public DbSet<StaffHome> StaffHome { get; set; }
        public DbSet<SupportHome> SupportHome { get; set; }
        public DbSet<Category> Category { get; set; }
    }
} 
