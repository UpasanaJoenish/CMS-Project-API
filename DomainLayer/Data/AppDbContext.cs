using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Coupon> Coupons { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Coupon>().Property(e => e.Discount).HasColumnType("decimal(10, 4)");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>()
        .HasIndex(c => c.CouponCode)
        .IsUnique();
            }


   
    }
}






