﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Domain.Country", b =>
                {
                    b.Property<Guid>("CountryID")
                        .HasColumnType("TEXT");

                    b.Property<int>("APIFootballID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Flag")
                        .HasColumnType("TEXT");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.League", b =>
                {
                    b.Property<Guid>("LeagueID")
                        .HasColumnType("TEXT");

                    b.Property<int>("APIFootballID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LeagueName")
                        .HasColumnType("TEXT");

                    b.HasKey("LeagueID");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Domain.Person", b =>
                {
                    b.Property<Guid>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.Property<Guid>("TeamID")
                        .HasColumnType("TEXT");

                    b.Property<int>("APIFootballID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("LeagueID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("FirebaseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonID")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Country", b =>
                {
                    b.HasOne("Domain.League", "League")
                        .WithOne("Country")
                        .HasForeignKey("Domain.Country", "CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Person", "Person")
                        .WithOne("Country")
                        .HasForeignKey("Domain.Country", "CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.League", b =>
                {
                    b.HasOne("Domain.Team", "Team")
                        .WithOne("League")
                        .HasForeignKey("Domain.League", "LeagueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.HasOne("Domain.Person", "Person")
                        .WithOne("Team")
                        .HasForeignKey("Domain.Team", "TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("Domain.User", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.League", b =>
                {
                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Person", b =>
                {
                    b.Navigation("Country");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.Navigation("League");
                });
#pragma warning restore 612, 618
        }
    }
}