using LoginAPIC_.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPIC_.Context
{
    public class Api_DBContext:DbContext
    {
        public Api_DBContext(DbContextOptions<DbContext> op)
            : base(op)
        {
               
        }
        public DbSet<User> Users { get; set; }
    }
}
