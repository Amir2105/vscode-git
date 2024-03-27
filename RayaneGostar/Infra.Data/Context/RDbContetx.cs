using Microsoft.EntityFrameworkCore;
using RayaneGostar.Domain.Models.Account;

namespace RayaneGostar.Infra.Data.Context
{
    public class RDbContetx : DbContext
    {
        public RDbContetx(DbContextOptions<RDbContetx> options) : base(options)
        {

        }
        #region User
        public DbSet<User> Users { get; set; }
        #endregion
    }
}