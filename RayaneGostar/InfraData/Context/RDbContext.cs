using Microsoft.EntityFrameworkCore;
using RayaneGostar.Domain.Models.Account;

namespace RayaneGostar.InfraData.Context
{
    public class RDbContext:DbContext
    {
        public RDbContext(DbContextOptions<RDbContext> options):base(options)
        {
            
        }
        #region User
        public DbSet<User> Users { get; set; }
        #endregion
    }
}