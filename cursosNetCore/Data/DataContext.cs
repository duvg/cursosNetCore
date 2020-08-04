using System;
using Microsoft.EntityFrameworkCore;
using cursosNetCore.Models;
namespace cursosNetCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        } 

        public DbSet<Category> Category { get; set; }
    }
}
