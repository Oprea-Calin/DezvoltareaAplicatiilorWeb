﻿using Lab9.Models;
using Microsoft.EntityFrameworkCore;
using Proiect.Data.Models;

namespace Lab9.Data
{
    public class ProjectContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Articol> Articole {  get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<ComandaArticol> ComandaArticole {  get; set; }
        public DbSet<Provider> Provideri { get; set; }
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many
            modelBuilder.Entity<User>()
                .HasMany(m1 => m1.Comenzi)
                .WithOne(m2 => m2.User);

            //one to one
            modelBuilder.Entity<Provider>()
                .HasOne(m3 => m3.articol)
                .WithOne(m4 => m4.Provider)
                .HasForeignKey<Articol>(m4 => m4.Id);

            //many to many
            modelBuilder.Entity<ComandaArticol>().HasKey(mr => new { mr.IdComanda, mr.IdArticol });

            modelBuilder.Entity<ComandaArticol>()
                .HasOne(mr => mr.Comanda)
                .WithMany(m5 => m5.comandaArticole)
                .HasForeignKey(mr => mr.IdComanda);

            modelBuilder.Entity<ComandaArticol>()
                .HasOne(mr => mr.Articol)
                .WithMany(m6 => m6.comandaArticole)
                .HasForeignKey(mr => mr.IdArticol);

            



            base.OnModelCreating(modelBuilder);
        }

        
    }
}
