using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace firstApi
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Law> Laws { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Fine> Fines { get; set; }

    }
}