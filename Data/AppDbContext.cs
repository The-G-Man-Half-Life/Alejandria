using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Alejandria.Models;
using Microsoft.EntityFrameworkCore;


namespace Alejandria.Data;
public class AppDbContext : DbContext
{
    public DbSet<Loan> Loans { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Location> Locations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar claves primarias
        modelBuilder.Entity<Loan>().HasKey(l => l.LoanId);
        modelBuilder.Entity<User>().HasKey(u => u.UserId);
        modelBuilder.Entity<Book>().HasKey(b => b.BookId);
        modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
        modelBuilder.Entity<Location>().HasKey(l => l.LocationCode);

        // Configurar relaciones
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.User)
            .WithMany(u => u.Loans)
            .HasForeignKey(l => l.UserId);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Location)
            .WithMany(l => l.Books)
            .HasForeignKey(b => b.LocationCode);

        base.OnModelCreating(modelBuilder);
    }
}


