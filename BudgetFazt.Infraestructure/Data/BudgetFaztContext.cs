﻿using System;
using System.Collections.Generic;
using System.Reflection;
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
    {
        optionsBuilder.UseSqlite(connectionString: "Filename="+"BudgetFazt.db", sqliteOptionsAction: op =>
        {
            op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable(nameof(Article));

            entity.Property(e => e.Id);
            entity.Property(e => e.Description);
            entity.Property(e => e.Discount);
            entity.Property(e => e.Name);
            entity.Property(e => e.Quantity);
            entity.Property(e => e.UnitPrice);

            entity.HasOne(d => d.Project).WithMany(p => p.Article).HasForeignKey(d => d.ProjectId);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable(nameof(Company));

            entity.Property(e => e.Id);
            entity.Property(e => e.CompanyName);
            entity.Property(e => e.Description);

            entity.HasOne(d => d.User).WithMany(p => p.Company).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable(nameof(Customer));

            entity.Property(e => e.Id);
            entity.Property(e => e.Address);
            entity.Property(e => e.Email);
            entity.Property(e => e.Name);
            entity.Property(e => e.Phone);

            entity.HasOne(d => d.Project).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable(nameof(Project));

            entity.Property(e => e.Id);
            entity.Property(e => e.Description);
            entity.Property(e => e.EndDate);
            entity.Property(e => e.NameProject);
            entity.Property(e => e.StartDate);

            entity.HasOne(d => d.Company).WithMany(p => p.Project).HasForeignKey(d => d.CompanyId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(nameof(User));

            entity.HasIndex(e => e.Email, "IX_User_Email").IsUnique();

            entity.HasIndex(e => e.Name, "IX_User_Name").IsUnique();

            entity.Property(e => e.Id);
            entity.Property(e => e.Email);
            entity.Property(e => e.Name);
            entity.Property(e => e.Password);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
