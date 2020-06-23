﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200621231035_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("owasp_topten_api.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 2500m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Balance = 5000m,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Balance = 15000m,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("owasp_topten_api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Frida",
                            LastName = "Kahlo",
                            Password = "123456",
                            Role = "User",
                            Username = "fkahlo"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Albert",
                            LastName = "Einstein",
                            Password = "123456",
                            Role = "User",
                            Username = "aeinstein"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Chuck",
                            LastName = "Norris",
                            Password = "123456",
                            Role = "Admin",
                            Username = "cnorris"
                        });
                });

            modelBuilder.Entity("owasp_topten_api.Entities.Account", b =>
                {
                    b.HasOne("owasp_topten_api.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}