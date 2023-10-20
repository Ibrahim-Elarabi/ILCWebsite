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
    }
} 
