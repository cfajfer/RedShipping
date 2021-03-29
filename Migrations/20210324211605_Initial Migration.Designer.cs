﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedShipping.Models;

namespace RedShipping.Migrations
{
    [DbContext(typeof(redshippingDBContext))]
    [Migration("20210324211605_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RedShipping.Models.DBCarrier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cost")
                        .HasColumnType("int");

                    b.Property<bool>("hazard")
                        .HasColumnType("bit");

                    b.Property<int>("location")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("RedShipping.Models.DBFreight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("hazard")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Freights");
                });

            modelBuilder.Entity("RedShipping.Models.DBLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RedShipping.Models.DBShipment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("carrier")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime");

                    b.Property<int>("endLoc")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("shipper")
                        .HasColumnType("int");

                    b.Property<int>("startLoc")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("RedShipping.Models.DBShipper", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("freight")
                        .HasColumnType("int");

                    b.Property<int>("location")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Shippers");
                });
#pragma warning restore 612, 618
        }
    }
}