﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TVApp.Model;

#nullable disable

namespace TVAppDatabase.Migrations
{
    [DbContext(typeof(TvContext))]
    [Migration("20240423195906_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("TVApp.Model.Nezo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TvadasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TvadasId");

                    b.ToTable("Nezok");
                });

            modelBuilder.Entity("TVApp.Model.Tv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Csatorna")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Felvetel")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Hossz")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Kezdet")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mufaj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Musor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tvadasok");
                });

            modelBuilder.Entity("TVApp.Model.Nezo", b =>
                {
                    b.HasOne("TVApp.Model.Tv", "Tvadas")
                        .WithMany()
                        .HasForeignKey("TvadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tvadas");
                });
#pragma warning restore 612, 618
        }
    }
}
