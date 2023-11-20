using E.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Infrastructure
{
    public class ExamenContext:DbContext
    {
        DbSet<Artiste> artistes {  get; set; }
        DbSet<Chanson> chansons { get; set; }
        DbSet<Concert> concertes { get; set; }
        DbSet<Festival> festivals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HajBrahemHabibConcert;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste>().HasMany(e => e.Concerts).WithOne(e => e.Artiste).HasForeignKey(e => e.ArtisteFk);
            modelBuilder.Entity<Festival>().HasMany(e => e.Concerts).WithOne(e => e.Festival).HasForeignKey(e => e.FestivalFk);
            modelBuilder.Entity<Concert>().HasKey(e => new {e.ArtisteFk,e.FestivalFk,e.DateConcert});
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<String>().HaveMaxLength(50);
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
