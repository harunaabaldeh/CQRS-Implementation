using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CQRS.Models;

namespace CQRS.Data
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ListOfSchool> ListOfSchools { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HARUNA;Database=Schools;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListOfSchool>(entity =>
            {
                entity.ToTable("listOfSchools");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Region)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SchooName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.SchooNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SchoolType)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
