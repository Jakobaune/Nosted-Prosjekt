﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NostedServicePro.Data;

#nullable disable

namespace NostedServicePro.Migrations
{
    [DbContext(typeof(ServiceProDbContex))]
    partial class ServiceProDbContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ServiceOrdre", b =>
                {
                    b.Property<int>("OrdreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double?>("Arbeidstimer")
                        .HasColumnType("double");

                    b.Property<string>("AvtaltKommentar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Avtaltferdigstillingsdato")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("AvtaltleveringsDato")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BremsekraftKn")
                        .HasColumnType("longtext");

                    b.Property<string>("Bremser")
                        .HasColumnType("longtext");

                    b.Property<string>("BremsesylingerSkiftTelninger")
                        .HasColumnType("longtext");

                    b.Property<string>("ClutchLameller")
                        .HasColumnType("longtext");

                    b.Property<bool>("ErSjekklisteFullført")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HydraulikkSylinderLekkasje")
                        .HasColumnType("longtext");

                    b.Property<string>("InternKommentar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("KilleKjedehjul")
                        .HasColumnType("longtext");

                    b.Property<string>("Kjedestrammer")
                        .HasColumnType("longtext");

                    b.Property<string>("Kommentar")
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

                    b.Property<string>("LagerTrommel")
                        .HasColumnType("longtext");

                    b.Property<string>("LedningsnettVinsj")
                        .HasColumnType("longtext");

                    b.Property<string>("PTOOpplagring")
                        .HasColumnType("longtext");

                    b.Property<string>("PlnlonLager")
                        .HasColumnType("longtext");

                    b.Property<string>("Problembeskrivelse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ProduktmottattDato")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Produkttypevinsj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RegistreringFullførtAv")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Registreringsdato")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RingsyllingerSkiftTelnlnger")
                        .HasColumnType("longtext");

                    b.Property<string>("Serienummervinsj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkListeFullførtAv")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkTestKnappekasse")
                        .HasColumnType("longtext");

                    b.Property<string>("SjekkTestRadio")
                        .HasColumnType("longtext");

                    b.Property<string>("SkiftOljeGirboks")
                        .HasColumnType("longtext");

                    b.Property<string>("SkiftOljeTank")
                        .HasColumnType("longtext");

                    b.Property<string>("SlangerSkaderLekkasje")
                        .HasColumnType("longtext");

                    b.Property<string>("TestHydraulikkblokk")
                        .HasColumnType("longtext");

                    b.Property<string>("TestVinsjAlleFunksjoner")
                        .HasColumnType("longtext");

                    b.Property<string>("TrekkraftKn")
                        .HasColumnType("longtext");

                    b.Property<string>("Wire")
                        .HasColumnType("longtext");

                    b.Property<string>("XXBar")
                        .HasColumnType("longtext");

                    b.Property<int>("ÅrsmodellVinsj")
                        .HasColumnType("int");

                    b.HasKey("OrdreID");

                    b.ToTable("service");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
