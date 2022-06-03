﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonoProject.DAL.Data;

namespace MonoProject.DAL.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20220405211359_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleEngineType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abrv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleEngineTypes");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleMake", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abrv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abrv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EngineTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MakeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EngineTypeId")
                        .IsUnique();

                    b.HasIndex("MakeId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleModelToVehicleOwnerLink", b =>
                {
                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RegistrationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OwnerId", "ModelId", "RegistrationId");

                    b.HasIndex("ModelId");

                    b.HasIndex("RegistrationId")
                        .IsUnique();

                    b.ToTable("VehicleModelToVehicleOwnerLinks");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleOwners");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleRegistration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleRegistrations");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleModel", b =>
                {
                    b.HasOne("MonoProject.DAL.Models.VehicleEngineType", "VehicleEngineType")
                        .WithOne("VehicleModel")
                        .HasForeignKey("MonoProject.DAL.Models.VehicleModel", "EngineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MonoProject.DAL.Models.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleEngineType");

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleModelToVehicleOwnerLink", b =>
                {
                    b.HasOne("MonoProject.DAL.Models.VehicleModel", "VehicleModel")
                        .WithMany("VehicleModelToVehicleOwnerLinks")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MonoProject.DAL.Models.VehicleOwner", "VehicleOwner")
                        .WithMany("VehicleModelToVehicleOwnerLinks")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MonoProject.DAL.Models.VehicleRegistration", "VehicleRegistration")
                        .WithOne("VehicleModelToVehicleOwnerLink")
                        .HasForeignKey("MonoProject.DAL.Models.VehicleModelToVehicleOwnerLink", "RegistrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleModel");

                    b.Navigation("VehicleOwner");

                    b.Navigation("VehicleRegistration");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleEngineType", b =>
                {
                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleMake", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleModel", b =>
                {
                    b.Navigation("VehicleModelToVehicleOwnerLinks");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleOwner", b =>
                {
                    b.Navigation("VehicleModelToVehicleOwnerLinks");
                });

            modelBuilder.Entity("MonoProject.DAL.Models.VehicleRegistration", b =>
                {
                    b.Navigation("VehicleModelToVehicleOwnerLink");
                });
#pragma warning restore 612, 618
        }
    }
}