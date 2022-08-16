using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Prog_Farm_Stall_MVC_Final.Models
{
    public partial class Prog_Farm_Stall_MVC_FinalContext : DbContext
    {
        public Prog_Farm_Stall_MVC_FinalContext()
        {
        }

        public Prog_Farm_Stall_MVC_FinalContext(DbContextOptions<Prog_Farm_Stall_MVC_FinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginUser> LoginUser { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-3DLD77IN\\SQLEXPRESS;Initial Catalog=Prog_Farm_Stall_MVC_Final;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.HasKey(e => e.UsernameId)
                    .HasName("PK__LoginUse__B0AF7D582000DFF1");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDescription).IsUnicode(false);

                entity.Property(e => e.ProductFarmerName).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
