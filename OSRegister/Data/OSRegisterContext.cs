using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OSRegister
{
    public partial class OSRegisterContext : DbContext
    {
        public OSRegisterContext()
        {
        }

        public OSRegisterContext(DbContextOptions<OSRegisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OSRegister;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID");
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.HasIndex(e => e.ServiceId);

                entity.Property(e => e.OperatorId).HasColumnName("OperatorID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Operator)
                    .HasForeignKey(d => d.ServiceId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.OrderId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
