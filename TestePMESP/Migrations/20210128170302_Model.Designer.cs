﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestePMESP.Contexts;

namespace TestePMESP.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210128170302_Model")]
    partial class Model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TestePMESP.Models.Import", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ImportDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Import");
                });

            modelBuilder.Entity("TestePMESP.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ImportId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitaryPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ImportId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TestePMESP.Models.Product", b =>
                {
                    b.HasOne("TestePMESP.Models.Import", "Import")
                        .WithMany("Products")
                        .HasForeignKey("ImportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Import");
                });

            modelBuilder.Entity("TestePMESP.Models.Import", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
