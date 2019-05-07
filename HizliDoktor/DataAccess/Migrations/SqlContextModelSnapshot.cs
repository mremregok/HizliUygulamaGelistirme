﻿// <auto-generated />
using System;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Concrete.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi");

                    b.Property<string>("Sifre");

                    b.HasKey("Id");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("Entities.Concrete.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi");

                    b.Property<int>("HastaneId");

                    b.HasKey("Id");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("Entities.Concrete.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi");

                    b.Property<DateTime?>("AraSaati");

                    b.Property<int>("BolumId");

                    b.Property<DateTime?>("CalismaSaatiBaslangic");

                    b.Property<DateTime?>("CalismaSaatiBitis");

                    b.Property<string>("Cinsiyet");

                    b.Property<int>("HastaneId");

                    b.Property<string>("Sifre");

                    b.Property<string>("Soyadi");

                    b.Property<int>("Tc");

                    b.Property<string>("Unvan");

                    b.HasKey("Id");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("Entities.Concrete.Hasta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi");

                    b.Property<string>("Adres");

                    b.Property<string>("Cinsiyet");

                    b.Property<DateTime?>("DogumTarihi");

                    b.Property<string>("DogumYeri");

                    b.Property<string>("Hastalik");

                    b.Property<int>("RandevuDurumu");

                    b.Property<string>("Sifre");

                    b.Property<string>("Soyadi");

                    b.Property<int>("Tc");

                    b.HasKey("Id");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("Entities.Concrete.Hastane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi");

                    b.Property<string>("Il");

                    b.Property<string>("Ilce");

                    b.HasKey("Id");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("Entities.Concrete.Odeme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoktorId");

                    b.Property<DateTime?>("Tarih");

                    b.Property<decimal>("Tutar");

                    b.HasKey("Id");

                    b.ToTable("Odemeler");
                });

            modelBuilder.Entity("Entities.Concrete.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BaslangicTarihi");

                    b.Property<DateTime?>("BitisiTarihi");

                    b.Property<int>("BolumId");

                    b.Property<int>("DoktorId");

                    b.Property<int>("HastaId");

                    b.HasKey("Id");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("Entities.Concrete.Rapor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama");

                    b.Property<DateTime?>("Tarih");

                    b.HasKey("Id");

                    b.ToTable("Raporlar");
                });
#pragma warning restore 612, 618
        }
    }
}
