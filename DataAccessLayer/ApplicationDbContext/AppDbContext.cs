using CommanLayer.Enum;
using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Invoice> Invoices{ get; set; }
        public virtual DbSet<UserRefreshTokens> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(option =>
            {
                option.ToTable("users");
                option.HasIndex(e => e.Email).IsUnique();
                option.Property(e => e.Status).HasDefaultValue(UserStatus.ACTIVE);
                option.Property(e => e.Role).HasDefaultValue(UserRole.USER);
            });

            modelBuilder.Entity<Product>(option =>
            {
                option.ToTable("products");
            });

            modelBuilder.Entity<Invoice>(option =>
            {
                option.ToTable("invoices");
            });

            modelBuilder.Entity<UserRefreshTokens>(option =>
            {
                option.ToTable("userRefreshToken");
            });
        }
    }
}
