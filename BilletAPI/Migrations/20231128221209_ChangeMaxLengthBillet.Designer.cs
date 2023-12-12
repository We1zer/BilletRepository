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
    [Migration("20231128221209_ChangeMaxLengthBillet")]
    partial class ChangeMaxLengthBillet
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
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
                            CreatedDate = new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8028),
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
                            CreatedDate = new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8074),
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
                            CreatedDate = new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8076),
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
                            CreatedDate = new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8079),
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

                    b.Property<int>("BilletId")
                        .HasColumnType("int");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BilletNo");

                    b.HasIndex("BilletId");

                    b.ToTable("BilletUsers");
                });

            modelBuilder.Entity("BilletAPI.Models.BilletUser", b =>
                {
                    b.HasOne("BilletAPI.Models.Billet", "Billet")
                        .WithMany()
                        .HasForeignKey("BilletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billet");
                });
#pragma warning restore 612, 618
        }
    }
}