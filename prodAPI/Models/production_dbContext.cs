﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using prodAPI.Models.StrukturyWyrobu;

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
        public virtual DbSet<SurowceDto> Surowcies{ get; set; } = null!;
        public virtual DbSet<StatusDto> Statuses { get; set; } = null!;
        public virtual DbSet<ZleceniumDto> Zlecenia { get; set; } = null!;
        public virtual DbSet<StrukturyWyrobuDto> StrukturyWyrobus { get; set; } = null!;
        public virtual DbSet<SurowceDlaEtapuDto> SurowceDlaEtapus { get; set; } = null!;
        public virtual DbSet<AwariaDto> Awarias { get; set; } = null!;
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

                entity.Property(e => e.Czas).HasColumnName("czas");

                /*
                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.Etapies)
                    .HasForeignKey(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Etapy_Produkty");*/
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

                entity.Property(e => e.IdAwarii)
                   .HasColumnName("id_awarii");
                   
                entity.Property(e => e.DataPrzegladu)
                    .HasColumnType("datetime")
                    .HasColumnName("data_przegladu");

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
                    .HasMaxLength(500)
                    .HasColumnName("opis");

                entity.HasOne(d => d.IdAwariaNavigation)
                   .WithMany(p => p.Maszyny)
                   .HasForeignKey(d => d.IdAwarii)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Maszyny_Awaria");
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
                    .HasColumnName("nr_tel");
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

            modelBuilder.Entity<SurowceDto>(entity =>
            {
                entity.HasKey(e => e.IdSurowca);

                entity.ToTable("Surowce");

                entity.Property(e => e.IdSurowca)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_surowca");

                entity.Property(e => e.Nazwa)
                    .HasMaxLength(50)
                    .HasColumnName("nazwa");
            });
            modelBuilder.Entity<SurowceDlaEtapuDto>(entity =>
            {
                ///DO DOKOŃCZENIA!
                entity.HasKey(e => e.Id);

                entity.ToTable("SurowceDlaEtapu");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Stan)
                    .HasColumnName("stan");

                entity.Property(e => e.PotrzebnaIlosc)
                    .HasColumnName("potrzebna_ilosc");
                
                entity.Property(e => e.FaktycznaIlosc)
                    .HasColumnName("faktyczna_ilosc");
                
                entity.Property(e => e.IdEtapu)
                    .HasColumnName("id_etapu");
                
                entity.Property(e => e.IdSurowca)
                    .HasColumnName("id_surowca");

                entity.HasOne(d => d.IdEtapuNavigation)
                     .WithMany(p => p.SurowceDlaEtapus)
                     .HasForeignKey(d => d.IdEtapu)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_SDE_Etapy");

                entity.HasOne(d => d.IdSurowceNavigation)
                    .WithMany(p => p.SurowceDlaEtapus)
                    .HasForeignKey(d => d.IdSurowca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SDE_Surowce");

            });

            modelBuilder.Entity<StrukturyWyrobuDto>(entity =>
            {
                entity.ToTable("StrukturyWyrobu");

                entity.HasIndex(e => e.IdEtapu, "IX_StrukturyWyrobu_IdEtapuNavigationIdEtapu");

                entity.HasIndex(e => e.IdProduktu, "IX_StrukturyWyrobu_IdProduktuNavigationIdProduktu");

                entity.HasOne(d => d.IdEtapuNavigation)
                    .WithMany(p => p.StrukturyWyrobus)
                    .HasForeignKey(d => d.IdEtapu);

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.StrukturyWyrobus)
                    .HasForeignKey(d => d.IdProduktu);
            });

            /*modelBuilder.Entity<ProduktyDto>()
                .HasData(
                new ProduktyDto
                {
                    IdProduktu = 1,
                    Nazwa = "Prod1"
                },
                new ProduktyDto
                {
                    IdProduktu = 2,
                    Nazwa = "Prod2"
                });
*/
            modelBuilder.Entity<StatusDto>(entity =>
            {
                entity.HasKey(e => e.IdStatusu);

                entity.ToTable("Status");

                entity.Property(e => e.IdStatusu)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_statusu");

                entity.Property(e => e.CzasTrwania).HasColumnName("czas_trwania");

                entity.Property(e => e.IdEtapu).HasColumnName("id_etapu");

                entity.Property(e => e.IdMaszyny).HasColumnName("id_maszyny");

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.IdZlecenia).HasColumnName("id_zlecenia");

                entity.Property(e => e.Stan).HasColumnName("stan");

                entity.HasOne(d => d.IdEtapuNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdEtapu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Etapy");

                entity.HasOne(d => d.IdMaszynyNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdMaszyny)
                    .HasConstraintName("FK_Status_Maszyny");

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdPracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Pracownicy");

              
                entity.HasOne(d => d.IdZleceniaNavigation)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.IdZlecenia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Zlecenia");
            });

            modelBuilder.Entity<ZleceniumDto>(entity =>
            {
                entity.HasKey(e => e.IdZlecenia);

                entity.ToTable("Zlecenia");

                entity.Property(e => e.IdZlecenia)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_zlecenia");
                
                entity.Property(e => e.DataRozpoczecia)
                    .HasColumnType("datetime")
                    .HasColumnName("data_rozpoczecia");

                entity.Property(e => e.DataZakonczenia)
                    .HasColumnType("datetime")
                    .HasColumnName("data_zakonczenia");

                entity.Property(e => e.IdProduktu).HasColumnName("id_produktu");

                entity.Property(e => e.Ilosc).HasColumnName("ilosc");

                entity.HasOne(d => d.IdProduktuNavigation)
                    .WithMany(p => p.Zlecenia)
                    .HasForeignKey(d => d.IdProduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zlecenia_Produkty");

            });
            modelBuilder.Entity<AwariaDto>(entity =>
            {
                entity.HasKey(e => e.IdAwarii);

                entity.ToTable("Awaria");

                entity.Property(e => e.IdAwarii)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_awarii");

                entity.Property(e => e.DataZgloszenia)
                    .HasColumnType("datetime")
                    .HasColumnName("data_rozpoczecia");

                entity.Property(e => e.Stan).HasColumnName("stan");

                entity.Property(e => e.Opis).HasColumnName("opis");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
