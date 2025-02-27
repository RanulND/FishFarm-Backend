﻿// <auto-generated />
using System;
using Fishfarm.Management.Service.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fishfarm.Management.Service.API.Migrations
{
    [DbContext(typeof(FishFarmDbContext))]
    [Migration("20250226202716_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fishfarm.Management.Service.API.Data.Models.Coordinate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Coordinate");
                });

            modelBuilder.Entity("Fishfarm.Management.Service.API.Data.Models.FishFarm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CageCount")
                        .HasColumnType("bigint");

                    b.Property<long>("CoordinateId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Hasbarge")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoordinateId");

                    b.ToTable("FishFarms");
                });

            modelBuilder.Entity("Fishfarm.Management.Service.API.Data.Models.Worker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CertifiedUntil")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FishfarmId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkerPosition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FishfarmId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Fishfarm.Management.Service.API.Data.Models.FishFarm", b =>
                {
                    b.HasOne("Fishfarm.Management.Service.API.Data.Models.Coordinate", "Coordinate")
                        .WithMany()
                        .HasForeignKey("CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinate");
                });

            modelBuilder.Entity("Fishfarm.Management.Service.API.Data.Models.Worker", b =>
                {
                    b.HasOne("Fishfarm.Management.Service.API.Data.Models.FishFarm", "Fishfarm")
                        .WithMany()
                        .HasForeignKey("FishfarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fishfarm");
                });
#pragma warning restore 612, 618
        }
    }
}
