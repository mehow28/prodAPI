﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace prodAPI.Models
{
    public partial class production_dbContext : DbContext
    {
        public production_dbContext()
        {
        }

        public production_dbContext(DbContextOptions<production_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EtapyDto> Etapies { get; set; } = null!;
        public virtual DbSet<KontumDto> Konties { get; set; } = null!;
        public virtual DbSet<MaszynyDto> Maszynies { get; set; } = null!;
        public virtual DbSet<PracownicyDto> Pracownicies { get; set; } = null!;
        public virtual DbSet<ProduktyDto> Produkties { get; set; } = null!;
        public virtual DbSet<ProduktyDlaEtapuDto> ProduktyDlaEtapus { get; set; } = null!;
        public virtual DbSet<StatusDto> Statuses { get; set; } = null!;
        public virtual DbSet<ZleceniumDto> Zlecenia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EtapyDto>(entity =>
            {
                entity.HasKey(e => e.IdEtapu)
                    .HasName("PK_etapy");

                entity.ToTable("Etapy");

                entity.Property(e => e.IdEtapu)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_etapu");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");

                entity.Property(e => e.Opis)
                    .HasColumnType("text")
                    .HasColumnName("opis");

            });

            modelBuilder.Entity<KontumDto>(entity =>
            {
                entity.HasKey(e => e.IdKonta);

                entity.Property(e => e.IdKonta)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_konta");

                entity.Property(e => e.Haslo)
                    .HasMaxLength(64)
                    .HasColumnName("haslo")
                    .IsFixedLength();

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                   
                    .HasColumnName("login");

                entity.Property(e => e.Uprawnienia)
                    .HasMaxLength(50)
                   
                    .HasColumnName("uprawnienia");

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithMany(p => p.Konta)
                    .HasForeignKey(d => d.IdPracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Konta_Pracownicy");
            });

            modelBuilder.Entity<MaszynyDto>(entity =>
            {
                entity.HasKey(e => e.IdMaszyny);

                entity.ToTable("Maszyny");

                entity.Property(e => e.IdMaszyny)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_maszyny");

                entity.Property(e => e.Kategoria)
                    .HasMaxLength(50)
                   
                    .HasColumnName("kategoria");

                entity.Property(e => e.Marka)
                    .HasMaxLength(50)
                   
                    .HasColumnName("marka");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                   
                    .HasColumnName("model");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                   
                    .HasColumnName("nazwa");

                entity.Property(e => e.Opis)
                    .HasMaxLength(50)
                   
                    .HasColumnName("opis");
            });

            modelBuilder.Entity<PracownicyDto>(entity =>
           {
                entity.HasKey(e => e.IdPracownika);

                entity.ToTable("Pracownicy");

                entity.Property(e => e.IdPracownika)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_pracownika");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                   
                    .HasColumnName("email");

                entity.Property(e => e.Imie)
                    .HasMaxLength(50)
                   
                    .HasColumnName("imie");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(50)
                   
                    .HasColumnName("nazwisko");

                entity.Property(e => e.Nrtel)
                    .HasMaxLength(50)
                   
                    .HasColumnName("nrtel");
            });

            modelBuilder.Entity<ProduktyDto>(entity =>
            {
                entity.HasKey(e => e.IdProduktu);

                entity.ToTable("Produkty");

                entity.Property(e => e.IdProduktu)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_produktu");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                   
                    .HasColumnName("nazwa");
            });

            modelBuilder.Entity<ProduktyDlaEtapuDto>(entity =>
            {
                entity.ToTable("Produkty_Dla_Etapu");

                entity.HasIndex(e => e.IdProduktu, "FK_Produkty_Dla_Etapu_2");

                entity.HasIndex(e => e.IdEtapu, "FK_Produkty_Dla_Etapu_3");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdEtapu).HasColumnName("id_etapu");

                entity.Property(e => e.IdProduktu).HasColumnName("id_produktu");

                entity.Property(e => e.Stan).HasColumnName("stan");

                entity.HasOne(d => d.IdEtapuNavigation)
                   .WithMany(p => p.ProduktyDlaEtapus)
                   .HasForeignKey(d => d.IdEtapu)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Produkty_Dla_Etapu_9");

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.ProduktyDlaEtapus)
                    .HasForeignKey(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produkty_Dla_Etapu_8_1");
            });
            modelBuilder.Entity<StatusDto>(entity =>
            {
                entity.HasKey(e => e.IdStatusu)
                    .HasName("PK_Status_1");

                entity.ToTable("Status");

                entity.Property(e => e.IdStatusu)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_statusu");

                entity.Property(e => e.DataRozpoczecia)
                    .HasColumnType("date")
                    .HasColumnName("data_rozpoczecia");

                entity.Property(e => e.DataZakonczenia)
                    .HasColumnType("date")
                    .HasColumnName("data_zakonczenia");

                entity.Property(e => e.IdEtapu).HasColumnName("id_etapu");

                entity.Property(e => e.IdMaszyny).HasColumnName("id_maszyny");

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.IdProduktu).HasColumnName("id_produktu");

                entity.Property(e => e.IdZlecenia).HasColumnName("id_zlecenia");

                entity.Property(e => e.Notatki)
                    .HasColumnType("text")
                    .HasColumnName("notatki");

                entity.Property(e => e.Stan).HasColumnName("stan");

                entity.HasOne(d => d.IdEtapuNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdEtapu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Etapy");

                entity.HasOne(d => d.IdMaszynyNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdMaszyny)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Maszyny");

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdPracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Pracownicy");

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Produkty");

                entity.HasOne(d => d.IdZleceniaNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdZlecenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Zlecenia");
            });

            modelBuilder.Entity<ZleceniumDto>(entity =>
            {
                entity.HasKey(e => e.IdZlecenia);

                entity.Property(e => e.IdZlecenia)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_zlecenia");

                entity.Property(e => e.DataRozpoczecia)
                    .HasColumnType("date")
                    .HasColumnName("data_rozpoczecia");

                entity.Property(e => e.DataZakonczenia!)
                    .HasColumnType("date")
                    .HasColumnName("data_zakonczenia");


                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.Property(e => e.Opis)
                    .HasColumnType("text")
                    .HasColumnName("opis");

                entity.Property(e => e.Stan).HasColumnName("stan");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
