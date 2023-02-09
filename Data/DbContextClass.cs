using Microsoft.EntityFrameworkCore;
using simple_crud_net_6.Models;

namespace simple_crud_net_6.Data
{
    public class DbContextClass : DbContext
    {
        private readonly IConfiguration Configuration;

         public DbContextClass(DbContextOptions<DbContextClass> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}