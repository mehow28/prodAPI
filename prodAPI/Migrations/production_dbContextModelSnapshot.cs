﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prodAPI.Models;

#nullable disable

namespace prodAPI.Migrations
{
    [DbContext(typeof(production_dbContext))]
    partial class production_dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("prodAPI.Models.EtapyDto", b =>
                {
                    b.Property<int>("IdEtapu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_etapu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEtapu"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nazwa");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEtapu")
                        .HasName("PK_etapy");

                    b.ToTable("Etapy", (string)null);
                });

            modelBuilder.Entity("prodAPI.Models.KontumDto", b =>
                {
                    b.Property<int>("IdKonta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_konta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKonta"), 1L, 1);

                    b.Property<byte[]>("Haslo")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("binary(64)")
                        .HasColumnName("haslo")
                        .IsFixedLength();

                    b.Property<int>("IdPracownika")
                        .HasColumnType("int")
                        .HasColumnName("id_pracownika");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("login");

                    b.Property<string>("Uprawnienia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("uprawnienia");

                    b.HasKey("IdKonta");

                    b.HasIndex("IdPracownika");

                    b.ToTable("Konties");
                });

            modelBuilder.Entity("prodAPI.Models.MaszynyDto", b =>
                {
                    b.Property<int>("IdMaszyny")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_maszyny");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMaszyny"), 1L, 1);

                    b.Property<DateTime?>("DataPrzegladu")
                        .HasColumnType("date")
                        .HasColumnName("data_przegladu");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("marka");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("model");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nazwa");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("opis");

                    b.HasKey("IdMaszyny");

