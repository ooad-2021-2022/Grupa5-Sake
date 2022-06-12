using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sake.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
options)
 : base(options)
 {
 }
 public DbSet<Lutrija> Lutrija { get; set; }
 public DbSet<Utakmica> Utakmica { get; set; }
 public DbSet<GledanjeUtakmice> GledanjeUtakmice { get; set; }
 public DbSet<Ulaznica> Ulaznica { get; set; }
 public DbSet<Igrac> Igrac { get; set; }
 public DbSet<SportskiTim> SportskiTim  { get; set; }
 public DbSet<IgranjeZaTim> IgranjeZaTim { get; set; }
       

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
 modelBuilder.Entity<Lutrija>().ToTable("Lutrija");
 modelBuilder.Entity<Utakmica>().ToTable("Utakmica");
 modelBuilder.Entity<GledanjeUtakmice>().ToTable("GledanjeUtakmice");
 modelBuilder.Entity<Ulaznica>().ToTable("Ulaznica");
 modelBuilder.Entity<Igrac>().ToTable("Igrac");
 modelBuilder.Entity<SportskiTim>().ToTable("SportskiTim");
 modelBuilder.Entity<IgranjeZaTim>().ToTable("IgranjeZaTim");
           

 base.OnModelCreating(modelBuilder);
 }
    }
}
