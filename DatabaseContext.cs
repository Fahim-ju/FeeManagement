using firstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace firstApi
{
    public class DatabaseContext:DbContext
    {
        public DbSet< Law > Laws { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

    }
}