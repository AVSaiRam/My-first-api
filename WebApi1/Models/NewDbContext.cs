using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi1.Models;

public partial class NewDbContext : DbContext
{
    public NewDbContext()
    {
    }

    public NewDbContext(DbContextOptions<NewDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Netwr> Netwrs { get; set; }

    public virtual DbSet<Repoteb> Repotebs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-D5K402D3\\AVSAIRAM; Database=NewDB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Netwr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Netwr");

            entity.Property(e => e.Fname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RollNo).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Repoteb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__REPOTEB__3214EC2717901A3E");

            entity.ToTable("REPOTEB");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.Discription)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DISCRIPTION");
            entity.Property(e => e.Intrests)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("INTRESTS");
            entity.Property(e => e.Nam)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
