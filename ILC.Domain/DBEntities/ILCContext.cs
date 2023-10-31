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
    }
} 
