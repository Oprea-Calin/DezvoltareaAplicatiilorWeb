﻿// <auto-generated />
using System;
using Lab9.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Proiect.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20240129130139_12")]
    partial class _12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lab9.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Proiect.Data.Models.Articol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Cantitate")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Articole");
                });

            modelBuilder.Entity("Proiect.Data.Models.Comanda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comenzi");
                });

            modelBuilder.Entity("Proiect.Data.Models.ComandaArticol", b =>
                {
                    b.Property<Guid?>("IdComanda")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdArticol")
                        .HasColumnType("char(36)");

                    b.HasKey("IdComanda", "IdArticol");

                    b.HasIndex("IdArticol");

                    b.ToTable("ComandaArticole");
                });

            modelBuilder.Entity("Proiect.Data.Models.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CUI")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Provideri");
                });

            modelBuilder.Entity("Proiect.Data.Models.Articol", b =>
                {
                    b.HasOne("Proiect.Data.Models.Provider", "Provider")
                        .WithOne("articol")
                        .HasForeignKey("Proiect.Data.Models.Articol", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Proiect.Data.Models.Comanda", b =>
                {
                    b.HasOne("Lab9.Models.User", "User")
                        .WithMany("Comenzi")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proiect.Data.Models.ComandaArticol", b =>
                {
                    b.HasOne("Proiect.Data.Models.Articol", "Articol")
                        .WithMany("ComandaArticole")
                        .HasForeignKey("IdArticol")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Proiect.Data.Models.Comanda", "Comanda")
                        .WithMany("ComandaArticole")
                        .HasForeignKey("IdComanda")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Articol");

                    b.Navigation("Comanda");
                });

            modelBuilder.Entity("Lab9.Models.User", b =>
                {
                    b.Navigation("Comenzi");
                });

            modelBuilder.Entity("Proiect.Data.Models.Articol", b =>
                {
                    b.Navigation("ComandaArticole");
                });

            modelBuilder.Entity("Proiect.Data.Models.Comanda", b =>
                {
                    b.Navigation("ComandaArticole");
                });

            modelBuilder.Entity("Proiect.Data.Models.Provider", b =>
                {
                    b.Navigation("articol")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
