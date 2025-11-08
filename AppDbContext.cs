using MusicRental.Class;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicRental
{
    public class AppDbContext : DbContext
    {
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentType> EquipmentType { get; set; }
        public DbSet<Maker> Maker { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<RentalUnit> RentalUnit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NL9UL70\SQLEXPRESS;Database=RentalEquipmentDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связей
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.EquipmentType)
                .WithMany()
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Maker)
                .WithMany()
                .HasForeignKey(e => e.MakerID);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Supplier)
                .WithMany()
                .HasForeignKey(e => e.SupplierID);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.RentalUnit)
                .WithMany()
                .HasForeignKey(e => e.RentalUnitID);
        }
    }
}
