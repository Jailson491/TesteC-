﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Santader.UserControl.Data;

#nullable disable

namespace Santader.UserControl.Migrations.AppDbContextOraMigrations
{
    [DbContext(typeof(AppDbContextOra))]
    partial class AppDbContextOraModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Santader.UserControl.Models.DELETEUSER", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Process")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("ResignationDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("idUser")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("id");

                    b.ToTable("DeleteUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
