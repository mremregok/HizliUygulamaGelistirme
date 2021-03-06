﻿// <auto-generated />
using System;
using DbMigrations;
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

                    b.Property<string>("Ad");

                    b.HasKey("Id");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("Entities.Concrete.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad");

                    b.Property<int>("HastaneId");

                    b.HasKey("Id");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("Entities.Concrete.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad");

                    b.Property<int>("BolumId");

                    b.Property<int>("Cinsiyet");

                    b.Property<DateTime?>("DogumTarihi");

                    b.Property<int>("HastaneId");

                    b.Property<string>("Sifre");

                    b.Property<string>("Soyad");

                    b.Property<string>("TC");

                    b.Property<string>("Unvan");

                    b.HasKey("Id");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("Entities.Concrete.Favori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoktorAdı");

                    b.Property<int>("DoktorId");

                    b.Property<int>("HastaId");

                    b.Property<DateTime?>("OlusturulmaTarihi");

                    b.HasKey("Id");

                    b.ToTable("Favoriler");
                });

            modelBuilder.Entity("Entities.Concrete.Hasta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad");

                    b.Property<int>("Cinsiyet");

                    b.Property<DateTime?>("DogumTarihi");

                    b.Property<bool>("IsMailVerified");

                    b.Property<string>("Mail");

                    b.Property<string>("Sifre");

                    b.Property<string>("Soyad");

                    b.Property<string>("TC");

                    b.HasKey("Id");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("Entities.Concrete.Hastane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad");

                    b.Property<string>("Il");

                    b.Property<string>("Ilce");

                    b.HasKey("Id");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("Entities.Concrete.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BolumId");

                    b.Property<int>("DoktorId");

                    b.Property<int>("HastaId");

                    b.Property<int>("HastaneId");

                    b.Property<DateTime?>("Tarih");

                    b.HasKey("Id");

                    b.ToTable("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
