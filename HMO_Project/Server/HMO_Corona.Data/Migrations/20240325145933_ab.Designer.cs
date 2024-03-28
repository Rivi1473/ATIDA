﻿// <auto-generated />
using System;
using HMO_Corona.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMO_Corona.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240325145933_ab")]
    partial class ab
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HMO_Corona.Core.Entities.CoronaDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FirstVaccinationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstmanufacturerVaccination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FourthVaccinationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FourthmanufacturerVaccination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PositiveResultDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RecoveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SecondVaccinationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecondmanufacturerVaccination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThirdVaccinationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThirdmanufacturerVaccination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CoronaDetails");
                });

            modelBuilder.Entity("HMO_Corona.Core.Entities.PersonalDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoronaDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberHouse")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoronaDetailsId");

                    b.ToTable("PersonalDetails");
                });

            modelBuilder.Entity("HMO_Corona.Core.Entities.PersonalDetails", b =>
                {
                    b.HasOne("HMO_Corona.Core.Entities.CoronaDetails", "CoronaDetails")
                        .WithMany()
                        .HasForeignKey("CoronaDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoronaDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