                    b.ToTable("Maszyny", (string)null);
                });

            modelBuilder.Entity("prodAPI.Models.PracownicyDto", b =>
                {
                    b.Property<int>("IdPracownika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_pracownika");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPracownika"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("imie");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nazwisko");

                    b.Property<string>("Nrtel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nr_tel");

                    b.HasKey("IdPracownika");

                    b.ToTable("Pracownicy", (string)null);
                });

            modelBuilder.Entity("prodAPI.Models.ProduktyDto", b =>
                {
                    b.Property<int>("IdProduktu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_produktu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduktu"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nazwa");

                    b.HasKey("IdProduktu");

                    b.ToTable("Produkty", (string)null);
                });

            modelBuilder.Entity("prodAPI.Models.StatusDto", b =>
                {
                    b.Property<int>("IdStatusu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_statusu");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatusu"), 1L, 1);

                    b.Property<int>("CzasTrwania")
                        .HasColumnType("int")
                        .HasColumnName("czas_trwania");

                    b.Property<int>("IdEtapu")
                        .HasColumnType("int")
                        .HasColumnName("id_etapu");

                    b.Property<int?>("IdMaszyny")
                        .HasColumnType("int")
                        .HasColumnName("id_maszyny");

                    b.Property<int>("IdPracownika")
                        .HasColumnType("int")
                        .HasColumnName("id_pracownika");

                    b.Property<int>("IdZlecenia")
                        .HasColumnType("int")
                        .HasColumnName("id_zlecenia");

                    b.Property<bool>("Stan")
                        .HasColumnType("bit")
                        .HasColumnName("stan");

                    b.HasKey("IdStatusu");

                    b.HasIndex("IdEtapu");

                    b.HasIndex("IdMaszyny");

                    b.HasIndex("IdPracownika");

                    b.HasIndex("IdZlecenia");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("prodAPI.Models.SurowceDlaEtapuDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FaktycznaIlosc")
                        .HasColumnType("int")
                        .HasColumnName("faktyczna_ilosc");

                    b.Property<int>("IdEtapu")
                        .HasColumnType("int")
                        .HasColumnName("id_etapu");

                    b.Property<int>("IdSurowca")
                        .HasColumnType("int")
                        .HasColumnName("id_surowca");

                    b.Property<int>("PotrzebnaIlosc")
                        .HasColumnType("int")
                        .HasColumnName("potrzebna_ilosc");

                    b.Property<bool>("Stan")
                        .HasColumnType("bit")
                        .HasColumnName("stan");

                    b.HasKey("Id");

                    b.HasIndex("IdEtapu");

                    b.HasIndex("IdSurowca");

                    b.ToTable("SurowceDlaEtapu", (string)null);
                });

            modelBuilder.Entity("prodAPI.Models.SurowceDto", b =>
                {
                    b.Property<int>("IdSurowca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_surowca");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSurowca"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nazwa");

                    b.HasKey("IdSurowca");

                    b.ToTable("Surowce", (string)null);
                });

            modelBuilder.Entity("prodAPI.Models.ZleceniumDto", b =>
                {
                    b.Property<int>("IdZlecenia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_zlecenia");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZlecenia"), 1L, 1);

                    b.Property<DateTime?>("DataRozpoczecia")
                        .HasColumnType("date")
                        .HasColumnName("data_rozpoczecia");

                    b.Property<DateTime?>("DataZakonczenia")
                        .HasColumnType("date")
                        .HasColumnName("data_zakonczenia");

                    b.Property<int>("IdProduktu")
                        .HasColumnType("int")
                        .HasColumnName("id_produktu");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int")
                        .HasColumnName("ilosc");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdZlecenia");

                    b.HasIndex("IdProduktu");

                    b.ToTable("Zlecenia");
                });

            modelBuilder.Entity("prodAPI.Models.KontumDto", b =>
                {
                    b.HasOne("prodAPI.Models.PracownicyDto", "IdPracownikaNavigation")
                        .WithMany("Konta")
                        .HasForeignKey("IdPracownika")
                        .IsRequired()
                        .HasConstraintName("FK_Konta_Pracownicy");

                    b.Navigation("IdPracownikaNavigation");
                });

            modelBuilder.Entity("prodAPI.Models.StatusDto", b =>
                {
                    b.HasOne("prodAPI.Models.EtapyDto", "IdEtapuNavigation")
                        .WithMany("Statuses")
                        .HasForeignKey("IdEtapu")
                        .IsRequired()
                        .HasConstraintName("FK_Status_Etapy");

                    b.HasOne("prodAPI.Models.MaszynyDto", "IdMaszynyNavigation")
                        .WithMany("Statuses")
                        .HasForeignKey("IdMaszyny")
                        .HasConstraintName("FK_Status_Maszyny");

                    b.HasOne("prodAPI.Models.PracownicyDto", "IdPracownikaNavigation")
                        .WithMany("Statuses")
                        .HasForeignKey("IdPracownika")
                        .IsRequired()
                        .HasConstraintName("FK_Status_Pracownicy");

                    b.HasOne("prodAPI.Models.ZleceniumDto", "IdZleceniaNavigation")
                        .WithMany("Statuses")
                        .HasForeignKey("IdZlecenia")
                        .IsRequired()
                        .HasConstraintName("FK_Status_Zlecenia");

                    b.Navigation("IdEtapuNavigation");

                    b.Navigation("IdMaszynyNavigation");

                    b.Navigation("IdPracownikaNavigation");

                    b.Navigation("IdZleceniaNavigation");
                });

            modelBuilder.Entity("prodAPI.Models.SurowceDlaEtapuDto", b =>
                {
                    b.HasOne("prodAPI.Models.EtapyDto", "IdEtapuNavigation")
                        .WithMany("SurowceDlaEtapus")
                        .HasForeignKey("IdEtapu")
                        .IsRequired()
                        .HasConstraintName("FK_SDE_Etapy");

                    b.HasOne("prodAPI.Models.SurowceDto", "IdSurowceNavigation")
                        .WithMany("SurowceDlaEtapus")
                        .HasForeignKey("IdSurowca")
                        .IsRequired()
                        .HasConstraintName("FK_SDE_Surowce");

                    b.Navigation("IdEtapuNavigation");

                    b.Navigation("IdSurowceNavigation");
                });

            modelBuilder.Entity("prodAPI.Models.ZleceniumDto", b =>
                {
                    b.HasOne("prodAPI.Models.ProduktyDto", "IdProduktuNavigation")
                        .WithMany("Zlecenia")
                        .HasForeignKey("IdProduktu")
                        .IsRequired()
                        .HasConstraintName("FK_Zlecenia_Produkty");

                    b.Navigation("IdProduktuNavigation");
                });

            modelBuilder.Entity("prodAPI.Models.EtapyDto", b =>
                {
                    b.Navigation("Statuses");

                    b.Navigation("SurowceDlaEtapus");
                });

            modelBuilder.Entity("prodAPI.Models.MaszynyDto", b =>
                {
                    b.Navigation("Statuses");
                });

            modelBuilder.Entity("prodAPI.Models.PracownicyDto", b =>
                {
                    b.Navigation("Konta");

                    b.Navigation("Statuses");
                });

            modelBuilder.Entity("prodAPI.Models.ProduktyDto", b =>
                {
                    b.Navigation("Zlecenia");
                });

            modelBuilder.Entity("prodAPI.Models.SurowceDto", b =>
                {
                    b.Navigation("SurowceDlaEtapus");
                });

            modelBuilder.Entity("prodAPI.Models.ZleceniumDto", b =>
                {
                    b.Navigation("Statuses");
                });
#pragma warning restore 612, 618
        }
    }
}
