using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENISSCHOOL
{
    class ENISContext : DbContext
    {
        public DbSet<Student> Students { get; set; } 
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BBSDTO7;Database=EnisDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Grade)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
