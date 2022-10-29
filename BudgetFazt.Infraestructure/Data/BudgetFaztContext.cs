using System;
using System.Collections.Generic;
using BudgetFazt.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetFazt.Infraestructure.Data;

public partial class BudgetFaztContext : DbContext
{
    public BudgetFaztContext()
    {
    }

    public BudgetFaztContext(DbContextOptions<BudgetFaztContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=C:\\Users\\mayor\\source\\repos\\BudgetFazt\\BudgetWinForms.UI\\BudgetFazt.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT");
            entity.Property(e => e.Description).HasColumnType("VARCHAR");
            entity.Property(e => e.Discount).HasColumnType("FLOAT");
            entity.Property(e => e.Name).HasColumnType("VARCHAR");
            entity.Property(e => e.Quantity).HasColumnType("INT");
            entity.Property(e => e.UnitPrice).HasColumnType("FLOAT");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Article)
                .HasForeignKey<Article>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT");
            entity.Property(e => e.CompanyName).HasColumnType("VARCHAR");
            entity.Property(e => e.Description).HasColumnType("VARCHAR");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Company)
                .HasForeignKey<Company>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT");
            entity.Property(e => e.Address).HasColumnType("VARCHAR");
            entity.Property(e => e.Email).HasColumnType("VARCHAR");
            entity.Property(e => e.Name).HasColumnType("VARCHAR");
            entity.Property(e => e.Phone).HasColumnType("VARCHAR");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT");
            entity.Property(e => e.Description).HasColumnType("VARCHAR");
            entity.Property(e => e.EndDate).HasColumnType("VARCHAR");
            entity.Property(e => e.NameProject).HasColumnType("VARCHAR");
            entity.Property(e => e.StartDate).HasColumnType("VARCHAR");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Project)
                .HasForeignKey<Project>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "IX_User_Email").IsUnique();

            entity.HasIndex(e => e.Name, "IX_User_Name").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("INT");
            entity.Property(e => e.Email).HasColumnType("VARCHAR");
            entity.Property(e => e.Name).HasColumnType("VARCHAR");
            entity.Property(e => e.Password).HasColumnType("VARCHAR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
