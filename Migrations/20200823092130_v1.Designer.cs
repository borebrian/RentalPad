﻿// <auto-generated />
using Fuela.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RentalPad.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20200823092130_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RentalPad.Models.Rental_Owners", b =>
                {
                    b.Property<int>("National_id")
                        .HasColumnType("int");

                    b.Property<int>("Full_names")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<int>("Paybill_number")
                        .HasColumnType("int");

                    b.Property<int>("Phone_number")
                        .HasColumnType("int");

                    b.HasKey("National_id");

                    b.ToTable("Rental_owners");
                });
#pragma warning restore 612, 618
        }
    }
}
