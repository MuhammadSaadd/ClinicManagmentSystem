﻿// <auto-generated />
using System;
using ClinicManagmentSystem.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicManagmentSystem.API.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230304160726_newUpdates")]
    partial class newUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Canceled")
                        .HasColumnType("bit");

                    b.Property<bool>("EposideVisitFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PhysicianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("PhysicianId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Availiable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Clinics", (string)null);
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.EpisodeVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.ToTable("EpisodeVisits", (string)null);
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Physician", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SSN")
                        .IsUnique();

                    b.ToTable("Physicians", (string)null);
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PhysicianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PhysicianId");

                    b.ToTable("Shifts", (string)null);
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Appointment", b =>
                {
                    b.HasOne("ClinicManagmentSystem.API.Data.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ClinicManagmentSystem.API.Data.Models.Physician", "Physician")
                        .WithMany("Appointments")
                        .HasForeignKey("PhysicianId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Patient");

                    b.Navigation("Physician");
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.EpisodeVisit", b =>
                {
                    b.HasOne("ClinicManagmentSystem.API.Data.Models.Appointment", "Appointment")
                        .WithOne("EpisodeVisit")
                        .HasForeignKey("ClinicManagmentSystem.API.Data.Models.EpisodeVisit", "AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Shift", b =>
                {
                    b.HasOne("ClinicManagmentSystem.API.Data.Models.Clinic", "Clinic")
                        .WithMany("Shifts")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagmentSystem.API.Data.Models.Physician", "Physician")
                        .WithMany("Shifts")
                        .HasForeignKey("PhysicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Physician");
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Appointment", b =>
                {
                    b.Navigation("EpisodeVisit");
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Clinic", b =>
                {
                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("ClinicManagmentSystem.API.Data.Models.Physician", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Shifts");
                });
#pragma warning restore 612, 618
        }
    }
}
