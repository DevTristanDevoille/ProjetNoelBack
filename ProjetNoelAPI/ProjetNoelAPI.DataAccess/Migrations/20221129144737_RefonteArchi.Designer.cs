﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetNoelAPI.DataAccess.DbContextNoel;

#nullable disable

namespace ProjetNoelAPI.DataAccess.Migrations
{
    [DbContext(typeof(NoelDbContext))]
    [Migration("20221129144737_RefonteArchi")]
    partial class RefonteArchi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetNoelAPI.Models.Idea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdListe")
                        .HasColumnType("int");

                    b.Property<bool?>("IsTake")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int?>("ListeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<string>("UrlIdea")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListeId");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("ProjetNoelAPI.Models.Liste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCreator")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdSquad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SquadId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SquadId");

                    b.HasIndex("UserId");

                    b.ToTable("Listes");
                });

            modelBuilder.Entity("ProjetNoelAPI.Models.Squad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Squades");
                });

            modelBuilder.Entity("ProjetNoelAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SquadUser", b =>
                {
                    b.Property<int>("SquadesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("SquadesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("SquadUser");
                });

            modelBuilder.Entity("ProjetNoelAPI.Models.Idea", b =>
                {
                    b.HasOne("ProjetNoelAPI.Models.Liste", "Liste")
                        .WithMany("Ideas")
                        .HasForeignKey("ListeId");

                    b.Navigation("Liste");
                });

            modelBuilder.Entity("ProjetNoelAPI.Models.Liste", b =>
                {
                    b.HasOne("ProjetNoelAPI.Models.Squad", "Squad")
                        .WithMany("Listes")
                        .HasForeignKey("SquadId");

                    b.HasOne("ProjetNoelAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Squad");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SquadUser", b =>
                {
                    b.HasOne("ProjetNoelAPI.Models.Squad", null)
                        .WithMany()
                        .HasForeignKey("SquadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetNoelAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetNoelAPI.Models.Liste", b =>
                {
                    b.Navigation("Ideas");
                });

            modelBuilder.Entity("ProjetNoelAPI.Models.Squad", b =>
                {
                    b.Navigation("Listes");
                });
#pragma warning restore 612, 618
        }
    }
}
