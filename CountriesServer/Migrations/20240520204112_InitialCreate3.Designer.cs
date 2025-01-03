﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CountriesServer.DbContextClasses;

#nullable disable

namespace CountriesServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240520204112_InitialCreate3")]
    partial class InitialCreate3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

            modelBuilder.Entity("CountriesServer.Country", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Agriculture")
                        .HasColumnType("REAL");

                    b.Property<double>("Area")
                        .HasColumnType("REAL");

                    b.Property<double>("Birthrate")
                        .HasColumnType("REAL");

                    b.Property<double>("Climate")
                        .HasColumnType("REAL");

                    b.Property<double>("CoastlineRatio")
                        .HasColumnType("REAL");

                    b.Property<double>("Deathrate")
                        .HasColumnType("REAL");

                    b.Property<double>("GDP")
                        .HasColumnType("REAL");

                    b.Property<double>("Industry")
                        .HasColumnType("REAL");

                    b.Property<double>("InfantMortality")
                        .HasColumnType("REAL");

                    b.Property<double>("Literacy")
                        .HasColumnType("REAL");

                    b.Property<double>("NetMigration")
                        .HasColumnType("REAL");

                    b.Property<double>("Phones")
                        .HasColumnType("REAL");

                    b.Property<double>("Population")
                        .HasColumnType("REAL");

                    b.Property<double>("PopulationDensity")
                        .HasColumnType("REAL");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
