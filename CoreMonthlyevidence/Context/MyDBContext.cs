using CoreMonthlyevidence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMonthlyevidence.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> g)
            : base(g)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }

}
