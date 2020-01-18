﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HomeNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PostCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 2137,
                            ApartmentNumber = 420,
                            City = "Wadowice",
                            HomeNumber = "JP2/GMD",
                            PostCode = "69-666",
                            Street = "Papieżowa"
                        },
                        new
                        {
                            Id = 666,
                            ApartmentNumber = 666,
                            City = "Piekło",
                            HomeNumber = "666/666",
                            PostCode = "66-666",
                            Street = "Ozzy'ego Osbourna"
                        });
                });

            modelBuilder.Entity("Model.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Login")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Pesel")
                        .HasColumnType("char(11) CHARACTER SET utf8mb4")
                        .IsFixedLength(true)
                        .HasMaxLength(11);

                    b.Property<string>("Surname")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1978, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Login = "admin",
                            Name = "Mariusz",
                            Password = "0DPiKuNIrrVmD8IUCuw1hQxNqZc=",
                            Pesel = "EZG 34XD23",
                            Surname = "Pudzianowski"
                        });
                });

            modelBuilder.Entity("Model.Models.Employment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<float>("Salary")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("StorePlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.HasIndex("StorePlaceId");

                    b.ToTable("Employments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            PositionId = 1,
                            Salary = 20000f,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Model.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CourierID")
                        .HasColumnType("int");

                    b.Property<float>("ParcelHeight")
                        .HasColumnType("float");

                    b.Property<float>("ParcelLength")
                        .HasColumnType("float");

                    b.Property<int>("ParcelStatus")
                        .HasColumnType("int");

                    b.Property<string>("ParcelType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("ParcelWeight")
                        .HasColumnType("float");

                    b.Property<float>("ParcelWidth")
                        .HasColumnType("float");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int?>("ReceiverDataId")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderDataId")
                        .HasColumnType("int");

                    b.Property<int>("StorePlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverDataId");

                    b.HasIndex("SenderDataId");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("Model.Models.PersonalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("PersonalAddressId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PersonalAddressId");

                    b.ToTable("PersonalDatas");
                });

            modelBuilder.Entity("Model.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("MaxSalary")
                        .HasColumnType("float");

                    b.Property<float>("MinSalary")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxSalary = 25000f,
                            MinSalary = 5000f,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            MaxSalary = 1000f,
                            MinSalary = 500f,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 3,
                            MaxSalary = 2000f,
                            MinSalary = 1500f,
                            Name = "Kurier"
                        },
                        new
                        {
                            Id = 4,
                            MaxSalary = 3000f,
                            MinSalary = 2500f,
                            Name = "Logistyk"
                        },
                        new
                        {
                            Id = 5,
                            MaxSalary = 1800f,
                            MinSalary = 1500f,
                            Name = "Magazynier"
                        },
                        new
                        {
                            Id = 6,
                            MaxSalary = 1800f,
                            MinSalary = 1200f,
                            Name = "Rejestracja"
                        });
                });

            modelBuilder.Entity("Model.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Model.Models.RoutePoint", b =>
                {
                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int?>("ParcelId")
                        .HasColumnType("int");

                    b.HasKey("RouteId", "Index");

                    b.HasIndex("ParcelId");

                    b.HasIndex("RouteId");

                    b.ToTable("RoutePoints");
                });

            modelBuilder.Entity("Model.Models.StorePlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("StorePlaces");

                    b.HasDiscriminator<int>("Type").HasValue(2);
                });

            modelBuilder.Entity("Model.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<float>("MaxCapacity")
                        .HasColumnType("float");

                    b.Property<float>("MaxLoad")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Registration")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int?>("StorePlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StorePlaceId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Model.Models.SendingPoint", b =>
                {
                    b.HasBaseType("Model.Models.StorePlace");

                    b.Property<int>("WorkersCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Model.Models.Warehouse", b =>
                {
                    b.HasBaseType("Model.Models.StorePlace");

                    b.Property<string>("ManagerName")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Model.Models.Employment", b =>
                {
                    b.HasOne("Model.Models.Employee", "Employee")
                        .WithMany("ActiveEmployments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Models.StorePlace", "StorePlace")
                        .WithMany()
                        .HasForeignKey("StorePlaceId");
                });

            modelBuilder.Entity("Model.Models.Parcel", b =>
                {
                    b.HasOne("Model.Models.PersonalData", "ReceiverData")
                        .WithMany()
                        .HasForeignKey("ReceiverDataId");

                    b.HasOne("Model.Models.PersonalData", "SenderData")
                        .WithMany()
                        .HasForeignKey("SenderDataId");
                });

            modelBuilder.Entity("Model.Models.PersonalData", b =>
                {
                    b.HasOne("Model.Models.Address", "PersonalAddress")
                        .WithMany()
                        .HasForeignKey("PersonalAddressId");
                });

            modelBuilder.Entity("Model.Models.Route", b =>
                {
                    b.HasOne("Model.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Model.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("Model.Models.RoutePoint", b =>
                {
                    b.HasOne("Model.Models.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelId");

                    b.HasOne("Model.Models.Route", "Route")
                        .WithMany("RoutePoints")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Models.StorePlace", b =>
                {
                    b.HasOne("Model.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Models.Vehicle", b =>
                {
                    b.HasOne("Model.Models.StorePlace", "StorePlace")
                        .WithMany()
                        .HasForeignKey("StorePlaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
