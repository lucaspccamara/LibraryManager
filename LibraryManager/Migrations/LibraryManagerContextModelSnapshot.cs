﻿// <auto-generated />
using System;
using LibraryManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryManager.Migrations
{
    [DbContext(typeof(LibraryManagerContext))]
    partial class LibraryManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibraryManager.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("BookName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IndAtivo")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ThemeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibraryManager.Models.BookTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IndAtivo")
                        .HasColumnType("int");

                    b.Property<string>("Theme")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BookTheme");
                });

            modelBuilder.Entity("LibraryManager.Models.LoanHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("IdBookId")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuId")
                        .HasColumnType("int");

                    b.Property<int>("IndAtivo")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LoanType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReturnDeadline")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("IdBookId");

                    b.HasIndex("IdUsuId");

                    b.ToTable("LoanHistory");
                });

            modelBuilder.Entity("LibraryManager.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("EndPenalizedPeriod")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IndAtivo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Sex")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedDateStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LibraryManager.Models.Book", b =>
                {
                    b.HasOne("LibraryManager.Models.BookTheme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeId");
                });

            modelBuilder.Entity("LibraryManager.Models.LoanHistory", b =>
                {
                    b.HasOne("LibraryManager.Models.Book", "IdBook")
                        .WithMany()
                        .HasForeignKey("IdBookId");

                    b.HasOne("LibraryManager.Models.User", "IdUsu")
                        .WithMany()
                        .HasForeignKey("IdUsuId");
                });
#pragma warning restore 612, 618
        }
    }
}
