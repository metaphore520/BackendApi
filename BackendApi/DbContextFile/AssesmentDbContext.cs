using System;
using System.Collections.Generic;
using BackendApi.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.DbContextFile;

public partial class AssesmentDbContext : DbContext
{
    public AssesmentDbContext()
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public AssesmentDbContext(DbContextOptions<AssesmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-R1A1J4P\\SQLEXPRESS;Database=AssesmentDB;Trust Server Certificate=true;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasOne(d => d.Course).WithMany(p => p.Marks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mark_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.Marks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mark_Student");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
