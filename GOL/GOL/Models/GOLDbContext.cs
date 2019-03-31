using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOL.Models
{
    public class GOLDbContext : DbContext
    {

    public GOLDbContext(DbContextOptions<GOLDbContext> options) : base(options) { }

    public DbSet<Airplane> Airplane { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airplane>(entity =>
        {
            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Capacity)
                .IsRequired()
                .HasColumnType("int");

            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");
        });
    }
}  
}