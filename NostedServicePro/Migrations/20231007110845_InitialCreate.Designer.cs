﻿// <auto-generated />
using System;
using Loginnosted.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Loginnosted.Migrations
{
    [DbContext(typeof(ServiceProDbContex))]
    [Migration("20231007110845_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bruker", b =>
                {
                    b.Property<int>("BrukerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BrukerNavn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Epostadresse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Passord")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rolle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BrukerId");

                    b.ToTable("Brukere");
                });

            modelBuilder.Entity("ServiceOrdre", b =>
                {
                    b.Property<int>("OrdreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AvtaltKommentar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("Avtaltferdigstillingsdato")
                        .HasColumnType("date");

                    b.Property<DateOnly>("AvtaltleveringsDato")
                        .HasColumnType("date");

                    b.Property<string>("InternKommentar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kundeepost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kundenavn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Kundetlf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Problembeskrivelse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("ProduktmottattDato")
                        .HasColumnType("date");

                    b.Property<string>("Produkttypevinsj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Registreringsdato")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Serienummervinsj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ÅrsmodellVinsj")
                        .HasColumnType("int");

                    b.HasKey("OrdreID");

                    b.ToTable("service");
                });
#pragma warning restore 612, 618
        }
    }
}
