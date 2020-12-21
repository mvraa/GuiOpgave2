using Microsoft.EntityFrameworkCore;
using GuiEksamen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiEksamen.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

        public DbSet<EfAccount> Accounts { get; set; }
        public DbSet<EfManager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure indexes
            modelBuilder.Entity<EfAccount>()
                .HasIndex(p => p.Email)
                .IsUnique();
            modelBuilder.Entity<EfManager>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
