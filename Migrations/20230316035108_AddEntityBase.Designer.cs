﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prod.Data;

#nullable disable

namespace prod.Migrations
{
    [DbContext(typeof(prodContext))]
    [Migration("20230316035108_AddEntityBase")]
    partial class AddEntityBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("prod.Models.Category", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("categoryName");

                    b.Property<long?>("created_by")
                        .HasColumnType("bigint")
                        .HasComment("Audit column, created by");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("datetime2")
                        .HasComment("Audit column, created date");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("bit")
                        .HasComment("Flag Soft Delete");

                    b.Property<long?>("updated_by")
                        .HasColumnType("bigint")
                        .HasComment("Audit column, updated by");

                    b.Property<DateTime?>("updated_date")
                        .HasColumnType("datetime2")
                        .HasComment("Audit column, updated date");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("prod.Models.Product", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("Primary Key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long?>("Categoryid")
                        .HasColumnType("bigint");

                    b.Property<long?>("created_by")
                        .HasColumnType("bigint")
                        .HasComment("Audit column, created by");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("datetime2")
                        .HasComment("Audit column, created date");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("bit")
                        .HasComment("Flag Soft Delete");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("productName");

                    b.Property<long?>("updated_by")
                        .HasColumnType("bigint")
                        .HasComment("Audit column, updated by");

                    b.Property<DateTime?>("updated_date")
                        .HasColumnType("datetime2")
                        .HasComment("Audit column, updated date");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("prod.Models.Product", b =>
                {
                    b.HasOne("prod.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Categoryid");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}