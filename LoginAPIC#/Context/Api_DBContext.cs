using LoginAPIC_.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPIC_.Context
{
    public class Api_DBContext:DbContext
    {
        public Api_DBContext(DbContextOptions<Api_DBContext> op)
            : base(op)
        {
               
        }
        public DbSet<User> Users { get; set; }
    }
}
