﻿// <auto-generated />
using System;
using BilletAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BilletAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231122202602_AddBilletUserToDb")]
    partial class AddBilletUserToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BilletAPI.Models.Billet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Billets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer1 = "adads",
                            Answer2 = "adadsad",
                            Answer3 = "",
                            Answer4 = "",
                            CorrectAnswer = "",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "lorem ipsum",
                            ImageUrl = "",
                            Name = "Billet1 ",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Answer1 = "adads",
                            Answer2 = "adadsad",
                            Answer3 = "",
                            Answer4 = "",
                            CorrectAnswer = "",
                            CreatedDate = new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(480),
                            Description = "lorem ipsum",
                            ImageUrl = "",
                            Name = "Billet2 ",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Answer1 = "adads",
                            Answer2 = "adadsad",
                            Answer3 = "",
                            Answer4 = "",
                            CorrectAnswer = "",
                            CreatedDate = new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(538),
                            Description = "lorem ipsum",
                            ImageUrl = "",
                            Name = "Billet3 ",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Answer1 = "adads",
                            Answer2 = "adadsad",
                            Answer3 = "",
                            Answer4 = "",
                            CorrectAnswer = "",
                            CreatedDate = new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(541),
                            Description = "lorem ipsum",
                            ImageUrl = "",
                            Name = "Billet4 ",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Answer1 = "adads",
                            Answer2 = "adadsad",
                            Answer3 = "",
                            Answer4 = "",
                            CorrectAnswer = "",
                            CreatedDate = new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(544),
                            Description = "lorem ipsum",
                            ImageUrl = "",
                            Name = "Billet5 ",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BilletAPI.Models.BilletUser", b =>
                {
                    b.Property<int>("BilletNo")
                        .HasColumnType("int");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BilletNo");

                    b.ToTable("BilletUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
