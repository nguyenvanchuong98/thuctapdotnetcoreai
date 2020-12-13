﻿// <auto-generated />
using System;
using BaoCaoThucTap.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaoCaoThucTap.Migrations
{
    [DbContext(typeof(WebContext))]
    partial class WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BaoCaoThucTap.Models.AnhSanPham", b =>
                {
                    b.Property<int>("maanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("masp")
                        .HasColumnType("int");

                    b.Property<string>("urlAnh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maanh");

                    b.HasIndex("masp");

                    b.ToTable("anhSanPhams");
                });

            modelBuilder.Entity("BaoCaoThucTap.Models.SanPham", b =>
                {
                    b.Property<int>("masp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("giasp")
                        .HasColumnType("float");

                    b.Property<string>("motasp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngaynhap")
                        .HasColumnType("datetime2");

                    b.Property<string>("tensp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("masp");

                    b.ToTable("sanPhams");
                });

            modelBuilder.Entity("BaoCaoThucTap.Models.AnhSanPham", b =>
                {
                    b.HasOne("BaoCaoThucTap.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("masp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}