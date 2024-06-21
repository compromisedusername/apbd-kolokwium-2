﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apbd_kolokwium_2.Data;

#nullable disable

namespace apbd_kolokwium_2.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240621103549_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apbd_kolokwium_2.Models.ObjectColumn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Height")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<int>("Object_Type_ID")
                        .HasColumnType("int");

                    b.Property<int>("Warehouse_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Width")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.HasKey("ID");

                    b.HasIndex("Object_Type_ID");

                    b.HasIndex("Warehouse_ID");

                    b.ToTable("Object");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Height = 2m,
                            Object_Type_ID = 1,
                            Warehouse_ID = 1,
                            Width = 1m
                        });
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.ObjectOwner", b =>
                {
                    b.Property<int>("Object_ID")
                        .HasColumnType("int");

                    b.Property<int>("Owner_ID")
                        .HasColumnType("int");

                    b.HasKey("Object_ID", "Owner_ID");

                    b.HasIndex("Owner_ID");

                    b.ToTable("Object_Owner");

                    b.HasData(
                        new
                        {
                            Object_ID = 1,
                            Owner_ID = 1
                        });
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.ObjectType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Object_Type");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Name1"
                        });
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("ID");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Name1",
                            LastName = "LastName1",
                            PhoneNumber = "555555555"
                        });
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.Warehouse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Warehouse");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Name1"
                        });
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.ObjectColumn", b =>
                {
                    b.HasOne("apbd_kolokwium_2.Models.ObjectType", "ObjectType")
                        .WithMany("Objects")
                        .HasForeignKey("Object_Type_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apbd_kolokwium_2.Models.Warehouse", "Warehouse")
                        .WithMany("Objects")
                        .HasForeignKey("Warehouse_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectType");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.ObjectOwner", b =>
                {
                    b.HasOne("apbd_kolokwium_2.Models.ObjectColumn", "ObjectColumn")
                        .WithMany("ObjectOwners")
                        .HasForeignKey("Object_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apbd_kolokwium_2.Models.Owner", "Owner")
                        .WithMany("ObjectOwners")
                        .HasForeignKey("Owner_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectColumn");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.ObjectColumn", b =>
                {
                    b.Navigation("ObjectOwners");
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.ObjectType", b =>
                {
                    b.Navigation("Objects");
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.Owner", b =>
                {
                    b.Navigation("ObjectOwners");
                });

            modelBuilder.Entity("apbd_kolokwium_2.Models.Warehouse", b =>
                {
                    b.Navigation("Objects");
                });
#pragma warning restore 612, 618
        }
    }
}
