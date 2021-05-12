using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jewelrystoreAPI.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class JwelleryDbContext : DbContext
    {
        public JwelleryDbContext(DbContextOptions<JwelleryDbContext> options) : base(options)
        {

        }
        public DbSet<User> UserData { get; set; }
    }
}
