﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TvMazeScraper.Database;

namespace TvMazeScraper.Migrations
{
    [DbContext(typeof(TvMazeDbContext))]
    partial class TvMazeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("TvMazeScraper.Database.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TvMazeScraper.Database.Models.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ShowId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("TvMazeScraper.Database.Models.ShowPerson", b =>
                {
                    b.Property<int>("ShowId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ShowId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("ShowPersons");
                });

            modelBuilder.Entity("TvMazeScraper.Database.Models.ShowPerson", b =>
                {
                    b.HasOne("TvMazeScraper.Database.Models.Person", "Person")
                        .WithMany("ShowPersons")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TvMazeScraper.Database.Models.Show", "Show")
                        .WithMany("ShowPersons")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}