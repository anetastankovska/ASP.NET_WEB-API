using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SEDC.WebApi.Class06.Domain
{
    public partial class SEDCContext : DbContext
    {
        public SEDCContext()
        {
        }

        public SEDCContext(DbContextOptions<SEDCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeesThatMadeOrder> EmployeesThatMadeOrders { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductsTest> ProductsTests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-U613IMF;Database=SEDC;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessEntity>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Region).HasMaxLength(1000);

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CustomerSize).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.RegionName).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.NationalIdNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<EmployeesThatMadeOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Employees that made order");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ProductsTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Products_Test");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
