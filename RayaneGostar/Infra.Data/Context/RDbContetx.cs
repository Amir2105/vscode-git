using Microsoft.EntityFrameworkCore;

namespace RayaneGostar.Infra.Data.Context
{
    public class RDbContetx:DbContext
    {
        public RDbContetx(DbContextOptions<RDbContetx>options):base(options)
        {
            
        }
    }
}